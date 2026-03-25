package org.parking.parkinglot.common;

import java.util.List;

public class UserDto {
    Long id;
    String username;
    String email;
    String password;
    private List<String> userGroups;

    public UserDto(Long id, String name, String email, List<String> userGroups) {
        this.id = id;
        this.username = name;
        this.email = email;
        this.userGroups = userGroups;
    }

    public String getUsername() {
        return username;
    }

    public String getEmail() {
        return email;
    }

    public Long getId() {
        return id;
    }

    public String getPassword() {
        return password;
    }

    public List<String> getUserGroups() {
        return userGroups;
    }
}
