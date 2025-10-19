import java.util.Objects;

public class Sali {
    String cod;
    String nume;
    String etaj;
    int numarCalculatoare;

    public Sali(){

    }

    public Sali(String cod, String nume, String etaj, int numarCalculatoare) {
        this.cod = cod;
        this.nume = nume;
        this.etaj = etaj;
        this.numarCalculatoare = numarCalculatoare;
    }

    @Override
    public String toString() {
        return this.cod + " " + this.nume + " " + this.etaj + " " + this.numarCalculatoare;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null) return false;
        Sali sali = (Sali) o;
        if(((Sali) o).etaj.equals(this.etaj)){
            return true;
        }
        if(((Sali) o).cod.equals(this.cod)){
            return true;
        }
        if(((Sali) o).nume.equals(this.nume)){
            return true;
        }
        return false;
    }

    @Override
    public int hashCode() {
        return Objects.hashCode(etaj);
    }
}
