import java.io.File;
import java.io.FileNotFoundException;
import java.util.*;

public class Main {
    public static void main(String[] args) throws FileNotFoundException {
        List<Integer> list = new ArrayList<Integer>();
        Random rand = new Random();
        for (int i = 0; i < 23; i++) {
            list.add(rand.nextInt(100));
        }
//        for (int i = 0; i < list.size(); i++) {
//            System.out.println(list.get(i));
//        }
        Set<String> set = new TreeSet<String>();
        for (int i = 1; i <= 2; i++) {
            set.add("test"+ " " + i);
        }
//        for (String s : set) {
//            System.out.println(s);
//        }
        Scanner sc;
        String fileName = "C:\\ProjectsGit\\PersonalProjects\\Laboratoare paradigme\\Laborator3\\src\\date.txt";
        File file = new File(fileName);
        sc = new Scanner(file);
        Map<String,Integer> cuvinte = new HashMap<String, Integer>();
        for(int i  =0; i < 6; i++) {
            String line = sc.next();
            line = line.toLowerCase();
            if(!cuvinte.containsKey(line)) {
                cuvinte.put(line, 1);
            }
            else {
                cuvinte.put(line, cuvinte.get(line) + 1);
            }
        }
        for(String cuvant: cuvinte.keySet()) {
            System.out.println(cuvant + " " + cuvinte.get(cuvant));
        }
    }
}