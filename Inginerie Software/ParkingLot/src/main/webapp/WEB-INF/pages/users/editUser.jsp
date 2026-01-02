<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@taglib prefix="t" tagdir="/WEB-INF/tags" %>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<t:pageTemplate pageTitle="Edit User">
    <h2>Edit User</h2>

    <form class="needs-validation" novalidate method="POST" action="${pageContext.request.contextPath}/EditUser">

        <input type="hidden" name="user_id" value="${user.id}" />

        <div class="row">

            <div class="col-md-12 mb-3">
                <label for="username">Username</label>
                <input type="text" class="form-control" id="username" name="username" placeholder="" value="${user.username}" required>
                <div class="invalid-feedback">
                    Username is required.
                </div>
            </div>

            <div class="col-md-12 mb-3">
                <label for="email">Email</label>
                <input type="email" class="form-control" id="email" name="email" placeholder="" value="${user.email}" required>
                <div class="invalid-feedback">
                    Email is required.
                </div>
            </div>

            <div class="col-md-12 mb-3">
                <label for="password">Password</label>
                <input type="password" class="form-control" id="password" name="password" placeholder="Leave empty to keep current password">
                <div class="invalid-feedback">
                    Password is required only if you want to change it.
                </div>
            </div>

            <div class="col-md-12 mb-3">
                <label for="user_groups">User Groups</label>
                <select class="custom-select d-block w-100" id="user_groups" name="user_groups" multiple>
                    <c:forEach var="group" items="${userGroups}">
                        <option value="${group}">${group}</option>
                    </c:forEach>
                </select>
            </div>
        </div>

        <hr class="mb-4">
        <button class="btn btn-primary btn-lg btn-block" type="submit">Save</button>
    </form>
</t:pageTemplate>