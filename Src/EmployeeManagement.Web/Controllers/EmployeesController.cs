using AutoMapper;
using EmployeeManagement.Core;
using EmployeeManagement.Core.Model;
using EmployeeManagement.Core.Repositories;
using EmployeeManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        // GET: Employees
        public IActionResult Index()
        {
            return View((mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employeeRepository.GetEmployees())));
        }

        //GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeRepository.GetEmployeeByID(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(mapper.Map<Employee, EmployeeViewModel>(employee));
        }

        //[Bind("EmployeeVM,Relationship,CurrentDependents,LastName,FirstName")]
        public IActionResult Dependents(DependentViewModel vm)
        {
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddDependents([Bind("EmployeeVM,EmployeeID,LastName,FirstName,Relationship,Dependents")] DependentViewModel dependentViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = employeeRepository.GetEmployeeByID(dependentViewModel.EmployeeID);
                if (employee == null)
                {
                    return NotFound();
                }

                var dependent = mapper.Map<DependentViewModel, Dependent>(dependentViewModel);
                var listOfDependents = employee.Dependents == null ? new List<Dependent>() : employee.Dependents.ToList();
                listOfDependents.Add(dependent);
                employee.Dependents = listOfDependents;
                employeeRepository.AddEntity(dependent);
                dependentViewModel.CurrentDependents =
                    mapper.Map<List<Dependent>, List<DependentViewModel>>(listOfDependents);

                return View(nameof(Dependents), dependentViewModel);
            }
            return View(nameof(Dependents), dependentViewModel);
        }

        public IActionResult PreviewCosts(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeCosts = employeeRepository.GetEmployeeCost(id.Value);
            if (employeeCosts == null)
            {
                return NotFound();
            }
            return View(employeeCosts);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Salary,ID,LastName,FirstName,Email,Dependents")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.AddEntity(employee);
                var vm = new DependentViewModel { EmployeeID = employee.ID };
                return View(nameof(Dependents), vm);
            }
            return View(mapper.Map<Employee, EmployeeViewModel>(employee));
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeRepository.GetEmployeeByID(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            return View(mapper.Map<Employee, EmployeeViewModel>(employee));
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Salary,ID,LastName,FirstName,Email,Dependents")] Employee employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employeeRepository.UpdateEmployee(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mapper.Map<Employee, EmployeeViewModel>(employee));
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeRepository.GetEmployeeByID(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(mapper.Map<Employee, EmployeeViewModel>(employee));
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            employeeRepository.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return employeeRepository.EmployeeExists(id);
        }
    }
}