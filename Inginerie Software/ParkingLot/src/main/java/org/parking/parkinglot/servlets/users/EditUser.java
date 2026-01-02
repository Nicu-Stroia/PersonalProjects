package org.parking.parkinglot.servlets.users;

import jakarta.inject.Inject;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.HttpConstraint;
import jakarta.servlet.annotation.ServletSecurity;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.parking.parkinglot.common.UserDto;
import org.parking.parkinglot.ejb.UserBean;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

@ServletSecurity(value = @HttpConstraint(rolesAllowed = {"WRITE_USERS"}))
@WebServlet(name = "EditUser", value = "/EditUser")
public class EditUser extends HttpServlet {

    @Inject
    UserBean userBean;

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String idAsString = request.getParameter("id");

        if (idAsString != null) {
            Long id = Long.parseLong(idAsString);
            UserDto user = userBean.findById(id);
            request.setAttribute("user", user);
        }

        List<String> userGroups = Arrays.asList("READ_USERS", "WRITE_USERS", "INVOICING", "READ_CARS", "WRITE_CARS");
        request.setAttribute("userGroups", userGroups);

        request.getRequestDispatcher("/WEB-INF/pages/users/editUser.jsp").forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String idAsString = request.getParameter("user_id");
        String username = request.getParameter("username");
        String email = request.getParameter("email");
        String password = request.getParameter("password");

        String[] userGroupsArray = request.getParameterValues("user_groups");

        List<String> userGroups = new ArrayList<>();
        if (userGroupsArray != null) {
            userGroups = Arrays.asList(userGroupsArray);
        }

        Long id = Long.parseLong(idAsString);

        userBean.updateUser(id, username, email, password, userGroups);

        response.sendRedirect(request.getContextPath() + "/Users");
    }
}
