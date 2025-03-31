public class Calculator {
    protected double x;

    public Calculator() {
        this.x = 0;
    }

    public Calculator(double x) {
        this.x = x;
    }

    public Calculator Adunare(double numar){
        x += numar;
        return this;
    }

    public Calculator Scadere(double numar){
        x -= numar;
        return this;
    }

    public Calculator Inmultire(double numar){
        x *= numar;
        return this;
    }

    public Calculator Impartire(double numar){
        if(numar==0){
            throw new ArithmeticException("Nu se poate imparti la 0");
        }
        x/=numar;
        return this;
    }

    public Calculator Radical(){
        if(x<=-1){
            throw new ArithmeticException("Nu se poate face radical din numere negative");
        }
        x=Math.sqrt(x);
        return this;
    }

    public Calculator Exponent(int numar){
        if(x<=-1){
            x = 1/(Math.pow(x,numar));
        }
        x = Math.pow(x,numar);
        return this;
    }

    public void getRezultat(){
        System.out.println("Rezultat " + x);
    }
}
