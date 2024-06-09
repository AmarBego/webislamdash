using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webislamdash.Models;
using webislamdash.Services;

public class CalendarController : Controller
{
    private readonly CalendarService _calendarService;

    public CalendarController(CalendarService calendarService)
    {
        _calendarService = calendarService;
    }

    public async Task<IActionResult> Index(int? month, int? year)
    {
        // If month and year parameters are not provided, default to current month and year
        if (!month.HasValue || !year.HasValue)
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
        }

        var hijriCalendar = await _calendarService.FetchHijriCalendar(month.Value, year.Value);
        return View(hijriCalendar);
    }
}
