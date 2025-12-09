package org.parking.parkinglot.common;

public class UserDto {
    Long id;
    String username;
    String email;
    String password;

    public UserDto(Long id, String name, String email) {
        this.id = id;
        this.username = name;
        this.email = email;
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

}
