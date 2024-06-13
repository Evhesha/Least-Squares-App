/*
* MATLAB Compiler: 6.2 (R2016a)
* Date: Tue Apr 23 15:01:35 2024
* Arguments: "-B" "macro_default" "-W"
* "dotnet:MathWorks.Matlab.Square,MLNApp,0.0,private" "-T" "link:lib" "-d" "D:\Visual
* Studio\projects\c#\LeastSquaresApp\matlabEdit\plotPolyfit\for_testing" "-v"
* "class{MLNApp:D:\Matlab\bin\plotPolyfit.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace MathWorks.Matlab.SquareNative
{

  /// <summary>
  /// The MLNApp class provides a CLS compliant, Object (native) interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// D:\Matlab\bin\plotPolyfit.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class MLNApp : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static MLNApp()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

          int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "Square.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the MLNApp class.
    /// </summary>
    public MLNApp()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~MLNApp()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the plotPolyfit MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ¬ыполн€ем полиномиальную аппроксимацию методом наименьших квадратов
    /// </remarks>
    ///
    public void plotPolyfit()
    {
      mcr.EvaluateFunction(0, "plotPolyfit", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the plotPolyfit MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ¬ыполн€ем полиномиальную аппроксимацию методом наименьших квадратов
    /// </remarks>
    /// <param name="XArray">Input argument #1</param>
    ///
    public void plotPolyfit(Object XArray)
    {
      mcr.EvaluateFunction(0, "plotPolyfit", XArray);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the plotPolyfit MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ¬ыполн€ем полиномиальную аппроксимацию методом наименьших квадратов
    /// </remarks>
    /// <param name="XArray">Input argument #1</param>
    /// <param name="YArray">Input argument #2</param>
    ///
    public void plotPolyfit(Object XArray, Object YArray)
    {
      mcr.EvaluateFunction(0, "plotPolyfit", XArray, YArray);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the plotPolyfit MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ¬ыполн€ем полиномиальную аппроксимацию методом наименьших квадратов
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] plotPolyfit(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "plotPolyfit", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the plotPolyfit MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ¬ыполн€ем полиномиальную аппроксимацию методом наименьших квадратов
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="XArray">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] plotPolyfit(int numArgsOut, Object XArray)
    {
      return mcr.EvaluateFunction(numArgsOut, "plotPolyfit", XArray);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the plotPolyfit MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ¬ыполн€ем полиномиальную аппроксимацию методом наименьших квадратов
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="XArray">Input argument #1</param>
    /// <param name="YArray">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] plotPolyfit(int numArgsOut, Object XArray, Object YArray)
    {
      return mcr.EvaluateFunction(numArgsOut, "plotPolyfit", XArray, YArray);
    }


    /// <summary>
    /// Provides an interface for the plotPolyfit function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// ¬ыполн€ем полиномиальную аппроксимацию методом наименьших квадратов
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("plotPolyfit", 2, 0, 0)]
    protected void plotPolyfit(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("plotPolyfit", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }

    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
