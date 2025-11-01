package org.example;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.*;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        groupProducts("Produse.txt", "ProduseSortate.txt");
    }

    public static void groupProducts(String inputFile, String outputFile) {
        try {
            List<String> lines = Files.readAllLines(Paths.get(inputFile));

            Set<String> uniqueLines = new HashSet<>(lines);

            Map<String, Integer> categoryCount = new HashMap<>();
            for (String line : uniqueLines) {
                String[] parts = line.split(" ");

                String category = parts[1];
                int count = categoryCount.getOrDefault(category, 0);
                categoryCount.put(category, count + 1);
            }

            List<String> sortedCategories = new ArrayList<>(categoryCount.keySet());
            Collections.sort(sortedCategories);

            List<String> outputLines = new ArrayList<>();

            for (String category : sortedCategories) {
                int count = categoryCount.get(category);
                outputLines.add(category + ": " + count + " produse");
            }

            Files.write(Paths.get(outputFile), outputLines);

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}