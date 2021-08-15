using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Interface;
using Identity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Role> roles = await _roleService.GetRoles();
            return View(roles);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Role role)
        {
            if (ModelState.IsValid)
            {
                await _roleService.Add(role.Name);
                ViewBag.result = "Record Inserted Successfully!";
                ModelState.Clear();

                return RedirectToAction("Index");
            }

            return View(role);
        }

        public async Task<ActionResult> Delete(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                ModelState.AddModelError("", "Please Select Correct Role");
                return View();
            }

            var output = await _roleService.Remove(roleName);
            if (output.Result)
            {
                ViewBag.result = "Record Delete Successfully!";
                return RedirectToAction("Index");
            }

            foreach (var error in output.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return View();
        }

        [HttpGet("Role/Update")]
        public async Task<IActionResult> UpdateAsync(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                ModelState.AddModelError("", "Please Select Correct Role");
                return View();
            }

            var result = await _roleService.Get(roleId);
            var role = new Role(result.Id, result.Name);
            return View(role);
        }

        [HttpPost("Role/Update")]
        public async Task<IActionResult> Update(Role role)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleService.Get(role.Id);
                result.Name = role.Name;
                await _roleService.Update(result);

                ViewBag.result = "Record Update Successfully!";
                ModelState.Clear();

                return RedirectToAction("Index");
            }

            return View(role);
        }
    }
}
