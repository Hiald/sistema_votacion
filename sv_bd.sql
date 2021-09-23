/*
Database: db_a66376_sv
Red: mysql5042.site4now.net
Username: a66376_sv
Pass: @SisVot2021.

accesos admin: 123
tipos usuarios
3: super admin
2: admin
1: usuario
*/
-- call sp_insertar_usuario('cuenta' ,'administrador' ,'administrador' ,1 ,0 ,0 ,0 ,0, ',','','' ,'000000' ,'' ,'' ,'2021-09-11' ,1 ,'2021-09-11' ,'17:45' ,3 ,'admin' ,'123' ,'' ,1 ,'88888888');
/* se guarda caracteristicas generales tales como: genero, tipo de documento, etc */
CREATE TABLE t_maestro (
  `idmaestro` INT NOT NULL AUTO_INCREMENT,
  `v_nombre` VARCHAR(50) NOT NULL,
  `v_descripcion` VARCHAR(50) NOT NULL,
  `b_estado` BIT(1) NOT NULL,
  `dt_fecharegistro` DATETIME NULL,
  PRIMARY KEY (`idmaestro`)
);

/* detalle de la tabla maestro tales como: femenino, masculino, etc */
CREATE TABLE t_maestro_parametro (
  `idparametro` INT NOT NULL,
  `idmaestro` INT NOT NULL,
  `v_nombre` VARCHAR(50) NOT NULL,
  `v_descripcion` VARCHAR(200) DEFAULT NULL,
  `b_estado` BIT(1) NOT NULL,
  `dt_fecharegistro` DATETIME NULL,
  FOREIGN KEY (`idmaestro`) REFERENCES t_maestro(`idmaestro`),
  PRIMARY KEY (`idparametro`)
);


-- informacion del usuario o administrador
CREATE TABLE IF NOT EXISTS t_usuario(
  `idusuario` INT NOT NULL AUTO_INCREMENT,
  `idpais` INT DEFAULT NULL,
  `idregion` INT DEFAULT NULL,
  `idprovincia` INT DEFAULT NULL,
  `idciudad` INT DEFAULT NULL,
  `iddistrito` INT DEFAULT NULL,
  `v_departamentos` VARCHAR(250) DEFAULT NULL,
  `v_provincia` VARCHAR(1000) DEFAULT NULL,
  `v_distritos` VARCHAR(2500) DEFAULT NULL,
  `v_ubigeo` VARCHAR(10) NULL,
  `v_nombres` VARCHAR(100) NOT NULL,
  `v_apellidos` VARCHAR(100) DEFAULT NULL,
  `v_nombre_usuario` VARCHAR(100) NOT NULL,
  `v_direccion` VARCHAR(150) DEFAULT NULL,
  `v_direccion2` VARCHAR(150) DEFAULT NULL,
  `i_genero` INT DEFAULT NULL,
  `i_tipo_documento` INT DEFAULT NULL,
  `v_documento` VARCHAR(25) DEFAULT NULL,
  `v_correo2` VARCHAR(150) DEFAULT NULL,
  `v_facebook` VARCHAR(250) DEFAULT NULL,
  `v_instagram` VARCHAR(250) DEFAULT NULL,
  `v_twitter` VARCHAR(250) DEFAULT NULL,
  `v_imagenperfil` VARCHAR(250) DEFAULT NULL,
  `v_imagenportada` VARCHAR(250) DEFAULT NULL,
  `v_imagen1_ruta` VARCHAR(250) DEFAULT NULL,
  `v_imagen2_ruta` VARCHAR(250) DEFAULT NULL,
  `v_celular1` VARCHAR(15) DEFAULT NULL,
  `v_fechanacimiento` DATE DEFAULT NULL,
  `b_estado` BIT(1) NOT NULL,
  `dt_fecharegistro` DATE NOT NULL,
  `v_horaregistro` VARCHAR(25) NOT NULL,
  `v_fechamodificacion` DATE NULL,
  `v_horamodificacion` VARCHAR(25) NULL,
  `i_usuario_mod` INT NULL,
  PRIMARY KEY (`idusuario`)
);


-- informacion de los accesos, correo,clave del usuario final y administrador
CREATE TABLE t_acceso (
  `idacceso` INT NOT NULL AUTO_INCREMENT,
  `idusuario` INT NOT NULL,
  `i_tipo_usuario` INT NOT NULL, -- admin, superadmin, usuario final, etc
  `v_correo` VARCHAR(100) NOT NULL,
  `v_clave` VARCHAR(500) NOT NULL,
  `v_token` VARCHAR(500) DEFAULT NULL,
  `b_estado` BIT(1) NOT NULL,
  `dt_fecharegistro` DATE NOT NULL,
  `v_horaregistro` VARCHAR(25) NOT NULL,
  `v_fechamodificacion` DATE NULL,
  `v_horamodificacion` VARCHAR(25) NULL,
  FOREIGN KEY (`idusuario`) REFERENCES t_usuario(`idusuario`),
  PRIMARY KEY (`idacceso`)
);


-- información con las preguntas, tiempos, tipo de preguntas y si estara restringido 
-- a todo el peru, regional, etc
------------------------------------------------------------------------------------
-- por defecto se debe crear: voto a favor, voto en contra, abstencion, etc
-- el campo: i_varias_opciones tendra el control de ver si la persona debe marcar
-- 1, 2 o  solo escribir una respuesta a la pregunta hecha
CREATE TABLE t_votacion (
  `idvotacion` INT NOT NULL AUTO_INCREMENT,
  `idusuario` INT NOT NULL,
  `idpais` INT DEFAULT NULL,
  `idregion` VARCHAR(50) DEFAULT NULL,
  `idprovincia` VARCHAR(250) DEFAULT NULL,
  `idciudad` VARCHAR(1000) DEFAULT NULL,
  `iddistrito` VARCHAR(2500) DEFAULT NULL,
  `v_ubigeo` VARCHAR(10) NULL,
  `v_nombre` VARCHAR(150) NULL,
  `v_descripcion` VARCHAR(500) NULL,
  `i_tipovotacion` INT NULL, -- si es nacional, distrital, regional, etc
  `i_tipotiempo` INT NULL, -- si es tiempo por dias , horas, minutos, etc
  `i_tiempo` INT NULL, -- la cantidad de tiempo
  `dt_fecha_ini` DATE NULL,
  `dt_hora_ini` VARCHAR(25) NULL,
  `dt_fecha_fin` DATE NULL,
  `dt_hora_fin` VARCHAR(25) NULL,
  `b_tiempo_fecha_hora` INT NULL, -- si es que hay tiempos con fecha y hora
  `dt_tiempo_fecha` VARCHAR(25) NULL, -- si es hasta una fecha determinada
  `dt_tiempo_hora` VARCHAR(25) NULL, -- si es hasta una hora determinada
  `b_respuesta` INT NULL, -- si la pregunta es una respuesta, o sin respuesta u opcional, etc
  `v_respuesta` VARCHAR(500) NULL, -- enlazado con el campo de arriba
  `i_varias_opciones` INT NULL, -- 1 si solo una opcion, 2 si multiples , etc
  `i_cantidad_opciones` INT NULL, -- si la pregunta es de preguntas multiple, es la cantidad de respuestas minimas a marcar
  `i_votacion_cantidad` INT NULL, -- cuantas opciones se esta habilitando: 3 preguntas, 2: (solo en caso de preguntas multiples)
  `i_pregunta_1` INT NULL, -- si es 1 es porque esta habilitado, este campo por lo general siempre lo estara
  `v_pregunta_1` VARCHAR(250) NULL, -- el texto de la pregunta
  `i_pregunta_2` INT NULL, -- si es 1 es porque esta habilitado, si es 0 es porque no lo esta
  `v_pregunta_2` VARCHAR(250) NULL,
  `i_pregunta_3` INT NULL,
  `v_pregunta_3` VARCHAR(250) NULL,
  `i_pregunta_4` INT NULL,
  `v_pregunta_4` VARCHAR(250) NULL,
  `i_pregunta_5` INT NULL,
  `v_pregunta_5` VARCHAR(250) NULL,
  `i_pregunta_6` INT NULL,
  `v_pregunta_6` VARCHAR(250) NULL,
  `i_pregunta_7` INT NULL,
  `v_pregunta_7` VARCHAR(250) NULL,
  `i_pregunta_8` INT NULL,
  `v_pregunta_8` VARCHAR(250) NULL,
  `i_pregunta_9` INT NULL,
  `v_pregunta_9` VARCHAR(250) NULL,
  `i_pregunta_10` INT NULL,
  `v_pregunta_10` VARCHAR(250) NULL,
  `v_observacion` VARCHAR(500) NULL, -- (opcional)
  `b_estado` BIT(1) NOT NULL,
  `dt_fecharegistro` DATE NOT NULL,
  `v_horaregistro` VARCHAR(25) NOT NULL,
  `v_fechamodificacion` DATE NULL,
  `v_horamodificacion` VARCHAR(25) NULL,
  FOREIGN KEY (`idusuario`) REFERENCES t_usuario(`idusuario`),
  PRIMARY KEY (`idvotacion`)
);

-- se almacenaran las respuestas de los usuarios
CREATE TABLE t_votacion_usuario (
  `idvotacion_usuario` INT NOT NULL AUTO_INCREMENT,
  `idvotacion` INT NOT NULL,
  `idusuario` INT NOT NULL,
  `v_respuesta` VARCHAR(500) NULL, -- enlazado con el campo de arriba
  `i_cantidad_opciones` INT NULL, -- cuantas opciones ha marcado (en caso de ser multiple)
  `i_pregunta_1` INT NULL,  
  `i_pregunta_2` INT NULL,
  `i_pregunta_3` INT NULL,
  `i_pregunta_4` INT NULL,
  `i_pregunta_5` INT NULL,
  `i_pregunta_6` INT NULL,
  `i_pregunta_7` INT NULL,
  `i_pregunta_8` INT NULL,
  `i_pregunta_9` INT NULL,
  `i_pregunta_10` INT NULL,
  `v_observacion` VARCHAR(500) NULL, -- (opcional)
  `b_estado` BIT(1) NOT NULL,
  `dt_fecharegistro` DATE NOT NULL,
  `v_horaregistro` VARCHAR(25) NOT NULL,
  `v_fechamodificacion` DATE NULL,
  `v_horamodificacion` VARCHAR(25) NULL,
  FOREIGN KEY (`idusuario`) REFERENCES t_usuario(`idusuario`),
  FOREIGN KEY (`idvotacion`) REFERENCES t_votacion(`idvotacion`),
  PRIMARY KEY (`idvotacion_usuario`)
);

-- -----------------------------------------------------------

-- obtiene info de la sesion usuario, logeo
-- parametros: usuario y clave
-- retorno: 0 es porque es error de logeo 1 es correcto
DROP procedure IF EXISTS `sp_obtener_usuario`;
DELIMITER $$
CREATE PROCEDURE `sp_obtener_usuario`(IN _usuario VARCHAR(100),IN _clave VARCHAR(500) )
BEGIN

  IF EXISTS(SELECT idusuario FROM T_ACCESO WHERE v_correo = _usuario AND v_clave = _clave) THEN
  BEGIN
    
  SELECT 
         u.idusuario
        ,u.v_nombres
        ,u.v_apellidos
        ,u.v_nombre_usuario
        ,u.i_genero
        ,u.idpais
        ,u.idregion
        ,u.idprovincia
        ,u.idciudad
        ,u.iddistrito
        ,u.v_departamentos
        ,u.v_provincia
        ,u.v_distritos
        ,u.v_ubigeo
        ,a.v_correo
        ,a.i_tipo_usuario
        ,u.i_tipo_documento
        ,u.v_documento
        ,1 as '_resultado'
  FROM t_usuario u
    LEFT JOIN t_acceso a ON a.idusuario = u.idusuario
    WHERE u.idusuario = (SELECT idusuario FROM t_acceso WHERE v_correo = _usuario AND v_clave = _clave)
      AND u.b_estado = 1;

    END;
    ELSE 
    BEGIN

    SELECT 
          0 as 'idusuario'
        ,'' as 'v_nombres'
        ,'' as 'v_apellidos'
        ,'' as 'v_nombre_usuario'
        ,0 as 'i_genero'
        ,0 as 'idpais'
        ,0 as 'idregion'
        ,0 as 'idprovincia'
        ,0 as 'idciudad'
        ,0 as 'iddistrito'
        ,'' as 'v_departamentos'
        ,'' as 'v_provincia'
        ,'' as 'v_distritos'
        ,'' as 'v_ubigeo'
        ,'' as 'v_correo'
        ,0 as 'i_tipo_usuario'
        ,0 as 'i_tipo_documento'
        ,'' as 'v_documento'
        ,0 as '_resultado';
    END;
    END IF;

END$$
DELIMITER ;

-- --------------------------------------------------------------------------

-- registra al usuario y su acceso
-- parametros: datos de usuario
-- retorno: 0 es porque ya existe | caso contrario retorna ID GENERADO
/*DROP procedure IF EXISTS `sp_insertar_usuario`;*/
DELIMITER $$
CREATE PROCEDURE `sp_insertar_usuario`
  (IN _v_nombres VARCHAR(100)
  ,IN _v_apellidos VARCHAR(100)
  ,IN _v_nombre_usuario VARCHAR(100)
  ,IN _i_genero INT
  ,IN _idregion INT
  ,IN _idprovincia INT
  ,IN _idciudad INT
  ,IN _iddistrito INT
  ,IN _v_departamentos VARCHAR(250)
  ,IN _v_provincia VARCHAR(1000)
  ,IN _v_distritos VARCHAR(2500)
  ,IN _v_ubigeo VARCHAR(10)
  ,IN _v_imagenperfil VARCHAR(250)
  ,IN _v_imagenportada VARCHAR(250)
  ,IN _v_fechanacimiento VARCHAR(25)
  ,IN _b_estado BIT(1)
  ,IN _dt_fecharegistro VARCHAR(25)
  ,IN _v_horaregistro VARCHAR(25)
  ,IN _i_tipo_usuario INT
  ,IN _v_correo VARCHAR(100)
  ,IN _v_clave VARCHAR(500)
  ,IN _v_token VARCHAR(500)
  ,IN _i_tipo_documento INT
  ,IN _v_documento VARCHAR(25))
BEGIN

IF EXISTS(SELECT idusuario FROM t_acceso WHERE v_correo = _v_correo) THEN
BEGIN
  SELECT 0 as '_resultado';
END;
ELSE
BEGIN
    INSERT INTO t_usuario(
       v_nombres
      ,v_apellidos
      ,v_nombre_usuario
      ,i_genero
      ,idregion
      ,idprovincia
      ,idciudad
      ,iddistrito
      ,v_departamentos
      ,v_provincia
      ,v_distritos
      ,v_ubigeo
      ,v_imagenperfil
      ,v_imagenportada
      ,v_fechanacimiento
      ,i_tipo_documento
      ,v_documento
      ,b_estado
      ,dt_fecharegistro
      ,v_horaregistro)
    VALUES (
       _v_nombres
      ,_v_apellidos
      ,_v_nombre_usuario
      ,_i_genero
      ,_idregion
      ,_idprovincia
      ,_idciudad
      ,_iddistrito
      ,_v_departamentos
      ,_v_provincia
      ,_v_distritos
      ,_v_ubigeo
      ,_v_imagenperfil
      ,_v_imagenportada
      ,STR_TO_DATE(_v_fechanacimiento, '%Y-%m-%d')
      ,_i_tipo_documento
      ,_v_documento
      ,1
      ,STR_TO_DATE(_dt_fecharegistro, '%Y-%m-%d')
      ,_v_horaregistro);

    INSERT INTO t_acceso(
       idusuario
      ,i_tipo_usuario
      ,v_correo
      ,v_clave
      ,v_token
      ,b_estado
      ,dt_fecharegistro
      ,v_horaregistro)
  VALUES (
       LAST_INSERT_ID()
      ,_i_tipo_usuario
      ,_v_correo
      ,_v_clave
      ,_v_token
      ,1
      ,STR_TO_DATE(_dt_fecharegistro, '%Y-%m-%d')
      ,_v_horaregistro);
        
    SELECT LAST_INSERT_ID() as '_resultado';
END;
END IF;

END$$
DELIMITER ;

-- --------------------------------------------------------------------------

-- actualiza el correo y clave o desactiva el usuario (0 activo)
-- PD: para cerrar cuenta desde usuario o admin
-- parametros: tipo de act, id usuario, correo y clave
-- retorno: no aplica
/*DROP procedure IF EXISTS `sp_actualizar_acceso`;*/
DELIMITER $$
CREATE PROCEDURE `sp_actualizar_acceso`(
   IN _tipoactualizar INT
  ,IN _idusuario INT
  ,IN _v_correo VARCHAR(100)
  ,IN _v_clave VARCHAR(500))
BEGIN

  IF (_tipoactualizar = 1) THEN
  BEGIN
    
    UPDATE t_acceso
      SET  
      v_correo = _v_correo,
      v_clave = _v_clave
    WHERE idusuario = _idusuario;

  END;
  ELSE 
    
    UPDATE t_acceso
      SET b_estado = 0 
    WHERE idusuario = _idusuario;

    BEGIN
    END;
    END IF;

END$$
DELIMITER ;

-- --------------------------------------------------------------------------

-- actualiza solo la nueva clave del usuario
-- parametros: id usuario, nueva clave
-- retorno: no aplica
/*DROP procedure IF EXISTS `sp_actualizar_clave`;*/
DELIMITER $$
CREATE PROCEDURE `sp_actualizar_clave` (IN _idusuario INT, IN _nuevaclave VARCHAR(500))
BEGIN

UPDATE t_acceso SET v_clave = _nuevaclave WHERE idusuario = _idusuario;

END$$
DELIMITER ;

-- --------------------------------------------------------------------------

-- actualiza toda la info del usuario
-- parametros: datos del usuario
-- retorno: el id del usuario
/*DROP procedure IF EXISTS `sp_actualizar_usuario`;*/
DELIMITER $$
CREATE PROCEDURE `sp_actualizar_usuario`( 
   IN _idusuario INT
  ,IN _idpais INT
  ,IN _idprovincia INT
  ,IN _idciudad INT
  ,IN _iddistrito INT
  ,IN _v_departamentos VARCHAR(250)
  ,IN _v_provincia VARCHAR(1000)
  ,IN _v_distritos VARCHAR(2500)
  ,IN _v_ubigeo VARCHAR(10)
  ,IN _v_nombres VARCHAR(100)
  ,IN _v_apellidos VARCHAR(100)
  ,IN _v_nombre_usuario VARCHAR(100)
  ,IN _v_direccion VARCHAR(150)
  ,IN _v_direccion2 VARCHAR(150)
  ,IN _i_genero INT
  ,IN _v_correo2 VARCHAR(150)
  ,IN _v_facebook VARCHAR(250)
  ,IN _v_instagram VARCHAR(250)
  ,IN _v_twitter VARCHAR(250)
  ,IN _v_imagenperfil VARCHAR(250)
  ,IN _v_imagenportada VARCHAR(250)
  ,IN _v_celular1 VARCHAR(15)
  ,IN _v_fechanacimiento VARCHAR(25)
  ,IN _v_fechamodificacion VARCHAR(25)
  ,IN _v_horamodificacion VARCHAR(25)
  ,IN _idusuario_mod INT
  ,IN _b_estado BIT
  ,IN _i_tipo_documento INT
  ,IN _v_documento VARCHAR(25))
BEGIN
    UPDATE t_usuario
    SET
      idpais = _idpais,
      idprovincia = _idprovincia,
      idciudad = _idciudad,
      iddistrito = _iddistrito,
      v_departamentos = _v_departamentos,
      v_provincia = _v_provincia,
      v_distritos = _v_distritos,
      v_ubigeo = _v_ubigeo,
      v_nombres = _v_nombres,
      v_apellidos = _v_apellidos,
      v_nombre_usuario = _v_nombre_usuario,
      v_direccion = _v_direccion,
      v_direccion2 = _v_direccion,
      i_genero = _i_genero,
      v_correo2 = _v_correo2,
      v_facebook = _v_facebook,
      v_instagram = _v_instagram,
      v_twitter = _v_twitter,
      v_imagenperfil = _v_imagenperfil,
      v_imagenportada = _v_imagenportada,
      v_celular1 = _v_celular1,
      v_fechanacimiento = STR_TO_DATE(_v_fechanacimiento, '%Y-%m-%d'),
      v_fechamodificacion = STR_TO_DATE(_v_fechamodificacion, '%Y-%m-%d'),
      v_horamodificacion = _v_horamodificacion,
      i_usuario_mod = _idusuario_mod,
      b_estado = _b_estado,
      i_tipo_documento = _i_tipo_documento,
      v_documento = _v_documento
    WHERE idusuario = _idusuario;   
    SELECT _idusuario as '_resultado';      

END$$
DELIMITER ;

-- --------------------------------------------------------------------------

-- lista toda la info de un solo usuario
-- parametros: id usuario
-- retorno: listado de t_usuario
DROP procedure IF EXISTS `sp_filtrar_usuario`;
DELIMITER $$
CREATE PROCEDURE `sp_filtrar_usuario`(IN _idusuario INT, IN _bestado BIT(1), 
  IN _tipousuario INT)
BEGIN

  SELECT 
     u.idusuario
    ,u.idpais
    ,u.idprovincia
    ,u.idciudad
    ,u.iddistrito
    ,u.v_departamentos
    ,u.v_provincia
    ,u.v_distritos
    ,u.v_ubigeo
    ,u.v_nombres
    ,u.v_apellidos
    ,u.v_nombre_usuario
    ,u.v_direccion
    ,u.v_direccion2
    ,u.i_genero
    ,u.v_correo2
    ,u.v_facebook
    ,u.v_instagram
    ,u.v_twitter
    ,u.v_imagenperfil
    ,u.v_imagenportada
    ,u.v_celular1
    ,DATE_FORMAT(u.v_fechanacimiento, '%d-%m-%Y') as 'v_fechanacimiento'
    ,a.v_correo
  FROM t_usuario u
  LEFT JOIN t_acceso a ON u.idusuario = a.idusuario
    WHERE ((u.idusuario = _idusuario) OR (_idusuario = 0)) 
    AND u.b_estado = _bestado
    AND ((a.i_tipo_usuario =_tipousuario) OR (_tipousuario = 0));

END$$
DELIMITER ;

-- --------------------------------------------------------------------------

-- lista toda la lista de sub maestro
-- parametros: id maestro
-- retorno: listado de t_maestro_parametro
/*DROP procedure IF EXISTS `sp_listar_maestro`;*/
DELIMITER $$
CREATE PROCEDURE `sp_listar_maestro` (IN _idmaestro INT)
BEGIN

SELECT
   sm.idparametro
  ,sm.idmaestro
  ,sm.v_nombre
  ,sm.v_descripcion
  ,sm.b_estado
  ,DATE_FORMAT(sm.dt_fecharegistro, '%d-%m-%Y') as 'dt_fecharegistro'
FROM t_maestro as m 
  INNER JOIN t_maestro_parametro as sm WHERE m.idmaestro = sm.idmaestro
    AND sm.b_estado = 1 
    AND m.b_estado = 1 
    AND m.idmaestro = _idmaestro;

END$$
DELIMITER ;

-- --------------------------------------------------------------------------

-- _tipoactualizar: 1 actualizar , 2 insertar
/*DROP procedure IF EXISTS `sp_operacion_votacion`;*/
DELIMITER $$
CREATE PROCEDURE `sp_operacion_votacion`(
   IN _tipoactualizar INT
  ,IN _idvotacion INT
  ,IN _idusuario INT
  ,IN _idpais INT
  ,IN _idregion VARCHAR(50)
  ,IN _idprovincia VARCHAR(250)
  ,IN _idciudad VARCHAR(1000)
  ,IN _iddistrito VARCHAR(2500)
  ,IN _v_ubigeo VARCHAR(10)
  ,IN _v_nombre VARCHAR(150)
  ,IN _v_descripcion VARCHAR(500)
  ,IN _i_tipovotacion INT
  ,IN _i_tipotiempo INT
  ,IN _i_tiempo INT
  ,IN _b_tiempo_fecha_hora INT
  ,IN _dt_tiempo_fecha VARCHAR(25)
  ,IN _dt_tiempo_hora VARCHAR(25)
  ,IN _b_respuesta INT
  ,IN _v_respuesta VARCHAR(500)
  ,IN _i_varias_opciones INT
  ,IN _i_cantidad_opciones INT
  ,IN _i_votacion_cantidad INT
  ,IN _i_pregunta_1 INT
  ,IN _v_pregunta_1 VARCHAR(250)
  ,IN _i_pregunta_2 INT
  ,IN _v_pregunta_2 VARCHAR(250)
  ,IN _i_pregunta_3 INT
  ,IN _v_pregunta_3 VARCHAR(250)
  ,IN _i_pregunta_4 INT
  ,IN _v_pregunta_4 VARCHAR(250)
  ,IN _i_pregunta_5 INT
  ,IN _v_pregunta_5 VARCHAR(250)
  ,IN _i_pregunta_6 INT
  ,IN _v_pregunta_6 VARCHAR(250)
  ,IN _i_pregunta_7 INT
  ,IN _v_pregunta_7 VARCHAR(250)
  ,IN _i_pregunta_8 INT
  ,IN _v_pregunta_8 VARCHAR(250)
  ,IN _i_pregunta_9 INT
  ,IN _v_pregunta_9 VARCHAR(250)
  ,IN _i_pregunta_10 INT
  ,IN _v_pregunta_10 VARCHAR(250)
  ,IN _v_observacion VARCHAR(500)
  ,IN _b_estado BIT(1)
  ,IN _dt_fecharegistro VARCHAR(25)
  ,IN _v_horaregistro VARCHAR(25)
  ,IN _v_fechamodificacion VARCHAR(25)
  ,IN _v_horamodificacion VARCHAR(25)
  ,IN _dt_fecha_ini VARCHAR(25)
  ,IN _dt_hora_ini VARCHAR(25)
  ,IN _dt_fecha_fin VARCHAR(25)
  ,IN _dt_hora_fin VARCHAR(25))
BEGIN

  IF (_tipoactualizar = 1) THEN
  BEGIN
    
    UPDATE t_votacion
      SET  
       idpais = _idpais
      ,idregion = _idregion
      ,idprovincia = _idprovincia
      ,idciudad = _idciudad
      ,iddistrito = _iddistrito
      ,v_ubigeo = _v_ubigeo
      ,v_nombre = _v_nombre
      ,v_descripcion = _v_descripcion
      ,i_tipovotacion = _i_tipovotacion
      ,i_tipotiempo = _i_tipotiempo
      ,i_tiempo = _i_tiempo
      ,b_tiempo_fecha_hora = _b_tiempo_fecha_hora
      ,dt_tiempo_fecha = _dt_tiempo_fecha
      ,dt_tiempo_hora = _dt_tiempo_hora
      ,b_respuesta = _b_respuesta
      ,v_respuesta = _v_respuesta
      ,i_varias_opciones = _i_varias_opciones
      ,i_cantidad_opciones = _i_cantidad_opciones
      ,i_votacion_cantidad = _i_votacion_cantidad
      ,i_pregunta_1 = _i_pregunta_1
      ,v_pregunta_1 = _v_pregunta_1
      ,i_pregunta_2 = _i_pregunta_2
      ,v_pregunta_2 = _v_pregunta_2
      ,i_pregunta_3 = _i_pregunta_3
      ,v_pregunta_3 = _v_pregunta_3
      ,i_pregunta_4 = _i_pregunta_4
      ,v_pregunta_4 = _v_pregunta_4
      ,i_pregunta_5 = _i_pregunta_5
      ,v_pregunta_5 = _v_pregunta_5
      ,i_pregunta_6 = _i_pregunta_6
      ,v_pregunta_6 = _v_pregunta_6
      ,i_pregunta_7 = _i_pregunta_7
      ,v_pregunta_7 = _v_pregunta_7
      ,i_pregunta_8 = _i_pregunta_8
      ,v_pregunta_8 = _v_pregunta_8
      ,i_pregunta_9 = _i_pregunta_9
      ,v_pregunta_9 = _v_pregunta_9
      ,i_pregunta_10 = _i_pregunta_10
      ,v_pregunta_10 = _v_pregunta_10
      ,v_observacion = _v_observacion
      ,b_estado = _b_estado
      ,v_fechamodificacion = STR_TO_DATE(_v_fechamodificacion, '%Y-%m-%d')
      ,v_horamodificacion = _v_horamodificacion
      ,dt_fecha_ini = _dt_fecha_ini
      ,dt_hora_ini = _dt_hora_ini
      ,dt_fecha_fin = _dt_fecha_fin
      ,dt_hora_fin = _dt_hora_fin
    WHERE idvotacion = _idvotacion;

  END;
  ELSE 
  BEGIN

    INSERT INTO t_votacion
      (
       idusuario
      ,idpais
      ,idregion
      ,idprovincia
      ,idciudad
      ,iddistrito
      ,v_ubigeo
      ,v_nombre
      ,v_descripcion
      ,i_tipovotacion
      ,i_tipotiempo
      ,i_tiempo
      ,b_tiempo_fecha_hora
      ,dt_tiempo_fecha
      ,dt_tiempo_hora
      ,b_respuesta
      ,v_respuesta
      ,i_varias_opciones
      ,i_cantidad_opciones
      ,i_votacion_cantidad
      ,i_pregunta_1
      ,v_pregunta_1
      ,i_pregunta_2
      ,v_pregunta_2
      ,i_pregunta_3
      ,v_pregunta_3
      ,i_pregunta_4
      ,v_pregunta_4
      ,i_pregunta_5
      ,v_pregunta_5
      ,i_pregunta_6
      ,v_pregunta_6
      ,i_pregunta_7
      ,v_pregunta_7
      ,i_pregunta_8
      ,v_pregunta_8
      ,i_pregunta_9
      ,v_pregunta_9
      ,i_pregunta_10
      ,v_pregunta_10
      ,v_observacion
      ,b_estado
      ,dt_fecharegistro
      ,v_horaregistro
      ,dt_fecha_ini
      ,dt_hora_ini
      ,dt_fecha_fin
      ,dt_hora_fin)
    VALUES (
       _idusuario
      ,_idpais
      ,_idregion
      ,_idprovincia
      ,_idciudad
      ,_iddistrito
      ,_v_ubigeo
      ,_v_nombre
      ,_v_descripcion
      ,_i_tipovotacion
      ,_i_tipotiempo
      ,_i_tiempo
      ,_b_tiempo_fecha_hora
      ,_dt_tiempo_fecha
      ,_dt_tiempo_hora
      ,_b_respuesta
      ,_v_respuesta
      ,_i_varias_opciones
      ,_i_cantidad_opciones
      ,_i_votacion_cantidad
      ,_i_pregunta_1
      ,_v_pregunta_1
      ,_i_pregunta_2
      ,_v_pregunta_2
      ,_i_pregunta_3
      ,_v_pregunta_3
      ,_i_pregunta_4
      ,_v_pregunta_4
      ,_i_pregunta_5
      ,_v_pregunta_5
      ,_i_pregunta_6
      ,_v_pregunta_6
      ,_i_pregunta_7
      ,_v_pregunta_7
      ,_i_pregunta_8
      ,_v_pregunta_8
      ,_i_pregunta_9
      ,_v_pregunta_9
      ,_i_pregunta_10
      ,_v_pregunta_10
      ,_v_observacion
      ,_b_estado
      ,STR_TO_DATE(_dt_fecharegistro, '%Y-%m-%d')
      ,_v_horaregistro
      ,_dt_fecha_ini
      ,_dt_hora_ini
      ,_dt_fecha_fin
      ,_dt_hora_fin);
    
    END;
    END IF;

END$$
DELIMITER ;

-- --------------------------------------------------------------------------

DROP procedure IF EXISTS `sp_listar_votacion`;
DELIMITER $$
CREATE PROCEDURE `sp_listar_votacion`(
   IN _idusuario INT
  ,IN _idvotacion INT
  ,IN _idpais INT
  ,IN _idregion VARCHAR(50)
  ,IN _idprovincia VARCHAR(1000)
  ,IN _idciudad VARCHAR(1000)
  ,IN _iddistrito VARCHAR(2500)
  ,IN _v_ubigeo VARCHAR(10)
  ,IN _fechainicial VARCHAR(25)
  ,IN _fechafinal VARCHAR(25)
  ,IN _tipolistado INT)
BEGIN

  IF (_tipolistado = 1) THEN
  
  SELECT 
     u.v_nombres
    ,u.v_apellidos
    ,u.v_nombre_usuario
    ,v.idvotacion
    ,v.idusuario
    ,v.idpais
    ,v.idregion
    ,v.idprovincia
    ,v.idciudad
    ,v.iddistrito
    ,v.v_ubigeo
    ,v.v_nombre
    ,v.v_descripcion
    ,v.i_tipovotacion
    ,v.i_tipotiempo
    ,v.i_tiempo
    ,v.b_tiempo_fecha_hora
    ,v.dt_tiempo_fecha
    ,v.dt_tiempo_hora
    ,v.b_respuesta
    ,v.v_respuesta
    ,v.i_varias_opciones
    ,v.i_cantidad_opciones
    ,v.i_votacion_cantidad
    ,v.i_pregunta_1
    ,v.v_pregunta_1
    ,v.i_pregunta_2
    ,v.v_pregunta_2
    ,v.i_pregunta_3
    ,v.v_pregunta_3
    ,v.i_pregunta_4
    ,v.v_pregunta_4
    ,v.i_pregunta_5
    ,v.v_pregunta_5
    ,v.i_pregunta_6
    ,v.v_pregunta_6
    ,v.i_pregunta_7
    ,v.v_pregunta_7
    ,v.i_pregunta_8
    ,v.v_pregunta_8
    ,v.i_pregunta_9
    ,v.v_pregunta_9
    ,v.i_pregunta_10
    ,v.v_pregunta_10
    ,v.v_observacion
    ,(SELECT COUNT(*) FROM t_votacion_usuario vu WHERE vu.idvotacion = v.idvotacion AND vu.idusuario = _idpais) as 'b_estado'
    ,DATE_FORMAT(v.dt_fecharegistro, '%d-%m-%Y') as 'dt_fecharegistro'
    ,v.v_horaregistro
    ,DATE_FORMAT(v.dt_fecha_ini, '%d-%m-%Y') as 'dt_fecha_ini'
    ,v.dt_hora_ini
    ,DATE_FORMAT(v.dt_fecha_fin, '%d-%m-%Y') as 'dt_fecha_fin'
    ,v.dt_hora_fin
  FROM t_votacion v LEFT JOIN t_usuario u ON v.idusuario = u.idusuario
    WHERE 
     ((v.idusuario = _idusuario) OR (_idusuario = 0)) AND
        (
          (_fechainicial = 'vacio' AND _fechafinal = 'vacio')
        OR
          (
            DATE_FORMAT(v.dt_fecha_ini,'%Y-%m-%d') <= STR_TO_DATE(_fechainicial,'%Y-%m-%d')
          AND
            DATE_FORMAT(v.dt_fecha_fin,'%Y-%m-%d') >= STR_TO_DATE(_fechafinal,'%Y-%m-%d')
          )
        )
     AND ((_idregion = 'all') OR (v.idregion LIKE CONCAT('%', _idregion , '%')))
     AND ((_idprovincia = 'all') OR (v.idprovincia LIKE CONCAT('%', _idprovincia , '%')))
     AND ((_idciudad = 'all') OR (v.idciudad LIKE CONCAT('%', _idciudad , '%')))
     AND ((_iddistrito = "all") OR (v.iddistrito LIKE CONCAT('%', _iddistrito , '%')))
     AND ((v.idvotacion = _idvotacion) OR (_idvotacion = 0))
     AND v.b_estado = 1 ORDER BY DATE_FORMAT(v.dt_fecha_fin, '%d-%m-%Y') DESC;

  ELSEIF (_tipolistado = 2) THEN

     SELECT 
     u.v_nombres
    ,u.v_apellidos
    ,u.v_nombre_usuario
    ,v.idvotacion
    ,v.idusuario
    ,v.idpais
    ,v.idregion
    ,v.idprovincia
    ,v.idciudad
    ,v.iddistrito
    ,v.v_ubigeo
    ,v.v_nombre
    ,v.v_descripcion
    ,v.i_tipovotacion
    ,v.i_tipotiempo
    ,v.i_tiempo
    ,v.b_tiempo_fecha_hora
    ,v.dt_tiempo_fecha
    ,v.dt_tiempo_hora
    ,v.b_respuesta
    ,v.v_respuesta
    ,v.i_varias_opciones
    ,v.i_cantidad_opciones
    ,v.i_votacion_cantidad
    ,v.i_pregunta_1
    ,v.v_pregunta_1
    ,v.i_pregunta_2
    ,v.v_pregunta_2
    ,v.i_pregunta_3
    ,v.v_pregunta_3
    ,v.i_pregunta_4
    ,v.v_pregunta_4
    ,v.i_pregunta_5
    ,v.v_pregunta_5
    ,v.i_pregunta_6
    ,v.v_pregunta_6
    ,v.i_pregunta_7
    ,v.v_pregunta_7
    ,v.i_pregunta_8
    ,v.v_pregunta_8
    ,v.i_pregunta_9
    ,v.v_pregunta_9
    ,v.i_pregunta_10
    ,v.v_pregunta_10
    ,v.v_observacion
    ,(SELECT COUNT(*) FROM t_votacion_usuario vu WHERE vu.idvotacion = v.idvotacion AND vu.idusuario = _idpais) as 'b_estado'
    ,DATE_FORMAT(v.dt_fecharegistro, '%d-%m-%Y') as 'dt_fecharegistro'
    ,v.v_horaregistro
    ,DATE_FORMAT(v.dt_fecha_ini, '%d-%m-%Y') as 'dt_fecha_ini'
    ,v.dt_hora_ini
    ,DATE_FORMAT(v.dt_fecha_fin, '%d-%m-%Y') as 'dt_fecha_fin'
    ,v.dt_hora_fin
  FROM t_votacion v LEFT JOIN t_usuario u ON v.idusuario = u.idusuario
    WHERE ((v.idusuario = _idusuario) OR (_idusuario = 0))
     AND(
          (_fechainicial = 'vacio' AND _fechafinal = 'vacio')
        OR
          (
            DATE_FORMAT(v.dt_fecha_ini,'%Y-%m-%d') > STR_TO_DATE(_fechainicial,'%Y-%m-%d')
          AND
            DATE_FORMAT(v.dt_fecha_fin,'%Y-%m-%d') > STR_TO_DATE(_fechafinal,'%Y-%m-%d')
          )
        )
     AND ((_idregion = 'all') OR (v.idregion LIKE CONCAT('%', _idregion , '%')))
     AND ((_idprovincia = 'all') OR (v.idprovincia LIKE CONCAT('%', _idprovincia , '%')))
     AND ((_idciudad = 'all') OR (v.idciudad LIKE CONCAT('%', _idciudad , '%')))
     AND ((_iddistrito = "all") OR (v.iddistrito LIKE CONCAT('%', _iddistrito , '%')))
     AND ((v.idvotacion = _idvotacion) OR (_idvotacion = 0))
     AND v.b_estado = 1 ORDER BY DATE_FORMAT(v.dt_fecha_fin, '%d-%m-%Y') DESC;

  ELSEIF (_tipolistado = 3) THEN

     SELECT 
     u.v_nombres
    ,u.v_apellidos
    ,u.v_nombre_usuario
    ,v.idvotacion
    ,v.idusuario
    ,v.idpais
    ,v.idregion
    ,v.idprovincia
    ,v.idciudad
    ,v.iddistrito
    ,v.v_ubigeo
    ,v.v_nombre
    ,v.v_descripcion
    ,v.i_tipovotacion
    ,v.i_tipotiempo
    ,v.i_tiempo
    ,v.b_tiempo_fecha_hora
    ,v.dt_tiempo_fecha
    ,v.dt_tiempo_hora
    ,v.b_respuesta
    ,v.v_respuesta
    ,v.i_varias_opciones
    ,v.i_cantidad_opciones
    ,v.i_votacion_cantidad
    ,v.i_pregunta_1
    ,v.v_pregunta_1
    ,v.i_pregunta_2
    ,v.v_pregunta_2
    ,v.i_pregunta_3
    ,v.v_pregunta_3
    ,v.i_pregunta_4
    ,v.v_pregunta_4
    ,v.i_pregunta_5
    ,v.v_pregunta_5
    ,v.i_pregunta_6
    ,v.v_pregunta_6
    ,v.i_pregunta_7
    ,v.v_pregunta_7
    ,v.i_pregunta_8
    ,v.v_pregunta_8
    ,v.i_pregunta_9
    ,v.v_pregunta_9
    ,v.i_pregunta_10
    ,v.v_pregunta_10
    ,v.v_observacion
    ,(SELECT COUNT(*) FROM t_votacion_usuario vu WHERE vu.idvotacion = v.idvotacion AND vu.idusuario = _idpais) as 'b_estado'
    ,DATE_FORMAT(v.dt_fecharegistro, '%d-%m-%Y') as 'dt_fecharegistro'
    ,v.v_horaregistro
    ,DATE_FORMAT(v.dt_fecha_ini, '%d-%m-%Y') as 'dt_fecha_ini'
    ,v.dt_hora_ini
    ,DATE_FORMAT(v.dt_fecha_fin, '%d-%m-%Y') as 'dt_fecha_fin'
    ,v.dt_hora_fin
  FROM t_votacion v LEFT JOIN t_usuario u ON v.idusuario = u.idusuario
    WHERE ((v.idusuario = _idusuario) OR (_idusuario = 0))
     AND(
          (_fechainicial = 'vacio' AND _fechafinal = 'vacio')
        OR
          (
            DATE_FORMAT(v.dt_fecha_ini,'%Y-%m-%d') < STR_TO_DATE(_fechainicial,'%Y-%m-%d')
          AND
            DATE_FORMAT(v.dt_fecha_fin,'%Y-%m-%d') < STR_TO_DATE(_fechafinal,'%Y-%m-%d')
          )
        )
     AND ((_idregion = 'all') OR (v.idregion LIKE CONCAT('%', _idregion , '%')))
     AND ((_idprovincia = 'all') OR (v.idprovincia LIKE CONCAT('%', _idprovincia , '%')))
     AND ((_idciudad = 'all') OR (v.idciudad LIKE CONCAT('%', _idciudad , '%')))
     AND ((_iddistrito = "all") OR (v.iddistrito LIKE CONCAT('%', _iddistrito , '%')))
     AND ((v.idvotacion = _idvotacion) OR (_idvotacion = 0))
     AND v.b_estado = 1 ORDER BY DATE_FORMAT(v.dt_fecha_fin, '%d-%m-%Y') DESC;

 ELSEIF (_tipolistado = 4) THEN
 
     SELECT 
     u.v_nombres
    ,u.v_apellidos
    ,u.v_nombre_usuario
    ,v.idvotacion
    ,v.idusuario
    ,v.idpais
    ,v.idregion
    ,v.idprovincia
    ,v.idciudad
    ,v.iddistrito
    ,v.v_ubigeo
    ,v.v_nombre
    ,v.v_descripcion
    ,v.i_tipovotacion
    ,v.i_tipotiempo
    ,v.i_tiempo
    ,v.b_tiempo_fecha_hora
    ,v.dt_tiempo_fecha
    ,v.dt_tiempo_hora
    ,v.b_respuesta
    ,v.v_respuesta
    ,v.i_varias_opciones
    ,v.i_cantidad_opciones
    ,v.i_votacion_cantidad
    ,v.i_pregunta_1
    ,v.v_pregunta_1
    ,v.i_pregunta_2
    ,v.v_pregunta_2
    ,v.i_pregunta_3
    ,v.v_pregunta_3
    ,v.i_pregunta_4
    ,v.v_pregunta_4
    ,v.i_pregunta_5
    ,v.v_pregunta_5
    ,v.i_pregunta_6
    ,v.v_pregunta_6
    ,v.i_pregunta_7
    ,v.v_pregunta_7
    ,v.i_pregunta_8
    ,v.v_pregunta_8
    ,v.i_pregunta_9
    ,v.v_pregunta_9
    ,v.i_pregunta_10
    ,v.v_pregunta_10
    ,v.v_observacion
    ,(SELECT COUNT(*) FROM t_votacion_usuario vu WHERE vu.idvotacion = v.idvotacion AND vu.idusuario = _idpais) as 'b_estado'
    ,DATE_FORMAT(v.dt_fecharegistro, '%d-%m-%Y') as 'dt_fecharegistro'
    ,v.v_horaregistro
    ,DATE_FORMAT(v.dt_fecha_ini, '%d-%m-%Y') as 'dt_fecha_ini'
    ,v.dt_hora_ini
    ,DATE_FORMAT(v.dt_fecha_fin, '%d-%m-%Y') as 'dt_fecha_fin'
    ,v.dt_hora_fin
  FROM t_votacion v LEFT JOIN t_usuario u ON v.idusuario = u.idusuario
    WHERE ((v.idusuario = _idusuario) OR (_idusuario = 0))
     AND ((v.idvotacion = _idvotacion) OR (_idvotacion = 0))
     AND v.b_estado = 1 ORDER BY DATE_FORMAT(v.dt_fecha_fin, '%d-%m-%Y') DESC;

 END IF;

END$$
DELIMITER ;

-- --------------------------------------------------------------------------

-- _tipoactualizar: 1 actualizar , 2 insertar
/*DROP procedure IF EXISTS `sp_operacion_vot_usuario`;*/
DELIMITER $$
CREATE PROCEDURE `sp_operacion_vot_usuario`(
   IN _tipoactualizar INT
  ,IN _idvotacion_usuario INT
  ,IN _idvotacion INT
  ,IN _idusuario INT
  ,IN _v_respuesta VARCHAR(500)
  ,IN _i_cantidad_opciones INT
  ,IN _i_pregunta_1 INT
  ,IN _i_pregunta_2 INT
  ,IN _i_pregunta_3 INT
  ,IN _i_pregunta_4 INT
  ,IN _i_pregunta_5 INT
  ,IN _i_pregunta_6 INT
  ,IN _i_pregunta_7 INT
  ,IN _i_pregunta_8 INT
  ,IN _i_pregunta_9 INT
  ,IN _i_pregunta_10 INT
  ,IN _v_observacion VARCHAR(500)
  ,IN _b_estado BIT(1)
  ,IN _dt_fecharegistro VARCHAR(25)
  ,IN _v_horaregistro VARCHAR(25)
  ,IN _v_fechamodificacion VARCHAR(25)
  ,IN _v_horamodificacion VARCHAR(25))
BEGIN

  IF (_tipoactualizar = 1) THEN
  BEGIN
    
    UPDATE t_votacion_usuario
      SET  
       v_respuesta =  _v_respuesta
      ,i_cantidad_opciones = _i_cantidad_opciones
      ,i_pregunta_1 = _i_pregunta_1
      ,i_pregunta_2 = _i_pregunta_2
      ,i_pregunta_3 = _i_pregunta_3
      ,i_pregunta_4 = _i_pregunta_4
      ,i_pregunta_5 = _i_pregunta_5
      ,i_pregunta_6 = _i_pregunta_6
      ,i_pregunta_7 = _i_pregunta_7
      ,i_pregunta_8 = _i_pregunta_8
      ,i_pregunta_9 = _i_pregunta_9
      ,i_pregunta_10 = _i_pregunta_10
      ,v_observacion = _v_observacion
      ,b_estado = _b_estado
      ,v_fechamodificacion = STR_TO_DATE(_v_fechamodificacion, '%Y-%m-%d')
      ,v_horamodificacion = _v_horamodificacion
    WHERE idvotacion_usuario = _idvotacion_usuario;

  END;
  ELSE 
  BEGIN

    INSERT INTO t_votacion_usuario(
     idvotacion
    ,idusuario
    ,v_respuesta
    ,i_cantidad_opciones
    ,i_pregunta_1 
    ,i_pregunta_2
    ,i_pregunta_3
    ,i_pregunta_4
    ,i_pregunta_5
    ,i_pregunta_6
    ,i_pregunta_7
    ,i_pregunta_8
    ,i_pregunta_9
    ,i_pregunta_10
    ,v_observacion
    ,b_estado
    ,dt_fecharegistro
    ,v_horaregistro)
    VALUES (
       _idvotacion
      ,_idusuario
      ,_v_respuesta
      ,_i_cantidad_opciones
      ,_i_pregunta_1
      ,_i_pregunta_2
      ,_i_pregunta_3
      ,_i_pregunta_4
      ,_i_pregunta_5
      ,_i_pregunta_6
      ,_i_pregunta_7
      ,_i_pregunta_8
      ,_i_pregunta_9
      ,_i_pregunta_10
      ,_v_observacion
      ,1
      ,STR_TO_DATE(_dt_fecharegistro, '%Y-%m-%d')
      ,_v_horaregistro);
    
    END;
    END IF;

END$$
DELIMITER ;

-- --------------------------------------------------------------------------

DROP procedure IF EXISTS `sp_listar_vot_usuario`;
DELIMITER $$
CREATE PROCEDURE `sp_listar_vot_usuario`(
   IN _idusuario INT, IN _idvotacionusuario INT)
BEGIN

  SELECT 
     u.v_nombres
    ,u.v_apellidos
    ,u.v_nombre_usuario
    ,v.idvotacion_usuario
    ,v.idvotacion
    ,v.idusuario
    ,v.v_respuesta
    ,v.i_cantidad_opciones
    ,v.i_pregunta_1
    ,v.i_pregunta_2
    ,v.i_pregunta_3
    ,v.i_pregunta_4
    ,v.i_pregunta_5
    ,v.i_pregunta_6
    ,v.i_pregunta_7
    ,v.i_pregunta_8
    ,v.i_pregunta_9
    ,v.i_pregunta_10
    ,v.v_observacion
    ,v.b_estado
    ,DATE_FORMAT(v.dt_fecharegistro, '%d-%m-%Y') as 'dt_fecharegistro'
    ,v.v_horaregistro
  FROM t_votacion_usuario v LEFT JOIN t_usuario u ON v.idusuario = u.idusuario
    WHERE ((u.idusuario = _idusuario) OR (_idusuario = 0))
     AND ((v.idvotacion = _idvotacionusuario) OR (_idvotacionusuario = 0))
     AND v.b_estado = 1 ORDER BY v.idvotacion DESC;

END$$
DELIMITER ;

-- --------------------------------------------------------------------------
