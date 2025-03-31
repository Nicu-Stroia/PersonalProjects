//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        Calculator c = new Calculator(5);
        c.Adunare(2);
        c.Scadere(1);
        c.getRezultat();

        AdvancedCalculator cA = new AdvancedCalculator(5);
        cA.Exponent(-2);
        cA.getRezultat();
    }
}