﻿using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IMedicalRecordRepository
{
    Task<MedicalRecord?> GetMedicalRecordById(int id);
    Task<MedicalRecord?> GetMedicalRecordByPatientId(int patientId);
    Task UpdateMedicalRecord(MedicalRecord medicalRecord);
}