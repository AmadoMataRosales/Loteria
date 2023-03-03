USE LoteriaDB


IF OBJECT_ID('Carta', 'U') IS NULL

BEGIN

       CREATE TABLE Carta(

             Id INT PRIMARY KEY IDENTITY(1,1)
             , Descripcion VARCHAR(25) NOT NULL
             , Imagen VARCHAR(120) NOT NULL)
END

 

IF OBJECT_ID('Tabla', 'U') IS NULL

BEGIN
       CREATE TABLE Tabla(
             Id INT PRIMARY KEY IDENTITY(1,1)
             , IdUsuario NVARCHAR(450) NOT NULL
             , Activo BIT NOT NULL
             , FechaRegistro DATETIME NOT NULL)

		ALTER TABLE Tabla
		ADD CONSTRAINT KF_Tabla_AspNetUsers
		FOREIGN KEY(IdUsuario)
		REFERENCES AspNetUsers(Id)

END

IF OBJECT_ID('TablaDetalle', 'U') IS NULL

BEGIN
	CREATE TABLE TablaDetalle(
		IdTablaDetalle INT IDENTITY(1,1)
		, IdTabla INT NOT NULL
		, IdCarta INT NOT NULL)

		ALTER TABLE TablaDetalle
		ADD CONSTRAINT KF_TablaDetalle_Tabla
		FOREIGN KEY(IdTabla)
		REFERENCES Tabla(Id)

		ALTER TABLE TablaDetalle
		ADD CONSTRAINT KF_TablaDetalle_Carta
		FOREIGN KEY(IdCarta)
		REFERENCES Tabla(Id)
END