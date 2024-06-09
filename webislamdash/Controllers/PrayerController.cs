using Microsoft.AspNetCore.Mvc;
using webislamdash.Models;
using webislamdash.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using webislamdash.Data;
using Microsoft.EntityFrameworkCore;

public class PrayerController : Controller
{
    private readonly IPrayerTimeService _prayerTimeService;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public PrayerController(IPrayerTimeService prayerTimeService, ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _prayerTimeService = prayerTimeService;
        _context = context;
        _userManager = userManager;
    }
    public async Task<IActionResult> EnterCity(string city, string country)
    {
        if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(country))
        {
            try
            {
                var prayerTimes = await _prayerTimeService.GetPrayerTimes(city, country);
                return View("Index", (prayerTimes, city, country));
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError(string.Empty, "Invalid city or country. Please try again.");
            }
        }

        return View();
    }
    public async Task<IActionResult> Index(string city, string country)
    {
        if (User.Identity.IsAuthenticated)
        {
            var userId = _userManager.GetUserId(User);

            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(country))
            {
                var existingCity = await _context.CityInfos
                    .FirstOrDefaultAsync(ci => ci.UserId == userId);

                if (existingCity != null)
                {
                    existingCity.City = city;
                    existingCity.Country = country;
                    _context.CityInfos.Update(existingCity);
                }
                else
                {
                    var newCityInfo = new CityInfo
                    {
                        UserId = userId,
                        City = city,
                        Country = country
                    };
                    await _context.CityInfos.AddAsync(newCityInfo);
                }

                await _context.SaveChangesAsync();
            }

            var userCityInfo = await _context.CityInfos
                .FirstOrDefaultAsync(ci => ci.UserId == userId);

            if (userCityInfo != null)
            {
                try
                {
                    var prayerTimes = await _prayerTimeService.GetPrayerTimes(userCityInfo.City, userCityInfo.Country);
                    return View((prayerTimes, userCityInfo.City, userCityInfo.Country));
                }
                catch (HttpRequestException)
                {
                    return RedirectToAction("EnterCity");
                }
            }
            return RedirectToAction("EnterCity");
        }
        else
        {
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(country))
            {
                try
                {
                    var prayerTimes = await _prayerTimeService.GetPrayerTimes(city, country);
                    return View("Index", (prayerTimes, city, country));
                }
                catch (HttpRequestException)
                {
                    return RedirectToAction("EnterCity");
                }
            }
            return RedirectToAction("EnterCity");
        }
    }
    public async Task<IActionResult> ChangeCity()
    {
        if (User.Identity.IsAuthenticated)
        {
            var userId = _userManager.GetUserId(User);

            var existingCity = await _context.CityInfos
                .FirstOrDefaultAsync(ci => ci.UserId == userId);

            if (existingCity != null)
            {
                _context.CityInfos.Remove(existingCity);
                await _context.SaveChangesAsync();
            }
        }
        return RedirectToAction("EnterCity");
    }
}