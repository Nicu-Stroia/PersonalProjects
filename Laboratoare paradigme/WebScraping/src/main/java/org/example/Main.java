package org.example;

import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;
import org.apache.poi.ss.usermodel.Workbook;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.FileOutputStream;
import java.io.IOException;

public class Main {
    public static void main(String[] args) {

        String outputPath = args[0];
        String url = "https://ulbsibiu.ro/";

        try {
            Document document = Jsoup.connect(url).get();

            Element divContainer = document.selectFirst("div#navbarCollapse");

            Elements links = divContainer.select("> ul#primary-menu > li > a");

            Workbook menuWorkbook = new XSSFWorkbook();
            Sheet menuSheet = menuWorkbook.createSheet("MenuScraper");
            int rowIndex = 0;
            for (Element link : links) {
                Row row = menuSheet.createRow(rowIndex++);
                row.createCell(0).setCellValue(link.text());
            }

            try (FileOutputStream excelFile = new FileOutputStream(outputPath)) {
                menuWorkbook.write(excelFile);
            }

            menuWorkbook.close();
        }

        catch (IOException e) {
            e.printStackTrace();
        }
    }
}