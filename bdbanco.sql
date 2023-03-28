CREATE DATABASE bdbanco;
USE bdbanco;

SELECT * FROM tblclientes;
SELECT * FROM cuentas;
SELECT * FROM auditoria;

CREATE TABLE tblclientes(
	cedula INT NOT NULL PRIMARY KEY UNIQUE,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(30) NOT NULL,
    telefono INT
);

CREATE TABLE tblretiros(
	idretiro INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    cedula INT NOT NULL,
    fecha_transacccion DATETIME NOT NULL,
    monto INT NOT NULL,
    FOREIGN KEY (cedula) REFERENCES tblclientes(cedula)
);

CREATE TABLE cuentas(
	idcuenta INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    cedula INT NOT NULL UNIQUE,
    tipo_cuenta VARCHAR(8) NOT NULL,
    saldo INT,
    FOREIGN KEY (cedula) REFERENCES tblclientes(cedula)
);

CREATE TABLE auditoria(
	idauditoria INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    id_cuenta INT NOT NULL,
    saldo_transaccion INT,
    saldo_anterior INT,
    nuevo_saldo INT,
    tipo_transaccion VARCHAR(10),
    fecha DATETIME,
    FOREIGN KEY (id_cuenta) REFERENCES cuentas(idcuenta)
);