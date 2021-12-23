namespace DoctorPet.Application.Model.Output
{
    public  class AnimalOutput
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int TipoAnimalId { get; set; }
        public int ClienteId { get; set; }
    }
}
