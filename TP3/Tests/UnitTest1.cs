using System;
using Clases_instanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Testeos
{
    [TestClass]
    public class TestUniversidad
    {
        /// <summary>
        /// Comprueba que al intentar agragar a una universidad
        /// dos alumnos con el mismo legajo el sistema 
        /// debe lanzar la excepcion "AlumnoRepetidoException"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void CompruebaAgregarAlumnoRepetido()
        {
            //Arrange
            Universidad uni = new Universidad();
            Alumno alumno01 = new Alumno(1, "Fernando", "Caceres", "122", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Alumno alumno02 = new Alumno(1, "Fernan", "Quiroz", "4456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.Becado);

            //Act
            uni += alumno01;
            uni += alumno02;

            //Assert Exception.
        }


        /// <summary>
        /// Test
        /// Comprueba que al intentar instanciar un objeto del tipo Profesor 
        /// cuando el numero de DNI no se encuentra en el rango esperado por su nacionalidad
        /// se debe lanzar la Exception : "NacionalidadInvalidaException"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void CompruebaInstanciaProfesorNacionalidadInvalida()
        {
            //Arrange
            Profesor p1 = null;

            //Act
            p1 = new Profesor(123, "Estaba", "Andrada", "12432765", EntidadesAbstractas.Persona.ENacionalidad.Extranjero);
            //Assert Exception.
        }

        /// <summary>
        /// Test
        /// Comprueba que al intentar buscar un Profesor para dar una clase y no haya ninguno capaz de darla
        /// se debe lanzar una Exception "SinProfesorException"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void CompruebaxExcepcionSinProfesor()
        {
            //Arrange
            Universidad u1 = new Universidad();
            Universidad.EClases nuevaClase;
            Profesor p1 = null;

            //Act
            nuevaClase = Universidad.EClases.Laboratorio;
            p1 = (u1 == nuevaClase);

            //Assert Exception.
        }

        /// <summary>
        /// Comprueba al intentar instanciar un objeto de tipo Profesor(Persona) pasando
        /// por parametro de DNI una cadena de texto que no se pueda convertir a numero
        /// se debe lanzar la Exception "DniInvalidoExceptino"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void CompruebaFomatoDeDniInvalido()
        {
            //Arrange
            Profesor p1 = null;

            //Act
            p1 = new Profesor(1, "Santiago", "Gimennez", "23456abc", EntidadesAbstractas.Persona.ENacionalidad.Argentino);

            //Assert Exception.
        }

        /// <summary>
        /// Comprueba que al agregar dos instancias de Alumno y Profesor en las listas
        /// de la Universidad, efectivamente se ingresen a las respectivas listas.
        /// </summary>
        [TestMethod]
        
        public void CompruebaInstanciaListaDeAlumnosEnUniversida()
        {
            //Arrange
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Ignacio", "Sanchez", "12345678", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Profesor p1 = new Profesor(2, "Federico", "Davila", "30432542", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            //Act
            uni += a1;
            uni += p1;
            //Assert Exception.
            Assert.AreEqual(1, uni.Alumnos.Count);
            Assert.AreEqual(1, uni.Profesores.Count);
        }


        /// <summary>
        /// Comprueba que si el atributo nombre comienza con un espacio al instanciarse el objeto de tipo Persona
        /// dicho atributo quede vacio.
        /// </summary>
        [TestMethod]

        public void CompruebaFormatoDeNombreValido()
        {
            //Arrange
            Profesor p1;
            
            //Act
            p1 = new Profesor(1, " Roberto Carlos", "Davila", "30432542", EntidadesAbstractas.Persona.ENacionalidad.Argentino);


            //Assert Exception.
            Assert.AreEqual(string.Empty, p1.Nombre);
            
        }

        /// <summary>
        /// Comprueba que el atributo nombre pueda contener una cadena de caracteres con un espacio intermedio
        /// </summary>
        [TestMethod]

        public void CompruebaFormatoDeNombreValidoEspacio()
        {
            //Arrange
            Profesor p1;

            //Act
            p1 = new Profesor(1, "Roberto Carlos", "Davila", "30432542", EntidadesAbstractas.Persona.ENacionalidad.Argentino);


            //Assert Exception.
            Assert.AreEqual("Roberto Carlos", p1.Nombre);

        }


    }
}
