public class AdvancedCalculator extends Calculator {
    public AdvancedCalculator() {
        super();
    }

    public AdvancedCalculator(double x) {
        super(x);
    }

    public double Radical(){
        if(x<=-1){
            throw new ArithmeticException("Nu se poate face radical din numere negative");
        }
        x=Math.sqrt(x);
        return x;
    }

    public double Exponent(int numar){
        if(x<=-1){
            x = 1/(Math.pow(x,numar));
        }
        x = Math.pow(x,numar);
        return x;
    }
}
