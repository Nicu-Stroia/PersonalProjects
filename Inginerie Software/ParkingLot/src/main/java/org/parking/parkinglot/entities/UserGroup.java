package org.parking.parkinglot.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "usergroups")
public class UserGroup {
    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE)
    @Column(name = "id", nullable = false)
    private Long id;

    @Column(name = "username")
    private String username;

    @Column(name = "user_group")
    private String userGroup;

    public void setUserGroup(String userGroup) {
        this.userGroup = userGroup;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
