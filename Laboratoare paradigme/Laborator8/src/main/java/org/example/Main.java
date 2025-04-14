package org.example;

import org.apache.poi.ss.usermodel.*;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.*;
import java.util.Iterator;

public class Main {
    public static void main(String[] args) {
        // Try block to check for exceptions
        try {

            // Reading file from local directory
            FileInputStream file = new FileInputStream(
                    new File("C:\\ProjectsGit\\PersonalProjects\\Laboratoare paradigme\\Laborator8\\src\\TestExcel.xlsx"));

            // Create Workbook instance holding reference to
            // .xlsx file
            XSSFWorkbook workbook = new XSSFWorkbook(file);

            // Get first/desired sheet from the workbook
            XSSFSheet sheet = workbook.getSheetAt(0);

            // Iterate through each rows one by one
            Iterator<Row> rowIterator = sheet.iterator();

            double sum = 0;
            int count = 0;

            for (Row row : sheet) {
                Cell cell = row.getCell(2);
                if (cell != null && cell.getCellType() == CellType.NUMERIC) {
                    sum += cell.getNumericCellValue();
                    count++;
                }
            }

            if (count > 0) {
                Row row = sheet.getRow(0);
                if (row == null) {
                    row = sheet.createRow(0);
                }
                Cell cell = row.getCell(4);
                if (cell == null) {
                    cell = row.createCell(4);
                }
                cell.setCellValue(sum / count);
            }
            // Till there is an element condition holds true
            while (rowIterator.hasNext()) {

                Row row = rowIterator.next();

                // For each row, iterate through all the
                // columns
                Iterator<Cell> cellIterator
                        = row.cellIterator();

                while (cellIterator.hasNext()) {

                    Cell cell = cellIterator.next();

                    // Checking the cell type and format
                    // accordingly
                    switch (cell.getCellType()) {

                        // Case 1
                        case NUMERIC:
                            System.out.print(
                                    cell.getNumericCellValue()
                                            + " ");
                            break;

                        // Case 2
                        case STRING:
                            System.out.print(
                                    cell.getStringCellValue()
                                            + " ");
                            break;
                    }
                }

                System.out.println("");
            }

            // Closing file output streams
            file.close();
        }

        // Catch block to handle exceptions
        catch (Exception e) {

            // Display the exception along with line number
            // using printStackTrace() method
            e.printStackTrace();
        }
    }
}
