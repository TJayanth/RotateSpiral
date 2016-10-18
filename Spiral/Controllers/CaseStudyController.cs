using Spiral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spiral.Controllers
{
    public class CaseStudyController : Controller
    {
        #region Case Study - View
        /// <summary>
        /// DashBoard
        /// </summary>
        /// <returns>Returns View of DashBoard</returns>
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// Returns the input and the desired output for the given case study
        /// </summary>
        /// <returns>Returns CaseStudy View</returns>
        public ActionResult CaseStudy()
        {
            CaseStudyModel caseStudyModel = new CaseStudyModel();
            caseStudyModel.inputArray = new int[][] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 10 }, new int[] { 11, 12, 13, 14, 15 }, new int[] { 16, 17, 18, 19, 20 }, new int[] { 21, 22, 23, 24, 25 } };
            caseStudyModel.outPut1 = RotateMatrix(5, 5, caseStudyModel.inputArray);
            caseStudyModel.outPut2 = RotateMatrix(5, 5, caseStudyModel.outPut1);
            return View(caseStudyModel);
        }

        /// <summary>
        /// Returns view for generic type of rotation of 2d array
        /// </summary>
        /// <returns>Returns view for generic rotation of array</returns>
        [HttpGet]
        public ActionResult GenericType()
        {
            return View();
        }

        /// <summary>
        /// Returns the result after rotating the input array the given times
        /// </summary>
        /// <param name="caseStudyModel">Gets the caseStudyModel that contains the number of rotations to be performed</param>
        /// <returns>Returns the view with the array output after rotating for the given times</returns>
        [HttpPost]
        public ActionResult GenericType(CaseStudyModel caseStudyModel)
        {
            if (ModelState.IsValid)
            {
                //Input array
                caseStudyModel.inputArray = new int[][] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 10 }, new int[] { 11, 12, 13, 14, 15 }, new int[] { 16, 17, 18, 19, 20 }, new int[] { 21, 22, 23, 24, 25 } };
                caseStudyModel.genericOutput = caseStudyModel.inputArray;

                //After 25 rotations the value is going to be repeated, by taking mod of 25 reduces the number of computations to atmost 25 times
                int rotationTimes = caseStudyModel.rotationTimes % 25;

                //Rotates the array for the given times
                for (int i = 0; i < rotationTimes; i++)
                {
                    caseStudyModel.genericOutput = RotateMatrix(5, 5, caseStudyModel.genericOutput);
                }
                return View(caseStudyModel);
            }
            else
                return View();
        }

        #endregion

        #region RotateMatrix
        /// <summary>
        /// Rotates 2D array in the desired fashion
        /// </summary>
        /// <param name="row">Number of rows in the given array(Ending row index)</param>
        /// <param name="col">Number of columns in the given array(Ending column index)</param>
        /// <param name="arr">Array for which spiral rotation is to be done</param>
        /// <returns>Returns 2D array after rotation</returns>
        public int[][] RotateMatrix(int row, int col, int[][] arr)
        {
            var matrix = arr.Select(a => a.ToArray()).ToArray();

            int rowIndex = 0; //Starting row index
            int colIndex = 0; //Starting column index
            int previousElement = 0;
            int currentElement;

            while (rowIndex < row && colIndex < col)
            {
                //Stop shifting elements after reaching the center of matrix 
                if (rowIndex + 1 == row || colIndex + 1 == col)
                {
                    //Replace previous value to the centre and break the loop
                    matrix[rowIndex][colIndex] = previousElement;
                    break;
                }

                // Center element to be placed as first element of the new array
                if (rowIndex == 0)
                    previousElement = matrix[row / 2][col / 2];

                // Shift elements of first row
                for (int i = colIndex; i < col; ++i)
                {
                    currentElement = matrix[rowIndex][i];
                    matrix[rowIndex][i] = previousElement;
                    previousElement = currentElement;
                }
                rowIndex++;

                // Shift elements of last column
                for (int i = rowIndex; i < row; ++i)
                {
                    currentElement = matrix[i][col - 1];
                    matrix[i][col - 1] = previousElement;
                    previousElement = currentElement;
                }
                col--;

                // Shift elements of last row 
                if (rowIndex < row)
                {
                    for (int i = col - 1; i >= colIndex; --i)
                    {
                        currentElement = matrix[row - 1][i];
                        matrix[row - 1][i] = previousElement;
                        previousElement = currentElement;
                    }
                }
                row--;

                // Shift elements of first column 
                if (colIndex < col)
                {
                    for (int i = row - 1; i >= rowIndex; --i)
                    {
                        currentElement = matrix[i][colIndex];
                        matrix[i][colIndex] = previousElement;
                        previousElement = currentElement;
                    }
                }
                colIndex++;
            }

            return matrix;
        }

        #endregion
    }
}