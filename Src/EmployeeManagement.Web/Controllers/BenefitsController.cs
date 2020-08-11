using AutoMapper;
using EmployeeManagement.Core.Model;
using EmployeeManagement.Core.Repositories;
using EmployeeManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Web.Controllers
{
    public class BenefitsController : Controller
    {
        private readonly IBenefitsRepository benefitsRepository;
        private readonly IMapper mapper;

        public BenefitsController(IBenefitsRepository benefitsRepository, IMapper mapper)
        {
            this.benefitsRepository = benefitsRepository;
            this.mapper = mapper;
        }

        // GET: Benefits
        public IActionResult Index()
        {
            return View((mapper.Map<BenefitPolicy, BenefitPolicyViewModel>(benefitsRepository.GetCompanyBenefitsInformation())));
        }

        // GET: Benefits/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benefitPolicy = benefitsRepository.GetCompanyBenefitsInformation();
            if (benefitPolicy == null)
            {
                return NotFound();
            }

            return View(mapper.Map<BenefitPolicy, BenefitPolicyViewModel>(benefitPolicy));
        }

        // GET: Benefits/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benefitPolicy = benefitsRepository.GetCompanyBenefitsInformation();
            if (benefitPolicy == null)
            {
                return NotFound();
            }
            return View(mapper.Map<BenefitPolicy, BenefitPolicyViewModel>(benefitPolicy));
        }

        // POST: Benefits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,EmployeeCostPerYear,DependentCostPerYear,LetterToDiscount,DiscountAmount,IsActive,ChecksPerYear")] BenefitPolicyViewModel benefitPolicy)
        {
            if (id != benefitPolicy.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    benefitsRepository.UpdateCompanyBenefits(mapper.Map<BenefitPolicyViewModel, BenefitPolicy>(benefitPolicy));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(benefitPolicy);
        }
    }
}