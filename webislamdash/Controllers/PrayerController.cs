using Microsoft.AspNetCore.Mvc;
using webislamdash.Services;

public class PrayerController : Controller
{
    private readonly IPrayerTimeService _prayerTimeService;

    public PrayerController(IPrayerTimeService prayerTimeService)
    {
        _prayerTimeService = prayerTimeService;
    }

    public async Task<IActionResult> Index(string city, string country)
    {
        if (string.IsNullOrEmpty(city))
        {
            return View("EnterCity");
        }

        var prayerTimes = await _prayerTimeService.GetPrayerTimes(city, country);
        return View(prayerTimes);
    }

}