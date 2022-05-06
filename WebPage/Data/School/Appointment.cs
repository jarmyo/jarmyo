namespace Personal.Data
{
    public class Appointment
    {
        [Key]
        public string Id { get; set; }        
        /// <summary>
        /// Date separated from time for static purposes
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateOnly Date { get; set; }
        /// <summary>
        /// Separated from Date for statics purpouses
        /// </summary>
        [DataType(DataType.Time)]
        public TimeOnly Time { get; set; }
        /// <summary>
        /// Easy code its generated 6 Alphanumeric string easy to remember
        /// </summary>
        public string EasyCode { get; set; }
        /// <summary>
        /// To secure the appointment
        /// </summary>
        public string PINCode { get; set; }
        public string IdService { get; set; }
        public string IdClient { get; set; }
        public string IdBusiness { get; set; }
        public AppointmentStatusEnum Status { get; set; }
    }
}