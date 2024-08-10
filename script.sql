create table User_Profiles
(
    user_id     int          not null
        primary key,
    address     varchar(255) null,
    city        varchar(100) null,
    state       varchar(100) null,
    postal_code varchar(20)  null,
    phone       varchar(20)  null,
    country     varchar(100) null,
    constraint user_profiles_ibfk_1
        foreign key (user_id) references Users (UserId)
            on delete cascade
);

create table User_Sessions
(
    session_id  int auto_increment
        primary key,
    user_id     int                  null,
    login_time  datetime             not null,
    logout_time datetime             null on update CURRENT_TIMESTAMP,
    is_active   tinyint(1) default 1 not null,
    constraint user_sessions_ibfk_1
        foreign key (user_id) references Users (UserId)
            on delete cascade
);

create index user_id
    on User_Sessions (user_id);

create table users
(
    UserId        int auto_increment
        primary key,
    FirstName     varchar(100)                       not null,
    LastName      varchar(100)                       not null,
    Email         varchar(100)                       not null,
    Password_Hash varchar(255)                       not null,
    CreatedAt     datetime default CURRENT_TIMESTAMP not null,
    UpdatedAt     datetime default CURRENT_TIMESTAMP not null on update CURRENT_TIMESTAMP,
    constraint Email
        unique (Email)
);


