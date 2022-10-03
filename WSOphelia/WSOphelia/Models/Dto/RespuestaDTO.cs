namespace WSOphelia.Models.Dto
{
    public class RespuestaDTO
    {
        public bool Ok { get; set; } = true;
        public string Message { get; set; }
        public object Result { get; set; }
        public List<string> Errors { get; set; }
    }
}
