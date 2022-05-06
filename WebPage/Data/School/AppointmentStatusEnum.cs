namespace Personal.Data
{
    public enum AppointmentStatusEnum : short
    {
        Created = 1,
        Confirmed = 2,
        Completed = 3,
        Deleted = 4,
        RejectedByBusiness = 30,
        CanceledByclient = 31
    }
}