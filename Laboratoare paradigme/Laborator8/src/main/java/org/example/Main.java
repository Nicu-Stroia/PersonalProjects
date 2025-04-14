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
            FileInputStream file = new FileInputStream(new File("C:\\ProjectsGit\\PersonalProjects\\Laboratoare paradigme\\Laborator8\\src\\TestExcel.xlsx"));
            // Create Workbook instance holding reference to
            // .xlsx file
            XSSFWorkbook workbook = new XSSFWorkbook(file);

            // Get first/desired sheet from the workbook
            XSSFSheet sheet = workbook.getSheetAt(0);

            XSSFWorkbook outputWorkbook = new XSSFWorkbook();
            XSSFSheet outputSheet = outputWorkbook.createSheet("Modified");

            int rowNum=0;

            for(Row row : sheet) {
                Row newRow = outputSheet.createRow(rowNum++);

                int cellnum = 0;

                for(Cell cell : row) {
                    Cell newCell = newRow.createCell(cellnum);

                    if(cellnum==row.getLastCellNum()-1 && cell.getCellType() == CellType.NUMERIC){
                        double newAge=cell.getNumericCellValue()+1;
                        newCell.setCellValue(newAge);
                    }
                    else{
                        switch (cell.getCellType()) {

                            // Case 1
                            case NUMERIC:
                                newCell.setCellValue(cell.getNumericCellValue());
                                break;

                            // Case 2
                            case STRING:
                                newCell.setCellValue(cell.getStringCellValue());
                                break;
                        }
                    }
                    cellnum++;
                }
            }

            FileOutputStream outputFile = new FileOutputStream("C:\\ProjectsGit\\PersonalProjects\\Laboratoare paradigme\\Laborator8\\src\\Output.xlsx");
            outputWorkbook.write(outputFile);

            outputFile.close();
            workbook.close();
            outputWorkbook.close();
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
