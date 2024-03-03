namespace Calculator.Models.Entities
{
    public class Calculation
    {
        public Guid Id { get; set; }
        public string? operand1 { get; set; }
        public string? operand2 { get; set; }
        
        public  string? result {  get; set; }

        public string? opeator {  get; set; }

	}
}
