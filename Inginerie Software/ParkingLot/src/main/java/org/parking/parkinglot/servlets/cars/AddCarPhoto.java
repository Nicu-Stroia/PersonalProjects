package org.parking.parkinglot.servlets.cars;

import jakarta.inject.Inject;
import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;
import org.parking.parkinglot.ejb.CarsBean;
import org.parking.parkinglot.common.CarDto;

import java.io.IOException;

@MultipartConfig
@WebServlet(name = "AddCarPhoto", value = "/AddCarPhoto")
public class AddCarPhoto extends HttpServlet {

    @Inject
    CarsBean carsBean;

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        Long carId = Long.parseLong(request.getParameter("id"));
        CarDto car = carsBean.findById(carId);
        request.setAttribute("car", car);

        request.getRequestDispatcher("/WEB-INF/pages/cars/addCarPhoto.jsp").forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        Long carId = Long.parseLong(request.getParameter("car_id"));

        Part filePart = request.getPart("file");
        String fileName = filePart.getSubmittedFileName();
        String filetType = filePart.getContentType();
        long fileSize = filePart.getSize();
        byte[] fileContent = new byte[(int) fileSize];
        filePart.getInputStream().read(fileContent);

        carsBean.addPhotoToCar(carId, fileName, filetType, fileContent);
        response.sendRedirect(request.getContextPath() + "/Cars");
    }
}