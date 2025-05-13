class Dog //public/internal
{
    class DogData // Движок содержится в машине (Композиция)
    {   // public/internal/protected/private
        
    }

    public int Paws { get; set; } // было полем стало свойством

    public int GetPaws
    {
        get => Paws;
        set {  
            if (value > 0)
                Paws = value; 
        }
    }

    public string Tail { private get; set; } = "Black";

    public void Lie()
    {

    }

    public Dog() : this(4, "Black" ){ }
    public Dog(int paws)
    {
        Paws = paws;
    }
    public Dog(int paws, string tail)
    {
        Paws = paws;
        Tail = tail;
    }

    class Puppy : Dog
    {
        public Puppy() : base(4) { }
    }
}