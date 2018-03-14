namespace Nicollas.Dto.Realtime
{
    public class RealtimeDto
    {
        public ActionNeeded ActionNeeded { get; set; }
        public string Reducer { get; set; }
        public string Type { get; set; }
        public string ActionName { get; set; }
        public object Result { get; set; }
        public string Method { get; set; }
        public string Callback { get; set; }
    }
}
