import java.util.ArrayList;
import java.util.List;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        ArrayList<String> nume=new ArrayList<>();
        nume.add("Ana");
        nume.add("Mary");
        nume.add("Alexandru");

        List<String> numeMaiMiciDe5= nume.stream()
                .filter((numePersoana)->numePersoana.length()>5)
                .toList();

        List<String> numeUpperCase = nume.stream()
                .map((numePersoana)->numePersoana.toUpperCase())
                .toList();

        List<String> numeConcatenate=nume.stream()
                .map((numePersoana)->numePersoana)
                .toList();

        List<String> numeMaiMiciDe6SiLowerCase=nume.stream()
                .filter((numePersoana)->numePersoana.length()<6)
                .map((numePersoana)->numePersoana.toLowerCase())
                .toList();


        nume.stream()
                .filter((numePersoana)->numePersoana.length()>5)
                .forEach((numePersoana)->System.out.print(numePersoana));

        System.out.println();
        nume.stream()
                .map((numePersoana)->numePersoana.toUpperCase())
                .forEach((numePersoana)->System.out.print(numePersoana + " "));

        System.out.println();
        nume.stream()
                .map((numePersoana)->numePersoana + ",")
                .forEach((numePersoana)->System.out.print(numePersoana + " "));

        System.out.println();

        nume.stream()
                .filter((numePersoana)->numePersoana.length()<6)
                .map((numePersoana)->numePersoana.toLowerCase())
                .forEach((numePersoana)->System.out.print(numePersoana + " "));

        System.out.println();

        for(String numePersoana:nume){
            if(numePersoana.length()<6){
                numePersoana= numePersoana.toLowerCase();
                System.out.print(numePersoana + " ");
            }
        }
    }

}