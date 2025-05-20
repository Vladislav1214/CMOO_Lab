using System.Data;
namespace Cm1_Lab_10;

[Serializable]
public class DoctorAppointment
{
    private string? _doctorFullName;
    private string? _doctorQualification;
    private DateTime _visitDate;
    private int _officeNumber;
    private int _patientExaminationTime;
    private string[]? _registeredPatients;

    public DoctorAppointment() { }
    
    public DoctorAppointment(string doctorFullName, string doctorQualification, DateTime visitDate, int officeNumber, int patientExaminationTime,
        string[] registeredPatients)
    {
        _doctorFullName = doctorFullName;
        _doctorQualification = doctorQualification;
        _visitDate = visitDate;
        _officeNumber = officeNumber;
        _patientExaminationTime = patientExaminationTime;
        _registeredPatients = registeredPatients;
    }
    
    public string DoctorFullName
    {
        get { return _doctorFullName?? "NoDoctor"; }
        set { _doctorFullName = value; }
    }

    public string DoctorQualification
    {
        get { return _doctorQualification?? "NoDoctor"; }
        set { _doctorQualification = value; }
    }

    public DateTime VisitDate
    {
        get { return _visitDate; }
        set { _visitDate = value; }
    }

    public int OfficeNumber
    {
        get { return _officeNumber; }
        set { _officeNumber = value; }
    }

    public int PatientExaminationTime
    {
        get { return _patientExaminationTime; }
        set { _patientExaminationTime = value; }
    }

    public string[] RegisteredPatients
    {
        get
        {
            if (_registeredPatients == null)
            {
                _registeredPatients = new string[1];
                _registeredPatients[0] = "NoPatients";
            }
            
            return _registeredPatients;
        }
        set { _registeredPatients = value; }
    }

    public override string ToString()
    {
        return $"ПІБ лікаря: {DoctorFullName}, " +
               $"Кваліфікація лікаря: {DoctorQualification}, " +
               $"Дата відвідування: {VisitDate:yyyy-MM-dd HH:mm}, " +
               $"Номер кабінету: {OfficeNumber}, " +
               $"Час огляду пацієнта: {PatientExaminationTime} хвилин, " +
               $"Записані пацієнти: {string.Join(", ", RegisteredPatients)}";
    }
}