using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PhotoAlbum.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Test_Divide()
        {
            //arrange
            int expected = 5;
            int numerator = 20;
            int denominator = 4;

            //act
            int actual = PhotoAlbum.Unit.Divide(numerator, denominator);
            //assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void Test_Multiply()
        {
            //arrange
            int expected = 6;
            int Value1 = 20;
            int Value2 = 4;

            //act
            int actual = PhotoAlbum.Unit.Multiply(Value1, Value2);
            //assert
            Assert.AreNotEqual(expected, actual);


        }

        [TestMethod]
        public void Test_GetAlbumById()
        {
            Album album = new Album(1, "Pets");
            int expected = 2;
            int actual = album.getAlbumId();
            Assert.IsNotNull(album);
        }

        [TestMethod]
        public void Test_GetAlbumName()
        {
            Album album = new Album(1, "Pets");
            string expected = "Pets";
            string actual = album.getAlbumName();
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void Test_GetImageName()
        {
            Image image = new Image(1, "My first dog","Ahmed");
            string expected = "My first dog";
            string actual = image.getImageName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_GetImageCaptureLocation()
        {
            Image image = new Image(1, "My first dog", "Ahmed");
            string expected = "Ahmed";
            string actual = image.getCapturedBy();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_GetImageId()
        {
            Image image = new Image(1, "My first dog", "Ahmed");
            Assert.IsNotNull(image);
        }

        [TestMethod]
        public void Test_GetImageNames()
        {
            Image image1 = new Image(1, "My first dog", "Ahmed");
            Image image2 = new Image(1, "Birthday", "Brandon");

            Assert.AreNotEqual(image1.getImageName(), image2.getImageName());
        }





    }
}
