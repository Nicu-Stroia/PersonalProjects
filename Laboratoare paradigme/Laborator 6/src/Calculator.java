public class Calculator {
    protected double x;

    public Calculator() {
        this.x = 0;
    }

    public Calculator(double x) {
        this.x = x;
    }

    public double Adunare(double numar){
        x += numar;
        return x;
    }

    public double Scadere(double numar){
        x -= numar;
        return x;
    }

    public double Inmultire(double numar){
        x *= numar;
        return x;
    }

    public double Impartire(double numar){
        if(numar==0){
            throw new ArithmeticException("Nu se poate imparti la 0");
        }
        x/=numar;
        return x;
    }

    public void getRezultat(){
        System.out.println("Rezultat " + x);
    }
}
