namespace CheckPassword.Models {
    public class Evaluation {
        public int Score {  get; set; }
        public bool HasLower {  get; set; }
        public bool HasUpper { get; set; }
        public bool HasNumber { get; set; }
        public bool HasSymbol { get; set; }
        public double Entropy { get; set; }
    }
}
