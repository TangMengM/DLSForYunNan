using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MyPluginEngine;


using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.SpatialAnalyst;

using Accord;
using Accord.IO;
using Accord.Math;
using Accord.Statistics.Analysis;
using System.Diagnostics;
using ESRI.ArcGIS.Geometry;

//using DLS.CommandLibrary;

namespace DLS
{
    public partial class frmDLSSimulation : DevComponents.DotNetBar.OfficeForm
    {
        private MyPluginEngine.IApplication hk;
        private IMap pMap = null;
        string strProjectPath = "";
        string strDlsPath = "";
        string strToPath = "";
        List<string> lsbNames = new List<string>();

        /// <summary>
        /// 风险等级选择下拉菜单数据绑定
        /// </summary>
        public void CBX_Risk_Bind()
        {
            cbx_risk.Items.Add("低风险");
            cbx_risk.Items.Add("中风险");
            cbx_risk.Items.Add("高风险");
            cbx_risk.Text = "低风险";
        }

        public void CBX_Scene_Bind()
        {
            cbx_scene.Items.Add("基准情景");
            cbx_scene.Items.Add("经济优先");
            cbx_scene.Items.Add("生态保育");
        }

        public frmDLSSimulation()
        {
            InitializeComponent();
            //禁用Glass主题
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //去除图标
            this.ShowIcon = false;
        }

        public frmDLSSimulation(IMap _pMap)
        {
            InitializeComponent();
            if (_pMap != null)
                pMap = _pMap;
        }

        /// <summary>
        /// 参数配置界面启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDLSParemeters_Load(object sender, EventArgs e)
        {
            //风险下拉菜单等级绑定
            CBX_Risk_Bind();
            //情景选择下拉菜单绑定
            CBX_Scene_Bind();
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                if (pMap.get_Layer(i) is RasterLayer)
                {
                }
            }

            #region 加载土地利用现状
            string sLandUse = "";

            StreamReader sr = new StreamReader("LandUse.txt", System.Text.Encoding.Default);
            try
            {
                //使用StreamReader类来读取文件
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                // 从数据流中读取每一行，直到文件的最后一行
                string strLine = sr.ReadLine();
                while (strLine != null)
                {
                    sLandUse = sLandUse + strLine;
                    strLine = sr.ReadLine();
                }
                //关闭此StreamReader对象
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sr.Close();
            }
            string[] parts = sLandUse.Split(new char[] { ',' });
            lab_nowCuilt.Text = " " + parts[0] + Environment.NewLine +"平方千米";
            lab_nowForest.Text = " " + parts[1] + Environment.NewLine + "平方千米";
            lab_nowGrass.Text = " " + parts[2] + Environment.NewLine + "平方千米";
            lab_nowWater.Text = " " + parts[3] + Environment.NewLine + "平方千米";
            lab_nowBuild.Text = " " + parts[4] + Environment.NewLine + "平方千米";
            label31.Text = " 0" + Environment.NewLine + " 平方千米";
            #endregion

            string sDemandCuilt = parts[5];
            string sDemandForest = parts[6];
            string sDemandGrass = parts[7];
            string sDemandWater = parts[8];
            string sDemandBuild = parts[9];

            //设置滑块属性
            //耕地滑块
            trackBarCult.Minimum = 0;
            trackBarCult.Maximum = 300;
            trackBarCult.TickFrequency = 25;
            trackBarCult.SmallChange = 5;
            trackBarCult.LargeChange = 25;
            trackBarCult.Value = Convert.ToInt32(sDemandCuilt);
            //林地滑块
            trackBarFore.Minimum = 0;
            trackBarFore.Maximum = 600;
            trackBarFore.TickFrequency = 25;
            trackBarFore.SmallChange = 5;
            trackBarFore.LargeChange = 25;
            trackBarFore.Value = Convert.ToInt32(sDemandForest);
            //草地滑块
            trackBarGrass.Minimum = 0;
            trackBarGrass.Maximum = 900;
            trackBarGrass.TickFrequency = 25;
            trackBarGrass.SmallChange = 5;
            trackBarGrass.LargeChange = 25;
            trackBarGrass.Value = Convert.ToInt32(sDemandGrass);
            //水域滑块
            trackBarWater.Minimum = 0;
            trackBarWater.Maximum = 300;
            trackBarWater.TickFrequency = 25;
            trackBarWater.SmallChange = 5;
            trackBarWater.LargeChange = 25;
            //水域值固定为208
            trackBarWater.Value = Convert.ToInt32(sDemandWater);
            //建设用地滑块
            trackBarBuild.Minimum = 0;
            trackBarBuild.Maximum = 500;
            trackBarBuild.TickFrequency = 25;
            trackBarBuild.SmallChange = 5;
            trackBarBuild.LargeChange = 25;
            trackBarBuild.Value = Convert.ToInt32(sDemandBuild);

            trackBar1.Minimum = 0;
            trackBar1.Maximum = 500;
            trackBar1.TickFrequency = 25;
            trackBar1.SmallChange = 5;
            trackBar1.LargeChange = 25;
            trackBar1.Value = 0;

            labelCul.Text = trackBarCult.Value.ToString()+" 平方千米";
            labelFor.Text = trackBarFore.Value.ToString() + " 平方千米";
            labelGar.Text = trackBarGrass.Value.ToString() + " 平方千米";
            labelWat.Text = trackBarWater.Value.ToString() + " 平方千米";
            labelBui.Text = trackBarBuild.Value.ToString() + " 平方千米";
            lab_unUsedLand.Text = trackBar1.Value.ToString() + " 平方千米";


            //建筑用地转换概率
            nud_build.Minimum = 0;            //允许最小值
            nud_build.Maximum = 1;            //允许最大值
            nud_build.DecimalPlaces = 1;      //小数点后面位数
            nud_build.Increment = 0.1M;         //间隔
            nud_build.InterceptArrowKeys = true;
            nud_build.Value = 0M;             //初始值

            //林地用地转换概率
            nud_forest.Minimum = 0;            //允许最小值
            nud_forest.Maximum = 1;            //允许最大值
            nud_forest.DecimalPlaces = 1;      //小数点后面位数
            nud_forest.Increment = 0.1M;         //间隔
            nud_forest.InterceptArrowKeys = true;
            nud_forest.Value = 0.7M;             //初始值

            //草地用地转换概率
            nud_grass.Minimum = 0;            //允许最小值
            nud_grass.Maximum = 1;            //允许最大值
            nud_grass.DecimalPlaces = 1;      //小数点后面位数
            nud_grass.Increment = 0.1M;         //间隔
            nud_grass.InterceptArrowKeys = true;
            nud_grass.Value = 0.8M;             //初始值

            //耕地用地转换概率
            nud_cuilt.Minimum = 0;            //允许最小值
            nud_cuilt.Maximum = 1;            //允许最大值
            nud_cuilt.DecimalPlaces = 1;      //小数点后面位数
            nud_cuilt.Increment = 0.1M;         //间隔
            nud_cuilt.InterceptArrowKeys = true;
            nud_cuilt.Value = 0.8M;             //初始值

            //水域用地转换概率
            nud_water.Minimum = 0;            //允许最小值
            nud_water.Maximum = 1;            //允许最大值
            nud_water.DecimalPlaces = 1;      //小数点后面位数
            nud_water.Increment = 0.1M;         //间隔
            nud_water.InterceptArrowKeys = true;
            nud_water.Value = 0.1M;             //初始值

            //建筑用地转换概率
            nud_build.Minimum = 0;            //允许最小值
            nud_build.Maximum = 1;            //允许最大值
            nud_build.DecimalPlaces = 1;      //小数点后面位数
            nud_build.Increment = 0.1M;         //间隔
            nud_build.InterceptArrowKeys = true;
            nud_build.Value = 0M;             //初始值

            //未利用地转换概率
            nud_unUseLand.Minimum = 0;            //允许最小值
            nud_unUseLand.Maximum = 1;            //允许最大值
            nud_unUseLand.DecimalPlaces = 1;      //小数点后面位数
            nud_unUseLand.Increment = 0.1M;         //间隔
            nud_unUseLand.InterceptArrowKeys = true;
            nud_unUseLand.Value = 0M;             //初始值


            nud_numberOfLanduse.Minimum = 0;            //允许最小值
            nud_numberOfLanduse.Maximum = 15;            //允许最大值
            nud_numberOfLanduse.DecimalPlaces = 0;      //小数点后面位数
            nud_numberOfLanduse.Increment = 1;         //间隔
            nud_numberOfLanduse.InterceptArrowKeys = true;
            nud_numberOfLanduse.Value = 5;             //初始值

            nud_convergence.Minimum = 0;            //允许最小值
            nud_convergence.Maximum = 10;            //允许最大值
            nud_convergence.DecimalPlaces = 0;      //小数点后面位数
            nud_convergence.Increment = 1;         //间隔
            nud_convergence.InterceptArrowKeys = true;
            nud_convergence.Value = 3;             //初始值

            nud_targetYear.Minimum = 2000;            //允许最小值
            nud_targetYear.Maximum = 2100;            //允许最大值
            nud_targetYear.DecimalPlaces = 0;      //小数点后面位数
            nud_targetYear.Increment = 1;         //间隔
            nud_targetYear.InterceptArrowKeys = true;
            nud_targetYear.Value = 2020;             //初始值


        }

        private void btnSimulation_Click(object sender, EventArgs e)
        {
            //string sDLSPath = Application.StartupPath + "\\DLS\\bin\\bin.x86\\dls.exe";
            string sDLSPath = strToPath + "\\RunDLS\\bin\\bin.x86\\dls.exe";
            Process.Start(sDLSPath);
        }

        private void btnProjectPath_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(System.Windows.Forms.Application.StartupPath);
            this.txtProjectPath.Text = @"D:";

            string strFromPath = System.Windows.Forms.Application.StartupPath + "\\RunDLS";
            
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择工程数据存储路径";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                strToPath = fbd.SelectedPath;
                strDlsPath = strToPath;
                this.txtProjectPath.Text = strToPath;
                //dls输入数据路径
                strProjectPath = strToPath + "\\RunDLS\\DLS\\Input";

                CopyFolder(strFromPath,strToPath);
                MessageBox.Show(this,"工程创建成功\""+strToPath+"\"","提示");
            }
        }

        /// <summary>
        /// 拷贝文件夹(包括子文件夹)到指定文件夹下
        /// 文件和文件夹分开复制，当是文件夹则递归复制
        /// </summary>
        /// <param name="strFromPath">待复制地址</param>
        /// <param name="strToPath">目标地址</param>
        public static void CopyFolder(string strFromPath, string strToPath)
        {
            //如果源文件夹不存在，则创建  
            if (!Directory.Exists(strFromPath))
            {
                Directory.CreateDirectory(strFromPath);
            }
            //取得要拷贝的文件夹名  
            string strFolderName = strFromPath.Substring(
                strFromPath.LastIndexOf("\\") + 1,
                strFromPath.Length -
                strFromPath.LastIndexOf("\\") - 1);
            //如果目标文件夹中没有源文件夹
            //则在目标文件夹中创建源文件夹 
            if (!Directory.Exists(
                strToPath + "\\" + strFolderName))
            {
                Directory.CreateDirectory(
                    strToPath + "\\" + strFolderName);
            }
            //创建数组保存源文件夹下的文件名  
            string[] strFiles =
                Directory.GetFiles(strFromPath);
            //循环拷贝文件 
            for (int i = 0; i < strFiles.Length; i++)
            {
                //取得拷贝的文件名，只取文件名，地址截掉。
                string strFileName = strFiles[i].Substring(
                    strFiles[i].LastIndexOf("\\") + 1,
                    strFiles[i].Length -
                    strFiles[i].LastIndexOf("\\") - 1);
                //开始拷贝文件,true表示覆盖同名文件  
                File.Copy(
                    strFiles[i],
                    strToPath + "\\" + strFolderName +
                    "\\" + strFileName,
                    true);
            }
            //创建DirectoryInfo实例  
            DirectoryInfo dirInfo =
                new DirectoryInfo(strFromPath);
            //取得源文件夹下的所有子文件夹名称 
            DirectoryInfo[] ZiPath =
                dirInfo.GetDirectories();
            for (int j = 0; j < ZiPath.Length; j++)
            {
                //获取所有子文件夹名  
                string strZiPath = strFromPath + "\\" +
                    ZiPath[j].ToString();
                //把得到的子文件夹当成新的
                //源文件夹，从头开始新一轮的拷贝
                CopyFolder(
                    strZiPath,
                    strToPath + "\\" + strFolderName);
            }
        }


        private void btnBoundary_Click(object sender, EventArgs e)
        {
            //IWorkspaceFactory workSpaceF = new RasterWorkspaceFactory();
            //IWorkspace workSpace;
            //string strToPath = "";
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.Description = "请选择栅格数据存储路径";
            //if (fbd.ShowDialog() == DialogResult.OK)
            //{
            //    strToPath = fbd.SelectedPath;
            //    this.txtProjectPath.Text = strToPath;
            //    workSpace = workSpaceF.OpenFromFile(strToPath,0);
            //    if(workSpace==null)
            //    {
            //        MessageBox.Show("Could not open workspce");
            //        return;
            //    }

            //}
        }

        private void Rater2Ascii(IGeoDataset mask,double cellsize,IGeoDataset inData,string ascFileName)
        {
            if (mask == null)
                return;
            if (inData == null)
                return;
            if (ascFileName.Trim() == "")
                return;
            IRasterExportOp rexp=new RasterConversionOpClass();
            IRasterAnalysisEnvironment pEnv = (IRasterAnalysisEnvironment)rexp;
            object dCellSize = cellsize;  //栅格大小
            pEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref dCellSize);
            pEnv.Mask=mask;
            //cov1_0.0  con1_(land use type)_(simulation year)
            //string ascFile=this.txtProjectPath.Text="\\DLS\\DLS\\Input\\con1_0.0";
            //文件存在就删除
            FileInfo file = new FileInfo(ascFileName);
            if (file.Exists)
            {
                file.Delete();
            } 
            rexp.ExportToASCII(inData, ascFileName);
            //IRasterextrac rexp = new RasterConversionOpClass();
        }
        private void Rater2ASCII_GP()
        {
            IAoInitialize m_AoInitialize = new AoInitializeClass();
            esriLicenseStatus licenseStatus = esriLicenseStatus.esriLicenseUnavailable;
            licenseStatus = m_AoInitialize.Initialize(esriLicenseProductCode.esriLicenseProductCodeAdvanced);
            if (licenseStatus == esriLicenseStatus.esriLicenseCheckedOut)
            {
                Geoprocessor tGp = new Geoprocessor();
                tGp.OverwriteOutput = true;
                //执行raster to ASC2 
                RasterToASCII rastertoASCIITool = new RasterToASCII();
                string ascFile = "";
                IGeoDataset gdsIn = null;
                rastertoASCIITool.in_raster = gdsIn;
                rastertoASCIITool.out_ascii_file = ascFile;

                IGeoProcessorResult tGeoResult = (IGeoProcessorResult)tGp.Execute(rastertoASCIITool, null);
            }

        }

        /// <summary>
        /// 生成参数数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateInputData_Click(object sender, EventArgs e)
        {
            //if (this.strProjectPath.Trim() == "")
            //    return;
            
            //if (lsbLayerDriverFactor.Items.Count == 0)
            //    return;

            //云南项目中，地类只有5项
            int iLanduseType = 5;

            //ILayer pLayer = null;
            IRaster pRaster = new RasterClass();

            IGeoDataset pGdsMask = null;
            IRasterBandCollection pRasterBandColection=(new RasterClass()) as IRasterBandCollection;

            
            //try
            //{
                

               
                //驱动因子
                //string[] arr = new string[this.lsbLayerDriverFactor.Items.Count];
                
                //for (int i = 0; i < this.lsbLayerDriverFactor.Items.Count; i++) 
                //{
                //    arr[i]=this.lsbLayerDriverFactor.Items[i].ToString();
                //}
                
                this.rtxtState.AppendText("输出土地利用参数数据成功。\n");
                this.rtxtState.AppendText("读取驱动因子数据...\n");
                this.rtxtState.ScrollToCaret();

                this.rtxtState.AppendText("开始制备驱动因子参数...\n");
                this.rtxtState.ScrollToCaret();

                //IGeoDataset curtestGeo = null;
                ////boundaty-->mask
                //for (int i = 0; i < pMap.LayerCount; i++)
                //{
                //    ILayer pLyr = pMap.get_Layer(i);
                //    if (pLyr is IRasterLayer)
                //    {
                //        if (pLyr.Name == sLyrMask)
                //        {
                //            curtestGeo = ((pLyr as IRasterLayer).Raster) as IGeoDataset;
                //        }
                //    }
                //}


                //sample data
                ITable itFactors = ExportSample(pGdsMask, pRasterBandColection);
                
                //logistic 回归分析


                //lsbNames.AddRange(names);
                DataTable dtFactors = ITable2DTable(itFactors);


                itFactors = null;
                //MessageBox.Show(dtFactors.Columns[0].ColumnName + ";" + dtFactors.Columns[1].ColumnName + ";" + dtFactors.Columns[2].ColumnName);
            
                //制备驱动力参数文件
                this.rtxtState.AppendText("读取驱动因子数据表格数据...\n");
                this.rtxtState.ScrollToCaret();
                LogisticRegressionAnalysis lra;
                // Gets the columns of the independent variables
                List<string> names = new List<string>();

                

                String[] independentNames = names.ToArray();
                DataTable independent = dtFactors.DefaultView.ToTable(false, independentNames);
                // Creates the input and output matrices from the source data table
                double[][] input = independent.ToArray();
                double[,] sourceMatrix = dtFactors.ToMatrix(independentNames);

                StreamWriter sw = new StreamWriter(strProjectPath + "\\alloc1.reg", false);
                for(int ild=0; ild< iLanduseType; ild++)
                {
                    
                    this.rtxtState.AppendText("开始制备土地利用类型【" + ild.ToString() + "】驱动因子参数...\n");
                    this.rtxtState.ScrollToCaret();
                    DataColumn taxColumn =new DataColumn(); 
                    taxColumn.DataType = System.Type.GetType("System.Int32"); 
                    taxColumn.ColumnName ="sysland"+ild.ToString();//列名 
                    taxColumn.Expression = "iif("+lsbNames[0]+" = "+ild.ToString()+",1,0)";//设置该列得表达式，用于计算列中的值或创建聚合列
                    dtFactors.Columns.Add(taxColumn);
                    string dependentName = "sysland" + ild.ToString();

                    DataTable dependent = dtFactors.DefaultView.ToTable(false, dependentName);
                    double[] output = dependent.Columns[dependentName].ToArray();
                   

                    // Creates the Simple Descriptive Analysis of the given source
                    DescriptiveAnalysis sda = new DescriptiveAnalysis(sourceMatrix, independentNames);
                    sda.Compute();

                    // Populates statistics overview tab with analysis data
                    //dgvDistributionMeasures.DataSource = sda.Measures;

                    // Creates the Logistic Regression Analysis of the given source
                    lra = new LogisticRegressionAnalysis(input, output, independentNames, dependentName);


                    // Compute the Logistic Regression Analysis
                    lra.Compute();

                    // Populates coefficient overview with analysis data
                    //lra.Coefficients;
              
                    //MessageBox.Show(lra.Coefficients.Count.ToString());
                    //MessageBox.Show(lra.CoefficientValues[0].ToString());


                    //string str_check = listBox_deVar.Items[var_count].ToString().ToLower();
                    string st = ild.ToString();
                    int Relength = lra.CoefficientValues.Length;
                   
                    int number = 0;
                    for (int i = 1; i < Relength; i++)
                    {
                        //if (< 0.05)
                        //{
                            number++;
                        //}
                    }

                    // 保存alloc1.reg 文件
                    sw.WriteLine(st);
                    sw.WriteLine("\t" + Math.Round(lra.CoefficientValues[1], 6));//改过了1=0
                    sw.WriteLine(number);
                    int var_number2 = 0;
                    for (int i = 0; i < Relength; i++)//改过了0=1
                    {
                        //if ( < 0.05)
                        //{
                        sw.WriteLine("\t" + Math.Round(lra.CoefficientValues[i],6) + "\t" + var_number2);
                        //}
                        var_number2 = var_number2 + 1;
                    }
                    //progressBar1.Value = var_count + 1;
                }
                sw.Close();
            
                this.rtxtState.AppendText("制备驱动因子参数成功。\n");
                this.rtxtState.ScrollToCaret();
                MessageBox.Show("制备驱动因子参数成功!","提示",MessageBoxButtons.OK);
            
            #region 拷贝已经制备好的INPUT数据到DLS模型的INPUT目录下

               

            #endregion

        }

        private void btnParameterOpen_Click(object sender, EventArgs e)
        {
            string sParameter = "";
            OpenFileDialog ofdMain = new OpenFileDialog();
            ofdMain.Filter = "(*.1)|*.1|" + "(*.txt)|*.txt|" + "(*.*)|*.*";
            ofdMain.FilterIndex = 0;
            
            
            if (ofdMain.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofdMain.FileName, System.Text.Encoding.Default);
                try
                {
                    //使用StreamReader类来读取文件
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    // 从数据流中读取每一行，直到文件的最后一行
                    string strLine = sr.ReadLine();
                    while (strLine != null)
                    {
                        if (!sr.EndOfStream)
                        {
                            sParameter = sParameter + " " + strLine;
                            strLine = sr.ReadLine();
                        }
                        else
                        {
                            sParameter = sParameter + strLine;
                            strLine = sr.ReadLine();
                        }
                    }
                    //关闭此StreamReader对象
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    sr.Close();
                }
                string[] parts = sParameter.Split(new char[] { ' ' });
                nud_numberOfLanduse.Value = Convert.ToDecimal(parts[1]);
                nud_cuilt.Value = Convert.ToDecimal(parts[7]);
                nud_forest.Value = Convert.ToDecimal(parts[8]);
                nud_grass.Value = Convert.ToDecimal(parts[9]);
                nud_water.Value = Convert.ToDecimal(parts[10]);
                nud_build.Value = Convert.ToDecimal(parts[11]);
                nud_convergence.Value = Convert.ToDecimal(parts[12]);
                nud_targetYear.Value = Convert.ToDecimal(parts[14]);
            }
        }

        private void btnParameterSave_Click(object sender, EventArgs e)
        {
            string sNumOfLandUse = nud_numberOfLanduse.Value.ToString();
            string sCuilt = nud_cuilt.Value.ToString();
            string sForest = nud_forest.Value.ToString();
            string sGrass = nud_grass.Value.ToString();
            string sWater = nud_water.Value.ToString();
            string sBuild = nud_build.Value.ToString();
            string sConvergence = nud_convergence.Value.ToString();
            string sTargetYear = nud_targetYear.Value.ToString();
            string sParameter = sNumOfLandUse + Environment.NewLine + "0 1 2 3 4" + Environment.NewLine + sCuilt + " " + sForest + " " + sGrass + " " + sWater + " " + sBuild + Environment.NewLine + sConvergence + Environment.NewLine + "2019" + " " + sTargetYear + Environment.NewLine + "0" + Environment.NewLine + "1";

            try
            {
                SaveFileDialog sfdParameterSave = new SaveFileDialog();
                sfdParameterSave.Filter = "(*.1)|*.1|" + "(*.txt)|*.txt|" + "(*.*)|*.*";
                sfdParameterSave.FileName = "main";

                if (sfdParameterSave.ShowDialog() == DialogResult.OK)
                {
                    System.IO.FileStream fs = new System.IO.FileStream(sfdParameterSave.FileName, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    //开始写入
                    sw.Write(sParameter);
                    //清空缓冲区
                    sw.Flush();
                    //关闭流
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbRstraint_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            //toolTip1.AutoPopDelay = 1000;//一下4个都是属性
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
        }

        /// <summary>
        /// 存在ascii格式的文件
        /// </summary>
        /// <param name="_header">arcgis ascii 文件头</param>
        /// <param name="_dt">ascii文件数据</param>
        /// <param name="_saveFileName">保存路径</param>
        private void DataTable2Txt(string[] _header,int _landusetype, int[,] _dt,string _FilePath)
        {
            for (int ild = 0; ild < _landusetype; ild++)
            {
                string _saveFileName = _FilePath + "\\cov1_" + ild.ToString() + ".0";
                StreamWriter sr;
                if (File.Exists(_saveFileName))
                {
                    //如果文件存在,则删除对象 
                    File.Delete(_saveFileName);
                }
                //创建File.CreateText对象   
                sr = File.CreateText(_saveFileName);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < _header.Length; i++)
                {
                    sr.WriteLine(_header[i]);
                }
                string dtLine = "";
                for (int i = 0; i < _dt.GetLength(0); i++)
                {
                    dtLine = "";
                    for (int j = 0; j < _dt.GetLength(1); j++)
                    {
                        if (_dt[i, j] == ild)
                        {
                            dtLine = dtLine+"1 ";
                        }
                        else if (_dt[i, j] == -9999)
                        {
                            dtLine = dtLine+"-9999 ";
                        }
                        else
                        {
                           dtLine = dtLine+"0 ";
                        }
                    }
                    dtLine = dtLine.TrimEnd();
                    sr.WriteLine(dtLine);
                }
                sr.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pGdsLocation"></param>
        /// <param name="_BandCol"></param>
        /// <returns></returns>
        private ITable ExportSample(IGeoDataset _pGdsLocation, IRasterBandCollection _BandCol)
        {
            //IRasterLayer pRastetLayer = pLayer as IRasterLayer;
            //IRasterBandCollection pRasterBandColection = pRastetLayer.Raster as IRasterBandCollection;
            //if (pRasterBandColection.Count == 1)
            //{
                //Create the RasterExtractionOp object
                IExtractionOp pExtractionOp = new RasterExtractionOpClass();
                ////Declare the input location raster object
                //IGeoDataset pGdsLocation=_pGdsLocation;  
                ////Create a raster of multiple bands
                //IRasterBandCollection pBandCol=_BandCol;
                ////Declare the output table object
                ITable pOutputTable;
                //Calls the method     
                pOutputTable = pExtractionOp.Sample(_pGdsLocation, _BandCol as IGeoDataset, esriGeoAnalysisResampleEnum.esriGeoAnalysisResampleNearest);     
                return pOutputTable;
            //}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pRTable"></param>
        /// <returns></returns>
 
        private DataTable ITable2DTable(ITable _pRTable)
        {
            DataTable pTable = new DataTable();
            //此方法不能使用，对一些字段是不能删除的
            // cannot be removed include:
            //OBJECTID field 
            //SHAPE and shape dependent fields such as SHAPE_Length 
            //Enabled, AncillaryRole and Weight field for network feature classes 
            // try  
            //{ 
                // 删除字段 X Y
                //IFields pfields;
                //IField pfield;
                //pfields = _pRTable.Fields;
                //int fieldIndex = pfields.FindField("x");
                //pfield = pfields.get_Field(fieldIndex);
                //_pRTable.DeleteField(pfield);
                

                //fieldIndex = pfields.FindField("y");
                //pfield = pfields.get_Field(fieldIndex);
                //_pRTable.DeleteField(pfield);
            //}


            // catch (Exception ex)
            // {
                 
             //}

            //将ITable 转化到 DataTable 
            for (int i = 0; i < _pRTable.Fields.FieldCount; i++)
            {
                pTable.Columns.Add(_pRTable.Fields.get_Field(i).Name);
            }
            ICursor pCursor = _pRTable.Search(null,false);
            IRow pRrow = pCursor.NextRow();
            bool flag = true;
            while (pRrow != null)
            {
                flag = true;
                DataRow pRow = pTable.NewRow();
                for (int i = 0; i < pRrow.Fields.FieldCount; i++)
                {
                    pRow[i] = pRrow.get_Value(i);
                    //有缺失值的行排除掉
                    if (pRow[i] == System.DBNull.Value)
                    {
                        flag = false;
                        break;
                    }
                }
                if(flag)
                {
                    pTable.Rows.Add(pRow);
                }
                pRrow = pCursor.NextRow();
            }


            // 删除x,y以及之前的列，并对因子列更改列名
            int Yindex = pTable.Columns.IndexOf("y");
            for (int i = 0; i <= Yindex; i++) 
            {
                //MessageBox.Show(pTable.Columns[i].ColumnName);
                //注意这里不是 i 是 0 ;每次删除后需要删除的列在第一个
                pTable.Columns.RemoveAt(0);   
            };
            int fieldCount = pTable.Columns.Count;
            for (int i = 0; i < fieldCount; i++)
            {
                pTable.Columns[i].ColumnName = lsbNames[i];
            }
            //DataViewTest dt = new DataViewTest(pTable);
            //dt.ShowDialog();
            return pTable;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnRstraint_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 打开情景数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDemandOpen_Click(object sender, EventArgs e)
        {
            string sDemand = "";
            OpenFileDialog ofdDemand = new OpenFileDialog();
            ofdDemand.InitialDirectory = strProjectPath;
            ofdDemand.Filter = "(*.in1)|*.in1|" + "(*.txt)|*.txt|" + "(*.*)|*.*";
            ofdDemand.FilterIndex = 0;
            if (ofdDemand.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofdDemand.FileName, System.Text.Encoding.Default);
                try
                {
                    //使用StreamReader类来读取文件
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    // 从数据流中读取每一行，直到文件的最后一行
                    string strLine = sr.ReadLine();
                    while (strLine != null)
                    {
                        if (!sr.EndOfStream)
                        {
                            sDemand = sDemand + " " + strLine;
                            strLine = sr.ReadLine();
                        }
                        else
                        {
                            sDemand = sDemand + strLine;
                            strLine = sr.ReadLine();
                        }
                    }
                    //关闭此StreamReader对象
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    sr.Close();
                }
            }

            string[] parts = sDemand.Split(new char[] { ',' });
            lab_nowCuilt.Text = " " + parts[0] + "平方千米";
            lab_nowForest.Text = " " + parts[1] + "平方千米";
            lab_nowGrass.Text = " " + parts[2] + "平方千米";
            lab_nowWater.Text = " " + parts[3] + "平方千米";
            lab_nowBuild.Text = " " + parts[4] + "平方千米";
            trackBarCult.Value = Convert.ToInt32(parts[5]);
            trackBarFore.Value = Convert.ToInt32(parts[6]);
            trackBarGrass.Value = Convert.ToInt32(parts[7]);
            trackBarWater.Value = Convert.ToInt32(parts[8]);
            trackBarBuild.Value = Convert.ToInt32(parts[9]);
            labelCul.Text = " " + parts[5] + "平方千米";
            labelFor.Text = " " + parts[6] + "平方千米";
            labelGar.Text = " " + parts[7] + "平方千米";
            labelWat.Text = " " + parts[8] + "平方千米";
            labelBui.Text = " " + parts[9] + "平方千米";

        }
        /// <summary>
        /// 保存情景数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDemandSave_Click(object sender, EventArgs e)
        {
            string landUse = "";
            sLandUseDemand = trackBarCult.Value.ToString() + " " + trackBarFore.Value.ToString() + " " + trackBarGrass.Value.ToString() + " " + trackBarWater.Value.ToString() + " " + trackBarBuild.Value.ToString();
            landUse = labelCul.Text + " " + labelFor.Text + " " + labelGar.Text + " " + labelWat.Text + " " + labelBui.Text + System.Environment.NewLine + sLandUseDemand;
            try
            {
                SaveFileDialog sfdDemand = new SaveFileDialog();
                sfdDemand.InitialDirectory = strProjectPath;
                sfdDemand.Filter = "(*.in1)|*.in1|" + "(*.txt)|*.txt|" + "(*.*)|*.*";
                sfdDemand.FileName = "demand";

                if (sfdDemand.ShowDialog() == DialogResult.OK)
                {
                    System.IO.FileStream fs = new System.IO.FileStream(sfdDemand.FileName, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    //开始写入
                    sw.Write(landUse);
                    //清空缓冲区
                    sw.Flush();
                    //关闭流
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        public void DeleteFiles(string path)
        {
            if (Directory.Exists(path) == false)
            {
                MessageBox.Show("Path is not Existed!");
                return;
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            try
            {
                foreach (var item in files)
                {
                    File.Delete(item.FullName);
                }
                if (dir.GetDirectories().Length != 0)
                {
                    foreach (var item in dir.GetDirectories())
                    {
                        if (!item.ToString().Contains("$") && (!item.ToString().Contains("Boot")))
                        {
                            // Console.WriteLine(item);

                            DeleteFiles(dir.ToString() + "\\" + item.ToString());
                        }
                    }
                }
                //Directory.Delete(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Delete Failed!");
                return;

            }

        }

        public void CopyUpdateFile(string srcPath, string aimPath)
        {
            if (aimPath[aimPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                aimPath += System.IO.Path.DirectorySeparatorChar;
            if (!Directory.Exists(aimPath))
                Directory.CreateDirectory(aimPath);
            if (!Directory.Exists(srcPath))
                return;
            string[] fileList = Directory.GetFileSystemEntries(srcPath);

            foreach (string file in fileList)
            {
                int k = file.LastIndexOf("\\");
                string filename = file.Substring(k + 1);
                if (filename.ToLower() != System.IO.Path.GetFileName(System.Windows.Forms.Application.ExecutablePath).ToLower())
                {
                    if (Directory.Exists(file))
                        CopyUpdateFile(file, aimPath + System.IO.Path.GetFileName(file));
                    else
                    {
                        try
                        {
                            File.Copy(file, aimPath + System.IO.Path.GetFileName(file), true);
                            //File.Delete(file);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("复制文件失败：" + file + e.Message);
                            continue;
                        }
                    }
                }
            }
        } 

        /// <summary>
        /// 文件移动
        /// </summary>
        /// <param name="sFromPath"></param>
        /// <param name="sToPath"></param>
        public void FileMove(string sFromPath, string sToPath)
        {
            DeleteFiles(sToPath);
            CopyUpdateFile(sFromPath, sToPath);
        }

        /// <summary>
        /// 获取不同情景与风险等级的input数据路径
        /// </summary>
        /// <param name="sRiskType"></param>
        /// <param name="sSceneType"></param>
        /// <returns></returns>
        public string getFromPath(string sRiskType, string sSceneType)
        {
            string strInputFromPath = "";
            string strFromPath = System.Windows.Forms.Application.StartupPath + "\\Data\\DLS_Input";
            switch (sRiskType)
            {
                case "高风险":
                    switch (sSceneType)
                    {
                        case "基准情景": strInputFromPath = strFromPath + "\\highRisk_basic";
                            break;
                        case "经济优先": strInputFromPath = strFromPath + "\\highRisk_economic";
                            break;
                        case "生态保育": strInputFromPath = strFromPath + "\\highRisk_ecology";
                            break;
                    }
                    break;
                case "中风险":
                    switch (sSceneType)
                    {
                        case "基准情景": strInputFromPath = strFromPath + "\\middleRisk_basic";
                            break;
                        case "经济优先": strInputFromPath = strFromPath + "\\middleRisk_economic";
                            break;
                        case "生态保育": strInputFromPath = strFromPath + "\\middleRisk_ecology";
                            break;
                    }
                    break;
                case "低风险":
                    switch (sSceneType)
                    {
                        case "基准情景": strInputFromPath = strFromPath + "\\lowRisk_basic";
                            break;
                        case "经济优先": strInputFromPath = strFromPath + "\\lowRisk_economic";
                            break;
                        case "生态保育": strInputFromPath = strFromPath + "\\lowRisk_ecology";
                            break;
                    }
                    break;
                default: strInputFromPath = strFromPath + "\\highRisk_basic";
                    break;
            }
            return strInputFromPath;

        }

        /// <summary>
        /// 提取已制备好的参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_copydata_Click(object sender, EventArgs e)
        {
            if (this.txtProjectPath.Equals(""))
            {
                MessageBox.Show("请选择工程位置路径！");
                return;
            }
            
            string sRiskType = this.cbx_risk.Text.Trim();
            string sSceneType = this.cbx_scene.Text.Trim();
            string sFromPath = getFromPath(sRiskType, sSceneType);

            string sToPath = this.txtProjectPath.Text + "\\RunDLS\\DLS\\Input";
            FileMove(sFromPath, sToPath);
            MessageBox.Show("参数提取完毕！");
            
        }

        /// <summary>
        /// 替换TXT中的值
        /// </summary>
        /// <param name="sTxtFileName">文件名</param>
        /// <param name="sOldStr">原字符串</param>
        /// <param name="sNewStr">替换字符串</param>
        public void ReplaceTxt(string sTxtFileName, string sOldStr, string sNewStr)
        {
            //按行读取为字符串数组
            ArrayList LineList = new ArrayList();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(sTxtFileName))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    str = str.Replace(sOldStr, sNewStr);
                    LineList.Add(str);
                }
            }
            string[] lines = (string[])LineList.ToArray(typeof(string));
            System.IO.File.WriteAllLines(sTxtFileName, lines, Encoding.Default);

        }

        /// <summary>
        /// 栅格计算器
        /// </summary>
        /// <param name="sExpress"></param>
        /// <param name="sOutRaster"></param>
        public void DoRasterCalculate(string sExpress, string sOutRaster)
        {
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rcl = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            // Create the geoprocessor. 
            Geoprocessor GP = new Geoprocessor();
            GP.OverwriteOutput = true;
            object sev = null;
            try
            {
                rcl.expression = sExpress;
                rcl.output_raster = sOutRaster;
                GP.Execute(rcl, null);
            }
            catch (Exception)
            {
                MessageBox.Show(GP.GetMessages(ref sev), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// ASCIIToRaster
        /// </summary>
        /// <param name="in_ascii_file">输入文件</param>
        /// <param name="sOutRaster">输出栅格</param>
        public void ASCIIToRaster(string in_ascii_file, string sOutRaster)
        {
            ESRI.ArcGIS.ConversionTools.ASCIIToRaster tASC = new ESRI.ArcGIS.ConversionTools.ASCIIToRaster();
            // Create the geoprocessor. 
            Geoprocessor GP = new Geoprocessor();
            GP.OverwriteOutput = true;
            object sev = null;
            try
            {
                tASC.data_type = "INTEGER";
                tASC.in_ascii_file = in_ascii_file;
                tASC.out_raster = sOutRaster;
                GP.Execute(tASC, null);
            }
            catch (Exception)
            {
                MessageBox.Show(GP.GetMessages(ref sev), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 投影栅格
        /// </summary>
        /// <param name="sFile"></param>
        private void SetProjectForTIF(string sFile, ISpatialReference pSpatialReference)
        {
            ESRI.ArcGIS.DataManagementTools.ProjectRaster pr = new ESRI.ArcGIS.DataManagementTools.ProjectRaster();
            // Create the geoprocessor. 
            Geoprocessor GP = GP = new Geoprocessor();
            object sev = null;
            try
            {
                GP.OverwriteOutput = true;
                //输入栅格数据
                pr.in_raster = sFile;
                pr.in_coor_system = pSpatialReference;
                //重命名
                string sTmpFileName = System.IO.Path.GetFileNameWithoutExtension(sFile);
                string sOutnPutFile = System.IO.Path.GetDirectoryName(sFile) + "\\" + sTmpFileName + "_pr.tif";
                //输出栅格数据
                pr.out_raster = sOutnPutFile;
                pr.out_coor_system = pSpatialReference;
                // Execute the tool.
                GP.Execute(pr, null);
                File.Delete(System.IO.Path.GetDirectoryName(sFile) + "\\" + sTmpFileName + ".tfw");
                File.Delete(System.IO.Path.GetDirectoryName(sFile) + "\\" + sTmpFileName + ".tif");
                File.Delete(System.IO.Path.GetDirectoryName(sFile) + "\\" + sTmpFileName + ".tif.aux.xml");
                File.Delete(System.IO.Path.GetDirectoryName(sFile) + "\\" + sTmpFileName + ".tif.ovr");
                File.Delete(System.IO.Path.GetDirectoryName(sFile) + "\\" + sTmpFileName + ".tif.vat.dbf");
                File.Delete(System.IO.Path.GetDirectoryName(sFile) + "\\" + sTmpFileName + ".tif.xml");


            }
            catch (Exception ex)
            {
                MessageBox.Show(GP.GetMessages(ref sev), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        /// <summary>
        /// 获取要素集空间参考
        /// </summary>
        /// <param name="pFeatureDataset"></param>
        /// <returns></returns>
        public static ISpatialReference GetSpatialReference(IFeatureDataset pFeatureDataset)
        {
            IGeoDataset pGeoDataset = pFeatureDataset as IGeoDataset;
            ISpatialReference pSpatialReference = pGeoDataset.SpatialReference;
            return pSpatialReference;
        }

        /// <summary>
        /// 获取指定栅格的空间参考
        /// </summary>
        /// <param name="sRasterFile"></param>
        /// <returns></returns>
        public static ISpatialReference GetRasterSpatialReference(string sRasterFile)
        {
            IWorkspaceFactory pWorkspaceFactory;
            IRasterWorkspace pRasterWorkspace;

            string filePath = System.IO.Path.GetDirectoryName(sRasterFile);
            string fileName = System.IO.Path.GetFileName(sRasterFile);
            pWorkspaceFactory = new RasterWorkspaceFactoryClass();
            pRasterWorkspace = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(filePath, 0);
            IGeoDataset pRasterDataset = (IGeoDataset)pRasterWorkspace.OpenRasterDataset(fileName);
            ISpatialReference pSpatialReference = pRasterDataset.SpatialReference;
            return pSpatialReference;
        }

        /// <summary>
        /// 获取文件夹下指定文件
        /// </summary>
        /// <param name="sPath"></param>
        /// <param name="sFilter"></param>
        /// <returns></returns>
        public static List<string> getAllFileNameFromFolder(string sPath, string sFilter)
        {
            List<string> listNames = new List<string>();
            string[] sFiles = Directory.GetFiles(sPath);
            foreach (var sFile in sFiles)
            {
                string sExtensionName = System.IO.Path.GetExtension(sFile).ToString();
                string sFileName = System.IO.Path.GetFileNameWithoutExtension(sFile);
                if (sExtensionName.Equals(sFilter) && sFileName.Contains("cov1"))
                {
                    listNames.Add(sFile);
                }
            }
            return listNames;
        }

        /// <summary>
        /// 打开栅格
        /// </summary>
        /// <param name="sRasterFile"></param>
        public void OpenRaster(string sRasterFile)
        {
            IWorkspaceFactory pWorkspaceFactory;
            IRasterWorkspace pRasterWorkspace;

            string filePath = System.IO.Path.GetDirectoryName(sRasterFile);
            string fileName = System.IO.Path.GetFileName(sRasterFile);
            pWorkspaceFactory = new RasterWorkspaceFactoryClass();
            pRasterWorkspace = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(filePath, 0);
            IRasterDataset pRasterDataset;
            pRasterDataset = pRasterWorkspace.OpenRasterDataset(fileName);

            //影像金字塔的判断与创建
            IRasterPyramid pRasPyrmid;
            pRasPyrmid = pRasterDataset as IRasterPyramid;

            if (pRasPyrmid != null)
            {
                if (!(pRasPyrmid.Present))
                {
                    pRasPyrmid.Create();
                }
            }

            IRaster pRaster;
            pRaster = pRasterDataset.CreateDefaultRaster();

            IRasterLayer pRasterLayer;
            pRasterLayer = new RasterLayerClass();
            pRasterLayer.CreateFromRaster(pRaster);

            ILayer pLayer = pRasterLayer as ILayer;

            pMap.AddLayer(pLayer);

        }

        /// <summary>
        /// 输出结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_outTransfer_Click(object sender, EventArgs e)
        {
            if (this.txtProjectPath.Equals(" "))
            {
                MessageBox.Show("请选择工程位置路径！");
                return;
            }
            string sOutPut = this.txtProjectPath.Text + "\\RunDLS\\DLS\\Output";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(sOutPut);
            if (di.GetFiles().Length + di.GetDirectories().Length == 0)
            {
                //目录为空
                MessageBox.Show("输出目录为空，请检查DLS模型是否运行完毕！");
                return;
            }

            string sExpress = "";

            List<string> listFiles = getAllFileNameFromFolder(sOutPut,".1");
            this.rtxtState.AppendText("读取输出数据列表...\n");
            this.rtxtState.ScrollToCaret();
            if (listFiles.Count == 0)
            {
                MessageBox.Show("输出目录为空，请检查DLS模型是否运行完毕！");
                return;
            }
            foreach (var file in listFiles)
            {
                string sPartFileName = System.IO.Path.GetFileNameWithoutExtension(file);
                string sOutFileName = sOutPut + "\\" + sPartFileName;
                string sTmpFileName = sOutFileName.Replace("\\\\", "\\");
                string sInputFile = sTmpFileName + ".txt";
                //将扩展名为1的文件扩展名修改为.txt
                File.Move(file, sInputFile);
                this.rtxtState.AppendText("将Ascii转为Txt...\n");
                this.rtxtState.ScrollToCaret();
                string sOld = sPartFileName.Substring(5, 1);
                if (sOld != "0")
                {
                    string sNew = (int.Parse(sOld) + 1).ToString();
                    ReplaceTxt(sInputFile, "1.00", sNew + ".00");
                    this.rtxtState.AppendText("替换栅格中的分类值...\n");
                    this.rtxtState.ScrollToCaret();
                }
                sOutFileName = sTmpFileName + ".tif";
                ASCIIToRaster(sInputFile, sOutFileName);
                this.rtxtState.AppendText("ASCII转栅格...\n");
                this.rtxtState.ScrollToCaret();
                string strMskFile = System.Windows.Forms.Application.StartupPath + "\\Data\\dem.tif";
                //获取参考影像的空间参考
                ISpatialReference pSpatialReference = GetRasterSpatialReference(strMskFile);
                this.rtxtState.AppendText("获取参考影像空间参考...\n");
                this.rtxtState.ScrollToCaret();
                //投影栅格
                SetProjectForTIF(sOutFileName, pSpatialReference);
                this.rtxtState.AppendText("给栅格定义空间参考...\n");
                this.rtxtState.ScrollToCaret();
                File.Delete(sInputFile);
                //栅格计算表达式
                sExpress += " '" + sTmpFileName + "_pr.tif' + ";
            }
            //去除表达式多余后缀
            sExpress = sExpress.Substring(0, sExpress.Length - 2);
            //输出栅格
            string sOutRaster = sOutPut + "\\landuse2020.tif";
            this.rtxtState.AppendText("开始栅格计算...\n");
            this.rtxtState.ScrollToCaret();
            //栅格计算器，将各地类合并
            DoRasterCalculate(sExpress, sOutRaster);
            this.rtxtState.AppendText("栅格计算完毕...\n");
            this.rtxtState.ScrollToCaret();
            //加载到窗体中
            OpenRaster(sOutRaster);
            this.Close();

        }
        int sum1,sum2,sum3;
        string sLandUseDemand;

        private void trackBarBuild_Scroll(object sender, EventArgs e)
        {
            sum1 = 1529 - trackBarBuild.Value;
            trackBarCult.Value = sum1 * 1 / 12;
            trackBarFore.Value = sum1 * 4 / 12;
            trackBarGrass.Value = sum1 * 7 / 12;
            labelCul.Text = trackBarCult.Value.ToString() + " 平方千米";
            labelFor.Text = trackBarFore.Value.ToString() + " 平方千米";
            labelGar.Text = trackBarGrass.Value.ToString() + " 平方千米";
            labelWat.Text = trackBarWater.Value.ToString() + " 平方千米";
            labelBui.Text = trackBarBuild.Value.ToString() + " 平方千米";
        }

        private void trackBarFore_Scroll(object sender, EventArgs e)
        {
            sum2 = sum1 - trackBarFore.Value;
            trackBarCult.Value = sum2 * 1 / 8;
            trackBarGrass.Value = sum2 * 7 / 8;
            labelCul.Text = trackBarCult.Value.ToString() + " 平方千米";
            labelFor.Text = trackBarFore.Value.ToString() + " 平方千米";
            labelGar.Text = trackBarGrass.Value.ToString() + " 平方千米";
            labelWat.Text = trackBarWater.Value.ToString() + " 平方千米";
            labelBui.Text = trackBarBuild.Value.ToString() + " 平方千米";
        }

        private void trackBarGrass_Scroll(object sender, EventArgs e)
        {
            sum3 = sum2 - trackBarGrass.Value;
            trackBarCult.Value = sum3 * 1 / 1;
            labelCul.Text = trackBarCult.Value.ToString() + " 平方千米";
            labelFor.Text = trackBarFore.Value.ToString() + " 平方千米";
            labelGar.Text = trackBarGrass.Value.ToString() + " 平方千米";
            labelWat.Text = trackBarWater.Value.ToString() + " 平方千米";
            labelBui.Text = trackBarBuild.Value.ToString() + " 平方千米";
        }

        private void trackBarCult_Scroll(object sender, EventArgs e)
        {
            labelCul.Text = trackBarCult.Value.ToString() + " 平方千米";
            labelFor.Text = trackBarFore.Value.ToString() + " 平方千米";
            labelGar.Text = trackBarGrass.Value.ToString() + " 平方千米";
            labelWat.Text = trackBarWater.Value.ToString() + " 平方千米";
            labelBui.Text = trackBarBuild.Value.ToString() + " 平方千米";
        }

        private void trackBarWater_Scroll(object sender, EventArgs e)
        {
            trackBarWater.Value = 208;
            labelCul.Text = trackBarCult.Value.ToString() + " 平方千米";
            labelFor.Text = trackBarFore.Value.ToString() + " 平方千米";
            labelGar.Text = trackBarGrass.Value.ToString() + " 平方千米";
            labelWat.Text = trackBarWater.Value.ToString() + " 平方千米";
            labelBui.Text = trackBarBuild.Value.ToString() + " 平方千米";
        }

        private void btn_reductionLandUseDemand_Click(object sender, EventArgs e)
        {
            string sLandUse = "";

            StreamReader sr = new StreamReader("LandUse.txt", System.Text.Encoding.Default);
            try
            {
                //使用StreamReader类来读取文件
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                // 从数据流中读取每一行，直到文件的最后一行
                string strLine = sr.ReadLine();
                while (strLine != null)
                {
                    sLandUse = sLandUse + strLine;
                    strLine = sr.ReadLine();
                }
                //关闭此StreamReader对象
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sr.Close();
            }
            string[] parts = sLandUse.Split(new char[] { ',' });
            lab_nowCuilt.Text = " " + parts[0] + Environment.NewLine + "平方千米";
            lab_nowForest.Text = " " + parts[1] + Environment.NewLine + "平方千米";
            lab_nowGrass.Text = " " + parts[2] + Environment.NewLine + "平方千米";
            lab_nowWater.Text = " " + parts[3] + Environment.NewLine + "平方千米";
            lab_nowBuild.Text = " " + parts[4] + Environment.NewLine + "平方千米";

            string sDemandCuilt = parts[5];
            string sDemandForest = parts[6];
            string sDemandGrass = parts[7];
            string sDemandWater = parts[8];
            string sDemandBuild = parts[9];

            trackBarCult.Value = Convert.ToInt32(sDemandCuilt);
            trackBarFore.Value = Convert.ToInt32(sDemandForest);
            trackBarGrass.Value = Convert.ToInt32(sDemandGrass);
            trackBarWater.Value = Convert.ToInt32(sDemandWater);
            trackBarBuild.Value = Convert.ToInt32(sDemandBuild);

            labelCul.Text = trackBarCult.Value.ToString() + " 平方千米";
            labelFor.Text = trackBarFore.Value.ToString() + " 平方千米";
            labelGar.Text = trackBarGrass.Value.ToString() + " 平方千米";
            labelWat.Text = trackBarWater.Value.ToString() + " 平方千米";
            labelBui.Text = trackBarBuild.Value.ToString() + " 平方千米";



        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            lab_unUsedLand.Text = trackBar1.Value.ToString();
        }


    }
}
