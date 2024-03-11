using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LifeLinkAPI.Application.DTOs;
using LifeLinkAPI.Application.Interfaces.IServices;

namespace LifeLinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMedicalDataService _medicalDataService;

        public PatientController(IMedicalDataService medicalDataService)
        {
            _medicalDataService = medicalDataService;
        }
    }
}
