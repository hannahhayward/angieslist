CREATE TABLE jobs(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'created at',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'updated at',
    title varchar(255) comment 'job title',
    body VARCHAR(255) COMMENT 'job body',
    creatorId VARCHAR(255) COMMENT 'creator id'
) default charset utf8 comment '';
CREATE TABLE contractors(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'created at',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'updated at',
    title varchar(255) comment 'job title',
    experience VARCHAR(255) COMMENT 'job experience'
) default charset utf8 comment '';
CREATE TABLE bids(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'created at',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'updated at',
    body varchar(255) comment 'job body',
    creatorId INT COMMENT 'FK: contractor id',
    jobId INT COMMENT 'FK: job id',
    FOREIGN KEY(creatorId) REFERENCES contractors(id) ON DELETE CASCADE,
    FOREIGN KEY(jobId) REFERENCES jobs(id) ON DELETE CASCADE
) default charset utf8 comment '';
