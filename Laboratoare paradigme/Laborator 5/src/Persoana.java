import java.util.Objects;

public class Persoana  {
    public String prenume;
    public String nume;
    public int varsta;

    Persoana(String prenume,String nume, int varsta) {
        this.prenume = prenume;
        this.nume = nume;
        this.varsta = varsta;
    }

    public String getNume() {
        return nume;
    }

    public String toString() {
        return prenume + " " + nume + " " + varsta;
    }
}
