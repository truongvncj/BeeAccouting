USE [master]
GO
/****** Object:  Database [BEE]    Script Date: 1/16/2019 5:51:36 PM ******/
CREATE DATABASE [BEE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'POSM', FILENAME = N'D:\GitHub\SQL\POSM.mdf' , SIZE = 10624KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'POSM_log', FILENAME = N'D:\GitHub\SQL\POSM_log.ldf' , SIZE = 302400KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BEE] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BEE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BEE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BEE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BEE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BEE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BEE] SET ARITHABORT OFF 
GO
ALTER DATABASE [BEE] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BEE] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BEE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BEE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BEE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BEE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BEE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BEE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BEE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BEE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BEE] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BEE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BEE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BEE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BEE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BEE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BEE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BEE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BEE] SET RECOVERY FULL 
GO
ALTER DATABASE [BEE] SET  MULTI_USER 
GO
ALTER DATABASE [BEE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BEE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BEE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BEE] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BEE]
GO
/****** Object:  StoredProcedure [dbo].[calulationCDKT200loai1]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE procedure  [dbo].[calulationCDKT200loai1]
( 
@username nvarchar (225) ,
 @yearchon INT 


)
 
as


begin


		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;

		CREATE TABLE #TempResults
			(
		                       matk Nvarchar(10),
								loainganhan bit, 
                             	machitiet int,
                                tPSNo float,
                                tPSCo float,
								tPsNotruPSco float,
							
			)



		begin
        insert into #TempResults (matk,loainganhan, machitiet, tPSCo, tPSNo )
		SELECT tbl_Socai.TkCo,tbl_Socai.[nganhan], ISNULL(tbl_Socai.MaCTietTKCo, -1), SUM(tbl_Socai.PsCo),'0'
		 FROM  tbl_Socai
		 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY tbl_Socai.TkCo, tbl_Socai.MaCTietTKCo, tbl_Socai.[nganhan]
		end

		
		begin
        insert into #TempResults (matk,loainganhan, machitiet, tPSNo, tPSCo )
		SELECT tbl_Socai.TkNo,tbl_Socai.[nganhan], ISNULL(tbl_Socai.MaCTietTKNo,-1), SUM(tbl_Socai.PsNo),'0'
		 FROM  tbl_Socai
		 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY tbl_Socai.TkNo, tbl_Socai.MaCTietTKNo, tbl_Socai.[nganhan]
		end
		

		IF OBJECT_ID(N'tempdb..#TempResults2', N'U') IS NOT NULL 
        DROP TABLE #TempResults2;

		CREATE TABLE #TempResults2
			(
		                       matk Nvarchar(10),
								loainganhan bit, 
                             	machitiet int,
                                tPSNo float,
                                tPSCo float,
								tPsNotruPSco float,
							
			)


	   begin
        insert into #TempResults2 (matk,loainganhan, machitiet, tPSNo, tPSCo, tPsNotruPSco)
		SELECT #TempResults.matk,#TempResults.loainganhan, #TempResults.machitiet, SUM(#TempResults.tPSNo),SUM(#TempResults.tPSCo) , SUM(#TempResults.tPSNo)- SUM(#TempResults.tPSCo)
		 FROM  #TempResults
	--	 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY #TempResults.matk , #TempResults.machitiet ,#TempResults.loainganhan
		end






	BEGIN  -- udate baocaos ke toan

				begin
				delete RPtdetailCDKT200lientuc
				where RPtdetailCDKT200lientuc.username = @username

				end
				   
    END
   
    begin
        insert into RPtdetailCDKT200lientuc (username )
		values (@username )
		 --FROM RPtdetailKQKD200 
	--   where tbl_Socai.Ngayctu >=@fromdate and  tbl_Socai.Ngayctu <= @todate
	--   group by  tbl_Socai.TkNo --tbl_Socai.TkCo,
		end


BEGIN
  UPDATE  RPtdetailCDKT200lientuc
         SET 
		
	RPtdetailCDKT200lientuc.cn111tien = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '111' 
						 or left(#TempResults2.matk,3) =  '112' 
						 	 or left(#TempResults2.matk,3) =  '113') )  ,0),

RPtdetailCDKT200lientuc.cn112tientduong = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1281' 
						 or left(#TempResults2.matk,4) =  '1288' ) and
							#TempResults2.loainganhan ='1')  ,0),

RPtdetailCDKT200lientuc.cn121chungkhoan = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '121' 
						 ) and
							#TempResults2.loainganhan ='1')  ,0)	,												


RPtdetailCDKT200lientuc.cn122ckduphong = - isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2291' 
						 ) and
							#TempResults2.loainganhan ='1')  ,0)	,	
																		
RPtdetailCDKT200lientuc.cn123dtdenngay = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1281' 
						or left(#TempResults2.matk,4) =  '1282' 
							or left(#TempResults2.matk,4) =  '1288' 
						 ) )  ,0)													

							- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1281' 
						 or left(#TempResults2.matk,4) =  '1288' ) and
							#TempResults2.loainganhan ='1')  ,0) ,


RPtdetailCDKT200lientuc.cn131ptkhach = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '131' 
						and #TempResults2.tPsNotruPSco > 0
						
						 ) and 
							#TempResults2.loainganhan ='1')  ,0)	,	


RPtdetailCDKT200lientuc.cn132tratruoc = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '331' 
						and #TempResults2.tPsNotruPSco > 0
						
						 ) and 
							#TempResults2.loainganhan ='1')  ,0)	,	


RPtdetailCDKT200lientuc.cn133pthunbnganh = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1362' 
						 or left(#TempResults2.matk,4) =  '1363' 
						  or left(#TempResults2.matk,4) =  '1368' 
						  )
						and #TempResults2.tPsNotruPSco > 0
						
						  and 
							#TempResults2.loainganhan ='1')  ,0)	,	

RPtdetailCDKT200lientuc.cn134pthutiendokh = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '337' 
						
						  )
						and #TempResults2.tPsNotruPSco > 0
						
						)  ,0)	,	

RPtdetailCDKT200lientuc.cn135pthuchovay = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1283' 
						
						  )
						and #TempResults2.tPsNotruPSco > 0
						
						  and 
							#TempResults2.loainganhan ='1')  ,0)	,	


RPtdetailCDKT200lientuc.cn136ptnganhan = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1385' 
					or	left(#TempResults2.matk,4) =  '1388' 
					or	left(#TempResults2.matk,3) =  '334' 
						or	left(#TempResults2.matk,3) =  '338' 
							or	left(#TempResults2.matk,3) =  '141' 
								or	left(#TempResults2.matk,3) =  '244' 
						  )
						and #TempResults2.tPsNotruPSco > 0
						
						  and 
							#TempResults2.loainganhan ='1')  ,0)		,

	RPtdetailCDKT200lientuc.cn137dpptnganhan = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2293' 
						
						  )

						and #TempResults2.tPsNotruPSco < 0
							
						  and 
							#TempResults2.loainganhan ='1')  ,0)	,


	RPtdetailCDKT200lientuc.cn139tsthieucho = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1381' 
						
						  )

						and #TempResults2.tPsNotruPSco < 0
						
						)  ,0)	,


	RPtdetailCDKT200lientuc.cn141hangton = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '151' 
						 or left(#TempResults2.matk,3) =  '152' 
							 or left(#TempResults2.matk,3) =  '153' 
							 	 or left(#TempResults2.matk,3) =  '154' 
								 	 or left(#TempResults2.matk,3) =  '155' 
									 	 or left(#TempResults2.matk,3) =  '156' 
										  or left(#TempResults2.matk,3) =  '157' 
						  )

						and #TempResults2.tPsNotruPSco > 0
						
						)  ,0)	,						
								
	RPtdetailCDKT200lientuc.cn151cftratruoc = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '242' 
					
						  )

						and #TempResults2.tPsNotruPSco > 0
						
						)  ,0)	,
						
	RPtdetailCDKT200lientuc.cn152vatkhautru = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '133' 
					
						  )

						and #TempResults2.tPsNotruPSco > 0
						
						)  ,0)	,
						
	RPtdetailCDKT200lientuc.cn153thuepthukac = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '333' 
					
						  )

						and #TempResults2.tPsNotruPSco > 0
							and #TempResults2.machitiet is not null 
						)  ,0)	,								
						
	RPtdetailCDKT200lientuc.cn154traiphieu = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '171' 
					
						  )

						and #TempResults2.tPsNotruPSco > 0
					
						)  ,0)	,	
													
	RPtdetailCDKT200lientuc.cn155tskhacnh = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2288' 
					
						  )

						and #TempResults2.tPsNotruPSco > 0
						
							  and 
							#TempResults2.loainganhan ='1'
						)  ,0)		,
						
RPtdetailCDKT200lientuc.cn211ptkhach = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '131' 
						and #TempResults2.tPsNotruPSco > 0
							
						 ) and 
							#TempResults2.loainganhan ='0')  ,0)	,	
						
						
RPtdetailCDKT200lientuc.cn212tratruocdh = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '331' 
						and #TempResults2.tPsNotruPSco > 0
							
						 ) and 
							#TempResults2.loainganhan ='0')  ,0)	,	
												
RPtdetailCDKT200lientuc.cn213vonodonvi = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1361' 
						and #TempResults2.tPsNotruPSco > 0
							
						 ) )  ,0)	,	
												
											
RPtdetailCDKT200lientuc.cn214pthunbo = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1362' 
						 or left(#TempResults2.matk,4) =  '1363' 
						  or left(#TempResults2.matk,4) =  '1368' 
						and #TempResults2.tPsNotruPSco > 0
							
						 ) and 
							#TempResults2.loainganhan ='0')  ,0)	,	
							
							
RPtdetailCDKT200lientuc.cn215pthuchovay = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1283' 
						
						and #TempResults2.tPsNotruPSco > 0
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	,	
														
					
RPtdetailCDKT200lientuc.cn216pthukhac = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1285' 
						or left(#TempResults2.matk,4) =  '1288' 
					or	left(#TempResults2.matk,3) =  '334' 
						or left(#TempResults2.matk,3) =  '338' 
							or left(#TempResults2.matk,3) =  '141' 
								or left(#TempResults2.matk,3) =  '244' 
						and #TempResults2.tPsNotruPSco > 0
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	,	
														
							
RPtdetailCDKT200lientuc.cn219duphongpt = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2293' 
						
						and #TempResults2.tPsNotruPSco > 0
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0) 	,
							
							
							
RPtdetailCDKT200lientuc.cn222tscdngia = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '211' 
						
						and #TempResults2.tPsNotruPSco > 0
							
						 ))  ,0) 		,
						 
							
RPtdetailCDKT200lientuc.cn223tskhauh = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2141' 
						
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0) 	,

RPtdetailCDKT200lientuc.cn225tscdthung = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '212' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)	,						
							
RPtdetailCDKT200lientuc.cn226tscdthuekha = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2142' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)			,
						 
RPtdetailCDKT200lientuc.cn228tscdvohnggia = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '213' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)	,					 				
			
RPtdetailCDKT200lientuc.cn229tscdvhkhauh = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2143' 
						
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	,					 				
						
RPtdetailCDKT200lientuc.cn231bdsngia = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '217' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)		,
						
RPtdetailCDKT200lientuc.cn232bdshaomon = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2147' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)		,

RPtdetailCDKT200lientuc.cn241cfkddd = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2294' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	,
							
RPtdetailCDKT200lientuc.cn242cfxddd = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '241' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)	,
						 
RPtdetailCDKT200lientuc.cn251dtuctycon = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '221' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)	,
						 
RPtdetailCDKT200lientuc.cn252dtuctylienket = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '222' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)		,
						 
RPtdetailCDKT200lientuc.cn253dtukhac = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2281' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)			,
						 
RPtdetailCDKT200lientuc.cn254duphongdt =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2292' 
						
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	,
						 
RPtdetailCDKT200lientuc.cn255dtudaohan = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1281' 
					or	left(#TempResults2.matk,4) =  '1282' 
						or	left(#TempResults2.matk,4) =  '1288' 
						

						and #TempResults2.tPsNotruPSco >0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	,

						
	RPtdetailCDKT200lientuc.cn261cftratruocdn = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '242' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)	,
							
	RPtdetailCDKT200lientuc.cn262thuetndnhl = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '243' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)	,
						 
	RPtdetailCDKT200lientuc.cn263vtuthietbidn = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '1534' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)							 						
													 						 				 					 														 						 				 				
						+
						isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2294' 
						
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)		,
							
RPtdetailCDKT200lientuc.cn268tskhac = isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '2288' 
						
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)	,							
														 														 						 				 				
	
RPtdetailCDKT200lientuc.cn311ptnbannh = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '311' 
						
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='1')  ,0)	,

RPtdetailCDKT200lientuc.cn312ngmuatratr = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '131' 
						
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='1')  ,0)	,
							
							
RPtdetailCDKT200lientuc.cn313thuephainop =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '333' 
						
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	,
							
							--and 							#TempResults2.loainganhan ='1'
RPtdetailCDKT200lientuc.cn314ptracnhan = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '334' 
						
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='1')  ,0)	,

					
RPtdetailCDKT200lientuc.cn315cphiptranh = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '335' 
						
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='1')  ,0)		,
							
							
												
RPtdetailCDKT200lientuc.cn316cfptranbonh = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,4) =  '3362' 
					or	left(#TempResults2.matk,4) =  '3363' 
							or	left(#TempResults2.matk,4) =  '3368' )

						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='1')  ,0)		,														
														 														
														 																						
RPtdetailCDKT200lientuc.cn317ptrtheoluong = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,3) =  '337' 
						
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='1')  ,0)		,														 														
														 																		
														 																						
RPtdetailCDKT200lientuc.cn318pthuchunhan = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where (left(#TempResults2.matk,4) =  '3387 ' 
						
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='1')  ,0)	,															 														
														 																		
																			 																						
RPtdetailCDKT200lientuc.cn319ptranhan = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '338' 
					or	left(#TempResults2.matk,3) =  '138'
							or	left(#TempResults2.matk,3) =  '344'
					
					 )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='1')  ,0)	,


																										 																						
RPtdetailCDKT200lientuc.cn320vaynotcnhan =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '341' 
					or	left(#TempResults2.matk,5) =  '34311' )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	,


																										 																						
RPtdetailCDKT200lientuc.cn321duphptranh = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '352' 
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='1')  ,0)	,



																										 																						
RPtdetailCDKT200lientuc.cn322quykhen = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '353' 
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	,

							
				
																										 																						
RPtdetailCDKT200lientuc.cn323quygia = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '357' 
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0  ),

			
																										 																						
RPtdetailCDKT200lientuc.cn324bantraiphieu =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '171' 
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0 )	,

RPtdetailCDKT200lientuc.cn331nodnngban = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '331' 
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	,

		
RPtdetailCDKT200lientuc.cn332ngmuatratdn = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '131' 
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	,  


RPtdetailCDKT200lientuc.cn333cphiphaitra = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '335' 
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	,  


		
RPtdetailCDKT200lientuc.cn334ptranbvevon =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,4) =  '3361' 
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	,  
																
							
		
RPtdetailCDKT200lientuc.cn335ptranbdaihan =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,4) =  '3362' 
						 or left(#TempResults2.matk,4) =  '3363' 
						or left(#TempResults2.matk,4) =  '3368' 
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	,  
									
				
		
RPtdetailCDKT200lientuc.cn336dthuchthdn =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,4) =  '3387' 
						
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	,  
									

			
RPtdetailCDKT200lientuc.cn337ptradnkhac = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '338' 
				or		left(#TempResults2.matk,3) =  '334' 
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	  ,
				--	Dư Có chi tiết TK 341 và
--Dư Có TK 34311 trừ (-) dư Nợ TK
-- 34312 cộng (+) dư Có TK 34313.			
			
RPtdetailCDKT200lientuc.cn338vaynodn = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '341' 
						
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	
					+		isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,5) =  '34311' 
						
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)  
					-		isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,5) =  '34312' 
						
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)
					+	isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,5) =  '34313' 
						
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)  ,						
							
	
			
RPtdetailCDKT200lientuc.cn339traiphieu =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,4) =  '34312' 
			
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	  ,						
																					 											
	
RPtdetailCDKT200lientuc.cn340cophieu = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,4) =  '41112' 
			
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	  ,
							
							
				
RPtdetailCDKT200lientuc.cn341tnhoanlai = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '347' 
			
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	  ,						
																					 											
	
RPtdetailCDKT200lientuc.cn342duphongdn =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '352' 
			
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 )and 
							#TempResults2.loainganhan ='0')  ,0)	  ,						
													
	
RPtdetailCDKT200lientuc.cn343quykhoahoc =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '356' 
			
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	 ,
						 
						 
						 								
	
RPtdetailCDKT200lientuc.cn411vongopcsh = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '411' 
			
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	  		,		
		 								
	
RPtdetailCDKT200lientuc.cn411acophieupt =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,5) =  '41111' 
			
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	  		,

RPtdetailCDKT200lientuc.cn411bcpudai =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,5) =  '41112' 
			
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	  		,
						 

RPtdetailCDKT200lientuc.cn412thangduvon = - isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,4) =  '4112' 
			
			
					     )
						and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)		,					 				 		
											
											
			
RPtdetailCDKT200lientuc.cn413traiphieu = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,4) =  '4113' 
			
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)			,
						 
						 
RPtdetailCDKT200lientuc.cn414voncshkhac = - isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,4) =  '4118' 
			
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	,
						 

RPtdetailCDKT200lientuc.cn415cphieuquy =  isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '419' 
			
			
					     )
						and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)			,
						 


RPtdetailCDKT200lientuc.cn416chenhlechts =  isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '416' 
			
			
					     )
					--	and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	,
						 


RPtdetailCDKT200lientuc.cn417tygia =-  isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '413' 
			
			
					     )
					--	and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	,
						 
						 

RPtdetailCDKT200lientuc.cn418dautuptrien =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '414' 
			
			
					     )
			         	and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	,
						 

RPtdetailCDKT200lientuc.cn419quyxxdn =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '417' 
			
			
					     )
			         	and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)		,				 						 									
														 									
																 							
			
RPtdetailCDKT200lientuc.cn420quykhacsh = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '418' 
			
			
					     )
			         	and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)		,
						 
						 									 							
			
RPtdetailCDKT200lientuc.cn421lnsauthue = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '421' 
			
			
					     )
			        -- 	and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)			,
						 
						 
						  									 							
			
RPtdetailCDKT200lientuc.cn421alnkytruoc =- isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,4) =  '4211' 
			
			
					     )
			     --   	and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)		,
						 
						 									 							
			
RPtdetailCDKT200lientuc.cn421blnkynay = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,4) =  '4212' 
			
			
					     )
			        --	and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)		,
						 
						 								 							
			
RPtdetailCDKT200lientuc.cn422vonxdcb = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '441' 
			
			
					     )
			       	and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)		,
						 
						 
RPtdetailCDKT200lientuc.cn431nkinhphi = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '461' 
			
			
					     )
			       	and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	
						 -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '161' 
			
			
					     )
			       	and #TempResults2.tPsNotruPSco >0 
							
						 ))  ,0)	,
						 
						 
		
RPtdetailCDKT200lientuc.cn432kpthanhtscd = -isnull( (select sum(#TempResults2.tPsNotruPSco) from #TempResults2 
                         where ((left(#TempResults2.matk,3) =  '466' 
			
			
					     )
			       	and #TempResults2.tPsNotruPSco <0 
							
						 ))  ,0)	,					 								 						 									
													 						 									
																					 									
	RPtdetailCDKT200lientuc.dn111tien = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 
						 
						 and CDKT200Dauky.Machitieu= 111
						 
						           )  ,0)	,
								   
								   
								   																				 									
	RPtdetailCDKT200lientuc.dn112tientduong = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 112
						 
						           )  ,0)	,
							   																				 									
	RPtdetailCDKT200lientuc.dn121chungkhoan = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 121
						 
						           )  ,0)		,								   								
																				
RPtdetailCDKT200lientuc.dn122ckduphong = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 122
						 
						           )  ,0)	,																					 				
																				
RPtdetailCDKT200lientuc.dn123dtdenngay = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 123
						 
						           )  ,0)	,
																				
RPtdetailCDKT200lientuc.dn131ptkhach = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 131
						 
						           )  ,0)	,	
RPtdetailCDKT200lientuc.dn132tratruoc = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 132
						 
						           )  ,0)	,	
RPtdetailCDKT200lientuc.dn133pthunbnganh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 133
						 
						           )  ,0)	,									   								   								   																					 				
RPtdetailCDKT200lientuc.dn134pthutiendokh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 134
						 
						           )  ,0)	,	
RPtdetailCDKT200lientuc.dn135pthuchovay = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 135
						 
						           )  ,0)	,	
RPtdetailCDKT200lientuc.dn136ptnganhan = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 136
						 
						           )  ,0)	,		
RPtdetailCDKT200lientuc.dn137dpptnganhan = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 137
						 
						           )  ,0)	,	
RPtdetailCDKT200lientuc.dn139tsthieucho = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 139
						 
						           )  ,0)	,	
								   
RPtdetailCDKT200lientuc.dn141hangton = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 141
						 
						           )  ,0)	,	

RPtdetailCDKT200lientuc.dn149duphonght = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 131
						 
						           )  ,0)	,
								   

RPtdetailCDKT200lientuc.dn151cftratruoc = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 151
						 
						           )  ,0)	,

RPtdetailCDKT200lientuc.dn152vatkhautru = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 152
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn153thuepthukac = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 153
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn154traiphieu = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 154
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn155tskhacnh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 155
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn211ptkhach = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 211
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn212tratruocdh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 212
						 
						           )  ,0),

RPtdetailCDKT200lientuc.dn213vonodonvi = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 213
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn214pthunbo = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 214
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn215pthuchovay = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 215
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn216pthukhac = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 216
						 
						           )  ,0)	,

RPtdetailCDKT200lientuc.dn219duphongpt = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 219
						 
						           )  ,0)		,
								   


RPtdetailCDKT200lientuc.dn222tscdngia = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 222
						 
						           )  ,0)		,
								
RPtdetailCDKT200lientuc.dn223tskhauh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 223
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn225tscdthung = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 225
						 
						           )  ,0)		,
								 
RPtdetailCDKT200lientuc.dn226tscdthuekha = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 226
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn228tscdvohnggia = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 228
						 
						           )  ,0)		,
								   
								   
RPtdetailCDKT200lientuc.dn229tscdvhkhauh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 229
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn231bdsngia = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 231
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn232bdshaomon = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 232
						 
						           )  ,0)		,
								   
								   
RPtdetailCDKT200lientuc.dn241cfkddd = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 241
						 
						           )  ,0)		,
								   

RPtdetailCDKT200lientuc.dn242cfxddd = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 242
						 
						           )  ,0)		,
								   
								   
RPtdetailCDKT200lientuc.dn251dtuctycon = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 251
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn252dtuctylienket = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 252
						 
						           )  ,0)		,
								   
								   
RPtdetailCDKT200lientuc.dn253dtukhac = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 253
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn254duphongdt = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 254
						 
						           )  ,0)		,
								   

RPtdetailCDKT200lientuc.dn255dtudaohan = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 255
						 
						           )  ,0)		,
								   
								   
RPtdetailCDKT200lientuc.dn261cftratruocdn = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 261
						 
						           )  ,0)		,
								   
								   
RPtdetailCDKT200lientuc.dn262thuetndnhl = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 262
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn263vtuthietbidn = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 263
						 
						           )  ,0)		,
								   
								   
RPtdetailCDKT200lientuc.dn268tskhac = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 268
						 
						           )  ,0)		,
								 

RPtdetailCDKT200lientuc.dn311ptnbannh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 311
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn312ngmuatratr = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 312
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn313thuephainop = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 313
						 
						           )  ,0)	,

RPtdetailCDKT200lientuc.dn314ptracnhan = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 314
						 
						           )  ,0)	,

RPtdetailCDKT200lientuc.dn315cphiptranh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 315
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn316cfptranbonh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 316
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn317ptrtheoluong = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 317
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn318pthuchunhan = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 318
						 
						           )  ,0)	,

RPtdetailCDKT200lientuc.dn319ptranhan = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 319
						 
						           )  ,0)		,


								   
RPtdetailCDKT200lientuc.dn320vaynotcnhan = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 320
						 
						           )  ,0)		,


RPtdetailCDKT200lientuc.dn321duphptranh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 321
						 
						           )  ,0)		,

								   
RPtdetailCDKT200lientuc.dn322quykhen = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 322
						 
						           )  ,0)		,

								   
RPtdetailCDKT200lientuc.dn323quygia = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 323
						 
						           )  ,0)		,

								   
RPtdetailCDKT200lientuc.dn324bantraiphieu = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 324
						 
						           )  ,0)		,


RPtdetailCDKT200lientuc.dn331nodnngban = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 331
						 
						           )  ,0)		,


RPtdetailCDKT200lientuc.dn332ngmuatratdn = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 332
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn333cphiphaitra = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 333
						 
						           )  ,0)		,

								   
RPtdetailCDKT200lientuc.dn334ptranbvevon = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 334
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn335ptranbdaihan = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 335
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn336dthuchthdn = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 336
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn337ptradnkhac = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 337
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn338vaynodn = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 338
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn339traiphieu = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 339
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn340cophieu = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 340
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn341tnhoanlai = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 341
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn342duphongdn = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 342
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn343quykhoahoc = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 343
						 
						           )  ,0)		,
								   


RPtdetailCDKT200lientuc.dn411acophieupt = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 4111
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn411bcpudai = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 4112
						 
						           )  ,0)	,
								   
RPtdetailCDKT200lientuc.dn411vongopcsh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 411
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn412thangduvon = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 412
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn413traiphieu = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 413
						 
						           )  ,0)		,

RPtdetailCDKT200lientuc.dn414voncshkhac = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 414
						 
						           )  ,0)	,

RPtdetailCDKT200lientuc.dn415cphieuquy = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 415
						 
						           )  ,0)			,
								   
RPtdetailCDKT200lientuc.dn416chenhlechts = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 416
						 
						           )  ,0)		,
								   
RPtdetailCDKT200lientuc.dn417tygia = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 417
						 
						           )  ,0)			,

RPtdetailCDKT200lientuc.dn418dautuptrien = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 418
						 
						           )  ,0)				,

RPtdetailCDKT200lientuc.dn419quyxxdn = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 419
						 
						           )  ,0),								   						   	

RPtdetailCDKT200lientuc.dn420quykhacsh = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 420
						 
						           )  ,0)	,

RPtdetailCDKT200lientuc.dn421alnkytruoc = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 4211
						 
						           )  ,0)			,								   	
								   
RPtdetailCDKT200lientuc.dn421blnkynay = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 4212
						 
						           )  ,0)			,
								   
RPtdetailCDKT200lientuc.dn421lnsauthue = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 415
						 
						           )  ,0)			,
								   
RPtdetailCDKT200lientuc.dn422vonxdcb = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 422
						 
						           )  ,0)			,
								   
RPtdetailCDKT200lientuc.dn431nkinhphi = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 431
						 
						           )  ,0)			,
								   
RPtdetailCDKT200lientuc.dn432kpthanhtscd = 	isnull( (select sum(CDKT200Dauky.Sotien) from CDKT200Dauky 
                         where    CDKT200Dauky.nam =@yearchon
						 			 
						 and CDKT200Dauky.Machitieu= 432
						 
						           )  ,0)								   	
								   													   	
								   													   	
								   									   		
								   									   										   										   									   									   									   											   									   									   									   									   									   										   									   								   								   								   							   								   																																																 																																	
																									 
     from RPtdetailCDKT200lientuc
	
	where RPtdetailCDKT200lientuc.username = @username
		

      end



		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;

		
		IF OBJECT_ID(N'tempdb..#TempResults2', N'U') IS NOT NULL 
        DROP TABLE #TempResults2;


	END

	



GO
/****** Object:  StoredProcedure [dbo].[calulationCDKTtemp200]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE procedure  [dbo].[calulationCDKTtemp200]
( 
 @username nvarchar (225) ,
 @yearchon INT 


)
 
as


begin


		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;

		CREATE TABLE #TempResults
			(
		                       matk Nvarchar(10),
								loainganhan bit, 
                             	machitiet int,
								tenchitiet Nvarchar(225),
                                tPSNo float,
                                tPSCo float,
								tPsNotruPSco float,
							
			)



		begin
        insert into #TempResults (matk,loainganhan, machitiet, tPSCo, tPSNo )
		SELECT tbl_Socai.TkCo,tbl_Socai.[nganhan], ISNULL(tbl_Socai.MaCTietTKCo, -1), SUM(tbl_Socai.PsCo),'0'
		 FROM  tbl_Socai
		 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY tbl_Socai.TkCo, tbl_Socai.MaCTietTKCo, tbl_Socai.[nganhan]
		end

		
		begin
        insert into #TempResults (matk,loainganhan, machitiet, tPSNo, tPSCo )
		SELECT tbl_Socai.TkNo,tbl_Socai.[nganhan], ISNULL(tbl_Socai.MaCTietTKNo,-1), SUM(tbl_Socai.PsNo),'0'
		 FROM  tbl_Socai
		 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY tbl_Socai.TkNo, tbl_Socai.MaCTietTKNo, tbl_Socai.[nganhan]
		end
		
		begin -- xoa data cùng username trong  RptPhatsinhcdkt200
		delete from RptPhatsinhcdkt200
		where RptPhatsinhcdkt200.username =@username

		end


		begin
		update #TempResults

		set 
		#TempResults.tenchitiet = isnull( ( SELECT   tbl_machitiettk.tenchitiet
											 FROM  tbl_machitiettk
									where tbl_machitiettk.machitiet = #TempResults.machitiet 
									      and tbl_machitiettk.matk = #TempResults.matk 
									),'')
		 from #TempResults

		end


	   begin
        insert into RptPhatsinhcdkt200 (matk,loainganhan, machitiet, tenchitiet, tPSNo, tPSCo, tPsNotruPSco, username )
		SELECT #TempResults.matk,#TempResults.loainganhan, #TempResults.machitiet, max(#TempResults.tenchitiet), SUM(#TempResults.tPSNo),SUM(#TempResults.tPSCo) , SUM(#TempResults.tPSNo)- SUM(#TempResults.tPSCo),@username
		 FROM  #TempResults
	--	 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY #TempResults.matk , #TempResults.machitiet ,#TempResults.loainganhan
		end





   



		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;

		

	END

	



GO
/****** Object:  StoredProcedure [dbo].[calulationCDphatsinh200]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE procedure  [dbo].[calulationCDphatsinh200]
( 
@username nvarchar (225) ,
 @yearchon INT 


)
 
as


begin


		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;

		CREATE TABLE #TempResults
			(
		                        matk Nvarchar(10),
							
							
                             	machitiet int,
									tenchitiet  Nvarchar(225),
                                tPSNo float,
                                tPSCo float,
								tPsNotruPSco float,
							
			)



		begin
        insert into #TempResults (matk, machitiet, tenchitiet, tPSCo, tPSNo )
		SELECT tbl_Socai.TkCo, ISNULL(tbl_Socai.MaCTietTKCo, -1), tbl_Socai.tenchitietCo , SUM(tbl_Socai.PsCo),'0'
		 FROM  tbl_Socai
		 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY tbl_Socai.TkCo, tbl_Socai.MaCTietTKCo, tbl_Socai.tenchitietCo
		end

		
		begin
        insert into #TempResults (matk, machitiet,tenchitiet, tPSNo, tPSCo )
		SELECT tbl_Socai.TkNo, ISNULL(tbl_Socai.MaCTietTKNo,-1), tbl_Socai.tenchitietNo , SUM(tbl_Socai.PsNo),'0'
		 FROM  tbl_Socai
		 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY tbl_Socai.TkNo, tbl_Socai.MaCTietTKNo, tbl_Socai.tenchitietNo
		end
		

		IF OBJECT_ID(N'tempdb..#TempResults2', N'U') IS NOT NULL 
        DROP TABLE #TempResults2;

		CREATE TABLE #TempResults2
			(
		                       matk Nvarchar(10),
							  
								loainganhan bit, 
                             	machitiet int,
									tenchitiet  Nvarchar(225),
                                tPSNo float,
                                tPSCo float,
								tPsNotruPSco float,
							
			)


	   begin
        insert into #TempResults2 (matk, machitiet,tenchitiet, tPSNo, tPSCo, tPsNotruPSco)
		SELECT #TempResults.matk, #TempResults.machitiet, #TempResults.tenchitiet, SUM(#TempResults.tPSNo),SUM(#TempResults.tPSCo) , SUM(#TempResults.tPSNo)- SUM(#TempResults.tPSCo)
		 FROM  #TempResults
	--	 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY #TempResults.matk , #TempResults.machitiet ,#TempResults.tenchitiet
		end




	BEGIN  -- udate baocaos ke toan

				begin
				delete RptPhatsinhcdkt200
				where RptPhatsinhcdkt200.username = @username

				end
				   
    END
   


    begin
        insert into RptPhatsinhcdkt200 (username,matk,machitiet,tenchitiet,tPSCo,tPSNo,tPsNotruPSco )
		select @username,  #TempResults2.matk, #TempResults2.machitiet, #TempResults2.tenchitiet,#TempResults2.tPSCo,#TempResults2.tPSNo,#TempResults2.tPsNotruPSco
		from #TempResults2 
	   where #TempResults2.tPSCo <> 0 or #TempResults2.tPSNo <> 0
	  --  group by  tbl_Socai.TkNo --tbl_Socai.TkCo,
	end





BEGIN
  UPDATE  RptPhatsinhcdkt200
         SET  RptPhatsinhcdkt200.tentk = tbl_dstaikhoan.tentk
		 
			   									   										   										   									   									   									   											   									   									   									   									   									   										   									   								   								   								   							   								   																																																 																																	
																									 
     from tbl_dstaikhoan
	
	where tbl_dstaikhoan.matk  = RptPhatsinhcdkt200.matk
		

      end



		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;

		
		IF OBJECT_ID(N'tempdb..#TempResults2', N'U') IS NOT NULL 
        DROP TABLE #TempResults2;


	END

	



GO
/****** Object:  StoredProcedure [dbo].[calulationCDPStoRptdetaiCDP]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE procedure  [dbo].[calulationCDPStoRptdetaiCDP]
( 
@username nvarchar (225) ,
 @yearchon INT 


)
 
as


begin


		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;

		CREATE TABLE #TempResults
			(
		                        matk Nvarchar(10),
							
							
                             --	machitiet int,
								--	tenchitiet  Nvarchar(225),
                                tPSNo float,
                                tPSCo float,
							--	tPsNotruPSco float,
							
			)



		begin
        insert into #TempResults (matk,   tPSCo, tPSNo )
		SELECT tbl_Socai.TkCo,  SUM(tbl_Socai.PsCo),'0'
		 FROM  tbl_Socai
		 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY tbl_Socai.TkCo
		end

		
		begin
        insert into #TempResults (matk,  tPSNo, tPSCo )
		SELECT tbl_Socai.TkNo, SUM(tbl_Socai.PsNo),'0'
		 FROM  tbl_Socai
		 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY tbl_Socai.TkNo
		end
		

		IF OBJECT_ID(N'tempdb..#TempResults2', N'U') IS NOT NULL 
        DROP TABLE #TempResults2;

		CREATE TABLE #TempResults2
			(
		                       matk Nvarchar(10),
							  
                                tPSNo float,
                                tPSCo float,
							
							
			)


	   begin
        insert into #TempResults2 (matk, tPSNo, tPSCo)
		SELECT #TempResults.matk,  SUM(#TempResults.tPSNo),SUM(#TempResults.tPSCo) 
		 FROM  #TempResults
	--	 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
	     GROUP BY #TempResults.matk 
		end




	BEGIN  -- udate baocaos ke toan

				begin
				delete RptdetaiCDPS
				where RptdetaiCDPS.username = @username

				end
				   
    END
   


    begin
        insert into RptdetaiCDPS (username,matk,tentk , Codk, Nodk)
		select @username,  tbl_dstaikhoan.matk, tbl_dstaikhoan.tentk,sum(isnull(tbl_dstaikhoan.codk,0)), sum(isnull(tbl_dstaikhoan.nodk,0))
			from tbl_dstaikhoan 

	 --  where #TempResults2.tPSCo <> 0 or #TempResults2.tPSNo <> 0
	      group by  tbl_dstaikhoan.matk, tbl_dstaikhoan.tentk --tbl_Socai.TkCo,
	end





BEGIN
  UPDATE  RptdetaiCDPS
         SET  RptdetaiCDPS.Psco = #TempResults2.tPSCo,
		  RptdetaiCDPS.Psno = #TempResults2.tPSNo
			
				 																					 
     from #TempResults2
	
	where #TempResults2.matk  = RptdetaiCDPS.matk
		

      end


BEGIN
  UPDATE  RptdetaiCDPS
    --     SET  RptdetaiCDPS.Cock = RptdetaiCDPS.Cock + RptdetaiCDPS.Psco,
		  --RptdetaiCDPS.Nock = RptdetaiCDPS.Nodk + RptdetaiCDPS.Psno
			SET 
  RptdetaiCDPS.Cock = CASE WHEN isnull(RptdetaiCDPS.Nodk,0) + isnull(RptdetaiCDPS.Psno,0) < = isnull(RptdetaiCDPS.Cock,0) + isnull(RptdetaiCDPS.Psco,0)  THEN isnull(RptdetaiCDPS.Cock,0) + isnull(RptdetaiCDPS.Psco,0) - isnull(RptdetaiCDPS.Nodk ,0) - isnull(RptdetaiCDPS.Psno,0)  ELSE 0 END,
  RptdetaiCDPS.Nock = CASE WHEN isnull(RptdetaiCDPS.Nodk,0) + isnull(RptdetaiCDPS.Psno,0) > isnull(RptdetaiCDPS.Cock,0) + isnull(RptdetaiCDPS.Psco,0)  THEN -isnull(RptdetaiCDPS.Cock,0) - isnull(RptdetaiCDPS.Psco,0) +isnull(RptdetaiCDPS.Nodk ,0) + isnull(RptdetaiCDPS.Psno,0)  ELSE 0 END
  
				 																					 
     from RptdetaiCDPS
	
	
		

      end


		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;

		
		IF OBJECT_ID(N'tempdb..#TempResults2', N'U') IS NOT NULL 
        DROP TABLE #TempResults2;


	END

	



GO
/****** Object:  StoredProcedure [dbo].[calulationKQKD200]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure  [dbo].[calulationKQKD200]
( 
@username nvarchar (225) ,
 @yearchon INT 


)
 
as


begin


		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;

		CREATE TABLE #TempResults
			(
		                      matk Nvarchar(10),
                                PSNo float,
                                PSCo float,
                                 --    TkCo float,
                                 --Litter float,
                                 --  GSR float,
                                 -- NSR float,
			
			)


---- tinh phat sinh trong nam --  tao tem roi cong vao
--		begin
--        insert into #TempResults (matk,PSNo,PSCo )
--		SELECT tbl_dstaikhoan.[matk], '0','0' 
--		 FROM tbl_dstaikhoan 
--	--   where tbl_Socai.Ngayctu >=@fromdate and  tbl_Socai.Ngayctu <= @todate
--	--   group by  tbl_Socai.TkNo --tbl_Socai.TkCo,
--		end



--       BEGIN
--         UPDATE  #TempResults
--         SET 
--		 #TempResults.PSNo = isnull((select sum(tbl_Socai.PsNo) from tbl_Socai 
--                            where tbl_Socai.tkno =  #TempResults.[matk] and 
--						   year(tbl_Socai.Ngayctu) = @yearchon ),0)
	

		
--      from #TempResults,tbl_Socai
--		where #TempResults.[matk] = tbl_Socai.tkno
		
--		 END
		 
		

--		    BEGIN
--         UPDATE  #TempResults
--         SET 
--		 #TempResults.PSCo = isnull((select sum(tbl_Socai.PsCo) from tbl_Socai 
--                            where tbl_Socai.TkCo =  #TempResults.[matk]
--							 and
--							   year( tbl_Socai.Ngayctu)= @yearchon ),0)
		 
		 
--      from #TempResults,tbl_Socai
--		where #TempResults.[matk] = tbl_Socai.TkCo
		
--		 END
		 
		begin  -- udate baocakqkd

		begin
		delete RPtdetailKQKD200
		where RPtdetailKQKD200. username = @username

		end

       begin
        insert into RPtdetailKQKD200 (username,nay01dt,naycfbanhang )
		values (@username, '0','0' )
		 --FROM RPtdetailKQKD200 
	--   where tbl_Socai.Ngayctu >=@fromdate and  tbl_Socai.Ngayctu <= @todate
	--   group by  tbl_Socai.TkNo --tbl_Socai.TkCo,
		end

		--RPtdetailKQKD200. nay01dt = isnull( (select sum(#TempResults.PSNo) from #TempResults 
  --                          where left(#TempResults.matk,3) =  '111' or
		--							left(#TempResults.matk,3) =  '112' or
		--							left(#TempResults.matk,3) =  '113' ),0)
		

  UPDATE  RPtdetailKQKD200
         SET 
		
	RPtdetailKQKD200.nay01dt = isnull( (select sum(tbl_Socai.PSCo) from tbl_Socai 
                         where left(tbl_Socai.TkCo,3) =  '511'   and
							   year( tbl_Socai.Ngayctu)= @yearchon),0),
					
		
    RPtdetailKQKD200. nay02giamdt = isnull( (select sum(tbl_Socai.PsNo) from tbl_Socai 
                         where left(tbl_Socai.TkNo,3) =  '511'   and
						      left(tbl_Socai.TkCo,3) =  '521'   and
							   year( tbl_Socai.Ngayctu)= @yearchon),0),

     RPtdetailKQKD200. nay11giavon = isnull( (select sum(tbl_Socai.PsCo) from tbl_Socai 
                         where left(tbl_Socai.TkNo,3) =  '911'   and
						      left(tbl_Socai.TkCo,3) =  '632'   and
							   year( tbl_Socai.Ngayctu)= @yearchon),0),


 RPtdetailKQKD200. naydttaichinh = isnull( (select sum(tbl_Socai.PsCo) from tbl_Socai 
                         where left(tbl_Socai.TkNo,3) =  '515'   and
						      left(tbl_Socai.TkCo,3) =  '911'   and
							   year( tbl_Socai.Ngayctu)= @yearchon),0),


 RPtdetailKQKD200. naycftaichinh = isnull( (select sum(tbl_Socai.PsCo) from tbl_Socai 
                         where left(tbl_Socai.TkNo,3) =  '911'   and
						      left(tbl_Socai.TkCo,3) =  '635'   and
							   year( tbl_Socai.Ngayctu)= @yearchon),0),

							   
 RPtdetailKQKD200. naycfbanhang = isnull( (select sum(tbl_Socai.PsCo) from tbl_Socai 
                         where left(tbl_Socai.TkNo,3) =  '911'   and
						      left(tbl_Socai.TkCo,3) =  '641'   and
							   year( tbl_Socai.Ngayctu)= @yearchon),0),

							   
 RPtdetailKQKD200. naycfquanlydn = isnull( (select sum(tbl_Socai.PsCo) from tbl_Socai 
                         where left(tbl_Socai.TkNo,3) =  '911'   and
						      left(tbl_Socai.TkCo,3) =  '642'   and
							   year(tbl_Socai.Ngayctu)= @yearchon),0),

							   						   
 RPtdetailKQKD200. naythunhapkhac = isnull( (select sum(tbl_Socai.PsCo) from tbl_Socai 
                         where left(tbl_Socai.TkNo,3) =  '711'   and
						      left(tbl_Socai.TkCo,3) =  '911'   and
							   year(tbl_Socai.Ngayctu)= @yearchon),0),



							   						   
 RPtdetailKQKD200. naycfkhac = isnull( (select sum(tbl_Socai.PsCo) from tbl_Socai 
                         where left(tbl_Socai.TkNo,3) =  '911'   and
						      left(tbl_Socai.TkCo,3) =  '811'   and
							   year(tbl_Socai.Ngayctu)= @yearchon),0),

							   						   
 RPtdetailKQKD200. naycftndnhienhanh = isnull( (select sum(tbl_Socai.PsCo) from tbl_Socai 
                         where left(tbl_Socai.TkNo,3) =  '911'   and
						      left(tbl_Socai.TkCo,4) =  '8211'   and
							   year(tbl_Socai.Ngayctu)= @yearchon),0),

							   						   
 RPtdetailKQKD200. nayfdnhoanlai = isnull( (select sum(tbl_Socai.PsCo) from tbl_Socai 
                         where left(tbl_Socai.TkNo,3) =  '911'   and
						      left(tbl_Socai.TkCo,4) =  '8212'   and
							   year(tbl_Socai.Ngayctu)= @yearchon),0),

RPtdetailKQKD200. truoc01dt = isnull( (select KQKD200Dauky. [dthu01] from KQKD200Dauky 
                         where KQKD200Dauky.nam = @yearchon),0),

RPtdetailKQKD200. truoc02giamdt = isnull( (select KQKD200Dauky. [giamdt02] from KQKD200Dauky 
                         where KQKD200Dauky.nam = @yearchon),0),

RPtdetailKQKD200. truoc11giavon = isnull( (select KQKD200Dauky. [giavon11] from KQKD200Dauky 
                         where KQKD200Dauky.nam = @yearchon),0),
						 
RPtdetailKQKD200. truoccfbanhang = isnull( (select KQKD200Dauky. cfbanhang from KQKD200Dauky 
                         where KQKD200Dauky.nam = @yearchon),0),

RPtdetailKQKD200. truoccfdnhoanlai = isnull( (select KQKD200Dauky. cfdnhoanlai from KQKD200Dauky 
                         where KQKD200Dauky. nam = @yearchon),0),


RPtdetailKQKD200. truoccfkhac = isnull( (select KQKD200Dauky. cfkhac from KQKD200Dauky 
                         where KQKD200Dauky.nam = @yearchon),0),
RPtdetailKQKD200. truoccflaivay = isnull( (select KQKD200Dauky. cflaivay from KQKD200Dauky 
                         where KQKD200Dauky.nam = @yearchon),0),
--RPtdetailKQKD200. truoccfquanlydn = isnull( (select KQKD200Dauky. cfquanlydn from KQKD200Dauky 
--                         where KQKD200Dauky. nam = @yearchon-1),0),


RPtdetailKQKD200. truoccftaichinh = isnull( (select KQKD200Dauky. cftaichinh from KQKD200Dauky 
                         where KQKD200Dauky.nam = @yearchon),0),

RPtdetailKQKD200. truoccftndnhienhanh = isnull( (select KQKD200Dauky. cftndnhienhanh from KQKD200Dauky 
                         where KQKD200Dauky. nam = @yearchon),0),

RPtdetailKQKD200. truocdttaichinh = isnull( (select KQKD200Dauky. dttaichinh from KQKD200Dauky 
                         where KQKD200Dauky. nam = @yearchon),0),
						 
RPtdetailKQKD200. truoclaicbcophieu = isnull( (select KQKD200Dauky. laicbcophieu from KQKD200Dauky 
                         where KQKD200Dauky. nam = @yearchon),0),

RPtdetailKQKD200. truoccfquanlydn = isnull( (select KQKD200Dauky. cfquanlydn from KQKD200Dauky 
                         where KQKD200Dauky. nam = @yearchon),0),

RPtdetailKQKD200. truoclaigiaomtrencphieu = isnull( (select KQKD200Dauky. laigiaomtrencphieu from KQKD200Dauky 
                         where KQKD200Dauky. nam = @yearchon),0),

RPtdetailKQKD200. truocthunhapkhac = isnull( (select KQKD200Dauky. thunhapkhac from KQKD200Dauky 
                         where KQKD200Dauky. nam = @yearchon),0)



						 
     from RPtdetailKQKD200
	
	where RPtdetailKQKD200. username = @username
		

end


	    --where tbl_Socai.Ngayctu in (select tbl_kacontractCustcode.CustomerCode from tbl_kacontractCustcode 
     --                           where tbl_kacontractCustcode.ContractNo = @Contractno)
     --   --group by tbl_kasales.Priod


		--,first(tbl_Socai.TkNo) -- isnull(sum(tbl_Socai.PsCo)	

	-------
	  --tbl_kacontractsvolume contractvolume = new tbl_kacontractsvolume();
   --         //        contractvolume.ContractNo = contract.ContractNo;
   --         //        contractvolume.Priod = item.priod;
   --         //        contractvolume.EC = item.EC;
   --         //        contractvolume.NSR = item.NSR;
   --         //        contractvolume.Litter = item.Litter;
   --         //        contractvolume.GSR = item.GSR;
   --         //        contractvolume.PC = item.PC;
   --         //        contractvolume.UC = item.UC;

   --         //        dc.CommandTimeout = 0;
   --         //        dc.tbl_kacontractsvolumes.InsertOnSubmit(contractvolume);
   --         //        dc.SubmitChanges();

-----------------------
		--begin

		--  insert into tbl_kacontractsvolume (ContractNo,priod,EC,NSR,Litter,GSR,PC, UC)
		--SELECT  
	 --   	@Contractno, #TempResults.priod, #TempResults.EC,#TempResults.NSR,#TempResults.Litter,#TempResults.GSR,#TempResults.PC,#TempResults.UC
	 --  FROM #TempResults 
	--  where tbl_kasalesTemp.[Cond Type] = 'NETP'
		


	--		end


		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;



	end

	


GO
/****** Object:  StoredProcedure [dbo].[calulationluuchuyentiente200]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE procedure  [dbo].[calulationluuchuyentiente200]
( 
@username nvarchar (225) ,
 @yearchon INT 


)
 
as


begin


		IF OBJECT_ID(N'tempdb..#Tempthu', N'U') IS NOT NULL 
        DROP TABLE #Tempthu;

		
		CREATE TABLE #Tempthu
			(
		                        matkDU Nvarchar(10),
								
                             	machitiet int,
                                tPSNo float,
                          	stat int ,
							
			)

IF OBJECT_ID(N'tempdb..#Tempchi', N'U') IS NOT NULL 
        DROP TABLE #Tempchi;

		
		CREATE TABLE #Tempchi
			(
		                       matkDU Nvarchar(10),
								
                             	machitiet int,
                              
                                tPSCo float,
						stat int ,
							
			)


		begin
        insert into #Tempthu (matkDU, machitiet, tPSNo ,stat)
		SELECT tbl_Socai.TkCo, ISNULL(tbl_Socai.MaCTietTKCo, -1), SUM(tbl_Socai.PsCo),'0'
		 FROM  tbl_Socai
		 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
		       and (left(tbl_Socai.TkNo,3) =  '111'  
					or  left(tbl_Socai.TkNo,3)=  '112' 
					or  left(tbl_Socai.TkNo,3)=  '113' 	  
						   )

	     GROUP BY tbl_Socai.TkCo, tbl_Socai.MaCTietTKCo
		end

		begin

        insert into #Tempchi (matkDU, machitiet, tPSCo ,stat)
		SELECT tbl_Socai.TkNo, ISNULL(tbl_Socai.MaCTietTKNo, -1),- SUM(tbl_Socai.PsCo),'0'
		 FROM  tbl_Socai
		 WHERE   year( tbl_Socai.Ngayctu)= @yearchon
		       and (left(tbl_Socai.TkCo,3) =  '111'  
					or  left(tbl_Socai.TkCo,3)=  '112' 
					or  left(tbl_Socai.TkCo,3)=  '113' 	  
						   )

	     GROUP BY tbl_Socai.TkNo, tbl_Socai.MaCTietTKNo
		end


		 
	

		begin
		delete RPtdetaillchuyenttttiep
		where RPtdetaillchuyenttttiep.username = @username

		end

       begin
        insert into RPtdetaillchuyenttttiep (username,nn01thudthu,nn02chiccap )
		values (@username, '0','0' )
		
		end

	
	


begin -- loai 1
 UPDATE  #Tempthu
         SET 
#Tempthu.stat ='1'
  where (left(#Tempthu.matkDU,3) =  '511'  
						  or  left(#Tempthu.matkDU,4)=  '3331'  
						  	  or  left(#Tempthu.matkDU,3)=  '131'  
							  	  or  left(#Tempthu.matkDU,3)=  '515'  
	  or  left(#Tempthu.matkDU,3)=  '121'  )


end


begin -- loai 2
 UPDATE  #Tempchi  
         SET 
#Tempchi.stat ='2'
  where (left(#Tempchi.matkDU,3) =  '331'  
					or  left(#Tempchi.matkDU,3)=  '151'  
					or  left(#Tempchi.matkDU,3)=  '152'  
					or  left(#Tempchi.matkDU,3)=  '153'  
					or  left(#Tempchi.matkDU,3)=  '154'  
							or  left(#Tempchi.matkDU,3)=  '155'  
									or  left(#Tempchi.matkDU,3)=  '156'  
											or  left(#Tempchi.matkDU,3)=  '157'  
						  )


end


begin  --loai 3
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='3'
  
      where (left(#Tempchi.matkDU,3) =  '334'   )

end



begin  --loai 4
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='4'
  
      where left(#Tempchi.matkDU,3) =  '635' 
	             and #Tempchi.machitiet =  '0' -- chi tiết lai vay mã == 0

end



begin  --loai 5
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='5'
  
      where left(#Tempchi.matkDU,4) =  '3334' 
	          
end

-- PS Nợ 111+112 / Có 711, 133, 141, 244…(các khoản THU khác từ hoạt động KD mà ko thuộc chỉ tiêu 01)

---PS Có 111+112+113 / Nợ 211, 213, 217, 241 …

begin  --loai 21
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='21'
     where (left(#Tempchi.matkDU,3) =  '211' 
	          or left(#Tempchi.matkDU,3) =  '213' 
			     or left(#Tempchi.matkDU,3) =  '217' 
				  )
								   and  #Tempchi.stat ='0'

end


begin  --loai 31
 UPDATE  #Tempthu
         SET 
#Tempthu.stat ='31'
     where (left(#Tempthu.matkDU,3) =  '411' 
	         
			   
				  )
								   and  #Tempthu.stat ='0'

end


begin  --loai 32
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='32'
     where (left(#Tempchi.matkDU,3) =  '411' 
	         
			   
				  )
								   and  #Tempchi.stat ='0'

end

begin  --loai 33
 UPDATE  #Tempthu
         SET 
#Tempthu.stat ='33'
     where (left(#Tempthu.matkDU,4) =  '3411' 
	         
			 --or  left(#Tempthu.matkDU,3) =  '342' 
				  )
								   and  #Tempthu.stat ='0'

end


begin  --loai 34
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='34'
     where (left(#Tempchi.matkDU,4) =  '3411' 
	         
				 --or  left(#Tempchi.matkDU,3) =  '342'    
				  )
								   and  #Tempchi.stat ='0'

end


begin  --loai 35
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='35'
     where (left(#Tempchi.matkDU,4) =  '3412' 
	         
				 --or  left(#Tempchi.matkDU,3) =  '342'    
				  )
								   and  #Tempchi.stat ='0'

end


begin  --loai 36
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='36'
     where (left(#Tempchi.matkDU,3) =  '421' 
	         
				 --or  left(#Tempchi.matkDU,3) =  '342'    
				  )
								   and  #Tempchi.stat ='0'

end


begin  --loai 61
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='61'
     where (left(#Tempchi.matkDU,3) =  '412' 
	         
				 --or  left(#Tempchi.matkDU,3) =  '342'    
				  )
								   and  #Tempchi.stat ='0'

end

begin  --loai 61
 UPDATE  #Tempthu
         SET 
#Tempthu.stat ='61'
     where (left(#Tempthu.matkDU,3) =  '412' 
	         
			 --or  left(#Tempthu.matkDU,3) =  '342' 
				  )
								   and  #Tempthu.stat ='0'

end


begin  --loai 22
 UPDATE  #Tempthu
         SET 
#Tempthu.stat ='22'
     where (left(#Tempthu.matkDU,3) =  '711' 
	         
			or  left(#Tempthu.matkDU,4) =  '5117' 
				or  left(#Tempthu.matkDU,3) =  '131' 
				
				  )
								   and  #Tempthu.stat ='0'

end
  

begin  --loai 22
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='22'
     where (left(#Tempchi.matkDU,3) =  '632' 
	         
			or  left(#Tempchi.matkDU,3) =  '811' 
			--	or  left(#Tempchi.matkDU,3) =  '131' 
				
				  )
								   and  #Tempchi.stat ='0'

end					


begin  --loai 23
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='23'
     where (left(#Tempchi.matkDU,3) =  '128' 
	         
			or  left(#Tempchi.matkDU,3) =  '171' 
			--	or  left(#Tempchi.matkDU,3) =  '131' 
				
				  )
								   and  #Tempchi.stat ='0'

end			


begin  --loai 24
 UPDATE  #Tempthu
         SET 
#Tempthu.stat ='24'
     where (left(#Tempthu.matkDU,3) =  '128' 
	         
			or  left(#Tempthu.matkDU,4) =  '171' 
			
				
				  )
								   and  #Tempthu.stat ='0'

end
  

begin  --loai 25
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='25'
     where (left(#Tempchi.matkDU,3) =  '211' 
	         
			or  left(#Tempchi.matkDU,3) =  '222' 
			or  left(#Tempchi.matkDU,4) =  '2281' 
				
				  )
								   and  #Tempchi.stat ='0'

end			

begin  --loai 26
 UPDATE  #Tempthu
         SET 
#Tempthu.stat ='26'
     where (left(#Tempthu.matkDU,3) =  '221' 
	         
			or  left(#Tempthu.matkDU,3) =  '222' 
			
					or  left(#Tempthu.matkDU,4) =  '2281' 
				  )
								   and  #Tempthu.stat ='0'

end
  
  
begin  --loai 27
 UPDATE  #Tempthu
         SET 
#Tempthu.stat ='27'
     where (left(#Tempthu.matkDU,3) =  '515' 
	         
	--		or  left(#Tempthu.matkDU,3) =  '222' 
			
			--		or  left(#Tempthu.matkDU,4) =  '2281' 
				  )
								   and  #Tempthu.stat ='0'

end	



begin -- loai 6
 UPDATE  #Tempthu
         SET 
#Tempthu.stat ='6'
  where 
  --(left(#Tempthu.matkDU,3) =  '711'  
		--				  or  left(#Tempthu.matkDU,4)=  '133'  
		--				  	  or  left(#Tempthu.matkDU,3)=  '141'  
		--					  	  or ( (left(#Tempthu.matkDU,3)=  '244' ) 
		--						  and (#Tempthu.machitiet <> '1'	)  )
	 --)
	   #Tempthu.stat ='0'

end
-- PS Có 111+112+113 / Nợ 811, 161, 244, 333, 338, 344, 352, 353, 356…(các khoản CHI khác từ hoạt động KD mà ko thuộc chỉ tiêu 02+03+04+05)								 

begin  --loai 7
 UPDATE  #Tempchi
         SET 
#Tempchi.stat ='7'
    where
    --(left(#Tempchi.matkDU,3) =  '811' 
	     --     or left(#Tempchi.matkDU,3) =  '161' 
			   --  or left(#Tempchi.matkDU,3) =  '244' 
				  --  or left(#Tempchi.matkDU,3) =  '333' 
					 --  or left(#Tempchi.matkDU,3) =  '338' 
					 --     or left(#Tempchi.matkDU,3) =  '344' 
						--     or left(#Tempchi.matkDU,3) =  '352' 
						--	    or left(#Tempchi.matkDU,3) =  '353' 
						--		   or left(#Tempchi.matkDU,3) =  '356' )   and
								   #Tempchi.stat ='0'

end
	begin  -- udate lchuyen tien te

  UPDATE  RPtdetaillchuyenttttiep
         SET 
	--PS Nợ 111+112 / Có 511,3331,131, 515,121 (515,121 chi tiết số tiền thu từ bán chứng khoán kinh doanh)	
RPtdetaillchuyenttttiep.nn01thudthu = isnull( (select sum(#Tempthu.tPSNo) from #Tempthu 
                         where #Tempthu.stat ='1'	 ),0),

-- PS Có 111+112 / Nợ 331, 151, 152, 153, 154, 155, 156, 157,…
RPtdetaillchuyenttttiep.nn02chiccap = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi  
                         where #Tempchi.stat ='2'	 ),0),
							 
-- 	 PS Có 111+112 / Nợ 334
RPtdetaillchuyenttttiep.nn03chilaodong = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi  
                         where #Tempchi.stat ='3'	 ),0),

                   

					
-- PS Có 111+112+113 / Nợ 635-chi tiết lãi vay
RPtdetaillchuyenttttiep.nn04chilaivay = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi  
                         where #Tempchi.stat ='4'	 ),0),

				 

-- PS Có 111+112+113 / Nợ 3334

RPtdetaillchuyenttttiep.nn05chithuetndn =  isnull( (select sum(#Tempchi.tPSCo) from #Tempchi  
                        where #Tempchi.stat ='5'	 ),0),

-- PS Nợ 111+112 / Có 711, 133, 141, 244…(các khoản THU khác từ hoạt động KD mà ko thuộc chỉ tiêu 01)
			
RPtdetaillchuyenttttiep.nn06thukhac = isnull( (select sum(#Tempthu.tPSNo) from #Tempthu 
                         where #Tempthu.stat ='6'	 ),0),

								 
-- PS Có 111+112+113 / Nợ 811, 161, 244, 333, 338, 344, 352, 353, 356…(các khoản CHI khác từ hoạt động KD mà ko thuộc chỉ tiêu 02+03+04+05)								 
	RPtdetaillchuyenttttiep.nn07chikhac = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi  
                         where #Tempchi.stat ='7'	 ),0),

	
						 
								 
-- 20 = 01 + 02 + 03 + 04 + 05 + 06 + 07

	
---PS Có 111+112+113 / Nợ 211, 213, 217, 241 …
RPtdetaillchuyenttttiep.nn21chitsan = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi  
                         where #Tempchi.stat ='21'	 ),0),

					
-- Chênh lệch dương (+) hoặc âm (-) giữa:
-- Thu: PS nợ 111+112+113 / Có 711, 5117, 131…), và
-- Chi (PS có 111+112+113 / Nợ 632, 811…)
--chi tiết về thanh lý, nhượng bán TSCĐ, BĐSĐT và các tài sản dài hạn khác
		
RPtdetaillchuyenttttiep.nn22thutaisan = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi  
                         where #Tempchi.stat ='22'	 ),0)
						 + isnull( (select sum(#Tempthu.tPSNo) from #Tempthu  
                         where #Tempthu.stat ='22'	 ),0) ,
								 
	--PS Có 111+112+113 / Nợ 128, 171 …							 
	
RPtdetaillchuyenttttiep.nn23chichovay = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi  
                         where #Tempchi.stat ='23'	 ),0),	

--  PS Nợ 111+112+113 / Có 128, 171 …
	
RPtdetaillchuyenttttiep.nn24thuchovay = isnull( (select sum(#Tempthu.tPSNo) from #Tempthu 
                         where #Tempthu.stat ='24'	 ),0),


-- PS Có 111+112+113 / Nợ 221, 222, 2281…
	
RPtdetaillchuyenttttiep.nn25chidtdonvikhac = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi  
                         where #Tempchi.stat ='25'	 ),0),

-- PS Nợ 111+112+113 / Có 221, 222, 2281…
		
RPtdetaillchuyenttttiep.nn26thudtdonvikhac = isnull( (select sum(#Tempthu.tPSNo) from #Tempthu 
                         where #Tempthu.stat ='26'	 ),0),
								 
								 
--  PS Nợ 111+112+113 / Có 515 (lãi, cổ tức, lợi nhuận được chia)

		
RPtdetaillchuyenttttiep.nn27thulaicotuc = isnull( (select sum(#Tempthu.tPSNo) from #Tempthu 
                         where #Tempthu.stat ='27'	 ),0),
								 
								 
-- 	30 = 21 + 22 + 23 + 24 + 25 + 26 + 27
-- Tiền thu từ phát hành cổ phiếu, nhận vốn góp của chủ sở hữu
RPtdetaillchuyenttttiep.nn31thucophieu = isnull( (select sum(#Tempthu.tPSNo) from #Tempthu 
                         where #Tempthu.stat ='31'	 ),0),

RPtdetaillchuyenttttiep.nn32chitravon = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi 
                         where #Tempchi.stat ='32'	 ),0),

RPtdetaillchuyenttttiep.nn33thudivay = isnull( (select sum(#Tempthu.tPSNo) from #Tempthu 
                         where #Tempthu.stat ='33'	 ),0),
RPtdetaillchuyenttttiep.nn34tragoc = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi 
                         where #Tempchi.stat ='34'	 ),0),

RPtdetaillchuyenttttiep.nn35tragocthue = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi 
                         where #Tempchi.stat ='35'	 ),0),

RPtdetaillchuyenttttiep.nn36tracotuc = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi 
                         where #Tempchi.stat ='36'	 ),0),

RPtdetaillchuyenttttiep.nn61tientygia = isnull( (select sum(#Tempchi.tPSCo) from #Tempchi 
                         where #Tempchi.stat ='61'	 ),0)
						 + isnull( (select sum(#Tempthu.tPSNo) from #Tempthu 
                         where #Tempthu.stat ='61'	 ),0),

				 
RPtdetaillchuyenttttiep.nt02chiccap = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =2
						 
						  ),0),


RPtdetaillchuyenttttiep.nt03chilaodong = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =3
						 
						  ),0),
						  			

RPtdetaillchuyenttttiep.nt04chilaivay = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =4
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt05chithuetndn = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =5
						 
						  ),0),


RPtdetaillchuyenttttiep.nt06thukhac = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =6
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt07chikhac = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =7
						 
						  ),0),

RPtdetaillchuyenttttiep.nt21chitsan = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =21
						 
						  ),0),


RPtdetaillchuyenttttiep.nt22thutaisan = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =22
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt23chichovay = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =23
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt24thuchovay = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =24
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt25chidtdonvikhac = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =25
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt26thudtdonvikhac = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =26
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt27thulaicotuc = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =27
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt31thucophieu = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =31
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt32chitravon = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =32
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt33thudivay = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =33
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt34tragoc = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =34
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt35tragocthue = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =35
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt36tracotuc = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =36
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt50lltrongky = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =50
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt60tiendauky = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =60
						 
						  ),0),
						  
RPtdetaillchuyenttttiep.nt61tientygia = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =61
						 
						  ),0),
						  						  						  												 
RPtdetaillchuyenttttiep.nt01thudthu = isnull( (select sum(LTTT200Dauky.Sotien) from LTTT200Dauky 
                         where LTTT200Dauky.nam = @yearchon	
						 and LTTT200Dauky.Machitieu =1 ),0)

								 							 					
     from RPtdetaillchuyenttttiep
	
	where RPtdetaillchuyenttttiep.username = @username
		

end


		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;



	end

	



GO
/****** Object:  Table [dbo].[CDKT200Dauky]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CDKT200Dauky](
	[nam] [int] NULL,
	[Machitieu] [int] NULL,
	[Tenchitieu] [nvarchar](225) NULL,
	[Cachghi] [nvarchar](225) NULL,
	[Sotien] [float] NULL,
	[stat] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
 CONSTRAINT [PK_CDKT200] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CDKT200PS]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CDKT200PS](
	[nam] [int] NULL,
	[Machitieu] [int] NULL,
	[Tenchitieu] [nvarchar](225) NULL,
	[Sotien] [float] NULL,
	[stat] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
 CONSTRAINT [PK_CDKT200PS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KQKD200Dauky]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KQKD200Dauky](
	[nam] [int] NULL,
	[dthu01] [float] NULL,
	[giamdt02] [float] NULL,
	[giavon11] [float] NULL,
	[dttaichinh] [float] NULL,
	[cftaichinh] [float] NULL,
	[cflaivay] [float] NULL,
	[cfbanhang] [float] NULL,
	[cfquanlydn] [float] NULL,
	[thunhapkhac] [float] NULL,
	[cfkhac] [float] NULL,
	[cftndnhienhanh] [float] NULL,
	[cfdnhoanlai] [float] NULL,
	[laicbcophieu] [float] NULL,
	[laigiaomtrencphieu] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
 CONSTRAINT [PK_KQKD200] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LTTT200Dauky]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LTTT200Dauky](
	[nam] [int] NULL,
	[Machitieu] [int] NULL,
	[Tenchitieu] [nvarchar](225) NULL,
	[Cachghi] [nvarchar](225) NULL,
	[Sotien] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
 CONSTRAINT [PK_LTTT200Dauky] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rpt_PhieuThu]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rpt_PhieuThu](
	[tencongty] [nvarchar](225) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](225) NULL,
	[tengiamdoc] [nvarchar](225) NULL,
	[tenketoantruong] [nvarchar](225) NULL,
	[ngaychungtu] [datetime] NULL,
	[nguoinoptien] [nvarchar](100) NULL,
	[nguoilapphieu] [nvarchar](100) NULL,
	[diachinguoinop] [nvarchar](225) NULL,
	[lydothu] [nvarchar](225) NULL,
	[sotien] [float] NULL,
	[sotienbangchu] [nvarchar](225) NULL,
	[sochungtugoc] [int] NOT NULL,
	[username] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tkno] [nvarchar](10) NULL,
	[quyenso] [nvarchar](10) NULL,
	[tkco] [nvarchar](225) NULL,
	[phieuthuso] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblRpt_PhieuThu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RptBTTHdetail]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RptBTTHdetail](
	[matk] [nvarchar](50) NULL,
	[tentk] [nvarchar](225) NULL,
	[noidung] [nvarchar](225) NULL,
	[psno] [float] NULL,
	[psco] [float] NULL,
	[username] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RptBTTHdetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RptBTTHhead]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RptBTTHhead](
	[tencongty] [nvarchar](225) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](225) NULL,
	[tengiamdoc] [nvarchar](225) NULL,
	[tenketoantruong] [nvarchar](225) NULL,
	[ngaychungtu] [datetime] NULL,
	[nguoilapphieu] [nvarchar](100) NULL,
	[username] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[phieuso] [nvarchar](50) NULL,
 CONSTRAINT [PK_RptBTTHhead] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RptdetaiCDPS]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RptdetaiCDPS](
	[username] [nvarchar](50) NULL,
	[tentk] [nvarchar](225) NULL,
	[Nodk] [float] NULL,
	[Codk] [float] NULL,
	[Psno] [float] NULL,
	[Psco] [float] NULL,
	[Cock] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nock] [float] NULL,
	[matk] [nvarchar](50) NULL,
 CONSTRAINT [PK_RptdetaiCDPS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtdetailCDKT200lientuc]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtdetailCDKT200lientuc](
	[cn111tien] [float] NULL,
	[cn112tientduong] [float] NULL,
	[cn121chungkhoan] [float] NULL,
	[cn122ckduphong] [float] NULL,
	[cn123dtdenngay] [float] NULL,
	[cn131ptkhach] [float] NULL,
	[cn132tratruoc] [float] NULL,
	[cn133pthunbnganh] [float] NULL,
	[cn134pthutiendokh] [float] NULL,
	[cn135pthuchovay] [float] NULL,
	[cn136ptnganhan] [float] NULL,
	[cn137dpptnganhan] [float] NULL,
	[cn139tsthieucho] [float] NULL,
	[cn141hangton] [float] NULL,
	[cn149duphonght] [float] NULL,
	[cn151cftratruoc] [float] NULL,
	[cn152vatkhautru] [float] NULL,
	[cn153thuepthukac] [float] NULL,
	[cn154traiphieu] [float] NULL,
	[cn155tskhacnh] [float] NULL,
	[cn211ptkhach] [float] NULL,
	[cn212tratruocdh] [float] NULL,
	[cn213vonodonvi] [float] NULL,
	[cn214pthunbo] [float] NULL,
	[cn215pthuchovay] [float] NULL,
	[cn216pthukhac] [float] NULL,
	[cn219duphongpt] [float] NULL,
	[cn222tscdngia] [float] NULL,
	[cn223tskhauh] [float] NULL,
	[cn225tscdthung] [float] NULL,
	[cn226tscdthuekha] [float] NULL,
	[cn228tscdvohnggia] [float] NULL,
	[cn229tscdvhkhauh] [float] NULL,
	[cn231bdsngia] [float] NULL,
	[cn232bdshaomon] [float] NULL,
	[cn241cfkddd] [float] NULL,
	[cn242cfxddd] [float] NULL,
	[cn251dtuctycon] [float] NULL,
	[cn252dtuctylienket] [float] NULL,
	[cn253dtukhac] [float] NULL,
	[cn254duphongdt] [float] NULL,
	[cn255dtudaohan] [float] NULL,
	[cn261cftratruocdn] [float] NULL,
	[cn262thuetndnhl] [float] NULL,
	[cn263vtuthietbidn] [float] NULL,
	[cn268tskhac] [float] NULL,
	[cn311ptnbannh] [float] NULL,
	[cn312ngmuatratr] [float] NULL,
	[cn313thuephainop] [float] NULL,
	[cn314ptracnhan] [float] NULL,
	[cn315cphiptranh] [float] NULL,
	[cn316cfptranbonh] [float] NULL,
	[cn317ptrtheoluong] [float] NULL,
	[cn318pthuchunhan] [float] NULL,
	[cn319ptranhan] [float] NULL,
	[cn320vaynotcnhan] [float] NULL,
	[cn321duphptranh] [float] NULL,
	[cn322quykhen] [float] NULL,
	[cn323quygia] [float] NULL,
	[cn324bantraiphieu] [float] NULL,
	[cn331nodnngban] [float] NULL,
	[cn332ngmuatratdn] [float] NULL,
	[cn333cphiphaitra] [float] NULL,
	[cn334ptranbvevon] [float] NULL,
	[cn335ptranbdaihan] [float] NULL,
	[cn336dthuchthdn] [float] NULL,
	[cn337ptradnkhac] [float] NULL,
	[cn338vaynodn] [float] NULL,
	[cn339traiphieu] [float] NULL,
	[cn340cophieu] [float] NULL,
	[cn341tnhoanlai] [float] NULL,
	[cn342duphongdn] [float] NULL,
	[cn343quykhoahoc] [float] NULL,
	[cn411vongopcsh] [float] NULL,
	[cn411bcpudai] [float] NULL,
	[cn412thangduvon] [float] NULL,
	[cn413traiphieu] [float] NULL,
	[cn414voncshkhac] [float] NULL,
	[cn415cphieuquy] [float] NULL,
	[cn416chenhlechts] [float] NULL,
	[cn417tygia] [float] NULL,
	[cn418dautuptrien] [float] NULL,
	[cn419quyxxdn] [float] NULL,
	[cn420quykhacsh] [float] NULL,
	[cn421lnsauthue] [float] NULL,
	[cn421alnkytruoc] [float] NULL,
	[cn421blnkynay] [float] NULL,
	[cn422vonxdcb] [float] NULL,
	[cn431nkinhphi] [float] NULL,
	[cn432kpthanhtscd] [float] NULL,
	[cn411acophieupt] [float] NULL,
	[dn111tien] [float] NULL,
	[dn112tientduong] [float] NULL,
	[dn121chungkhoan] [float] NULL,
	[dn122ckduphong] [float] NULL,
	[dn123dtdenngay] [float] NULL,
	[dn131ptkhach] [float] NULL,
	[dn132tratruoc] [float] NULL,
	[dn133pthunbnganh] [float] NULL,
	[dn134pthutiendokh] [float] NULL,
	[dn135pthuchovay] [float] NULL,
	[dn136ptnganhan] [float] NULL,
	[dn137dpptnganhan] [float] NULL,
	[dn139tsthieucho] [float] NULL,
	[dn141hangton] [float] NULL,
	[dn149duphonght] [float] NULL,
	[dn151cftratruoc] [float] NULL,
	[dn152vatkhautru] [float] NULL,
	[dn153thuepthukac] [float] NULL,
	[dn154traiphieu] [float] NULL,
	[dn155tskhacnh] [float] NULL,
	[dn211ptkhach] [float] NULL,
	[dn212tratruocdh] [float] NULL,
	[dn213vonodonvi] [float] NULL,
	[dn214pthunbo] [float] NULL,
	[dn215pthuchovay] [float] NULL,
	[dn216pthukhac] [float] NULL,
	[dn219duphongpt] [float] NULL,
	[dn222tscdngia] [float] NULL,
	[dn223tskhauh] [float] NULL,
	[dn225tscdthung] [float] NULL,
	[dn226tscdthuekha] [float] NULL,
	[dn228tscdvohnggia] [float] NULL,
	[dn229tscdvhkhauh] [float] NULL,
	[dn231bdsngia] [float] NULL,
	[dn232bdshaomon] [float] NULL,
	[dn241cfkddd] [float] NULL,
	[dn242cfxddd] [float] NULL,
	[dn251dtuctycon] [float] NULL,
	[dn252dtuctylienket] [float] NULL,
	[dn253dtukhac] [float] NULL,
	[dn254duphongdt] [float] NULL,
	[dn255dtudaohan] [float] NULL,
	[dn261cftratruocdn] [float] NULL,
	[dn262thuetndnhl] [float] NULL,
	[dn263vtuthietbidn] [float] NULL,
	[dn268tskhac] [float] NULL,
	[dn311ptnbannh] [float] NULL,
	[dn312ngmuatratr] [float] NULL,
	[dn313thuephainop] [float] NULL,
	[dn314ptracnhan] [float] NULL,
	[dn315cphiptranh] [float] NULL,
	[dn316cfptranbonh] [float] NULL,
	[dn317ptrtheoluong] [float] NULL,
	[dn318pthuchunhan] [float] NULL,
	[dn319ptranhan] [float] NULL,
	[dn320vaynotcnhan] [float] NULL,
	[dn321duphptranh] [float] NULL,
	[dn322quykhen] [float] NULL,
	[dn323quygia] [float] NULL,
	[dn324bantraiphieu] [float] NULL,
	[dn331nodnngban] [float] NULL,
	[dn332ngmuatratdn] [float] NULL,
	[dn333cphiphaitra] [float] NULL,
	[dn334ptranbvevon] [float] NULL,
	[dn335ptranbdaihan] [float] NULL,
	[dn336dthuchthdn] [float] NULL,
	[dn337ptradnkhac] [float] NULL,
	[dn338vaynodn] [float] NULL,
	[dn339traiphieu] [float] NULL,
	[dn340cophieu] [float] NULL,
	[dn341tnhoanlai] [float] NULL,
	[dn342duphongdn] [float] NULL,
	[dn343quykhoahoc] [float] NULL,
	[dn411vongopcsh] [float] NULL,
	[dn411bcpudai] [float] NULL,
	[dn412thangduvon] [float] NULL,
	[dn413traiphieu] [float] NULL,
	[dn414voncshkhac] [float] NULL,
	[dn415cphieuquy] [float] NULL,
	[dn416chenhlechts] [float] NULL,
	[dn417tygia] [float] NULL,
	[dn418dautuptrien] [float] NULL,
	[dn419quyxxdn] [float] NULL,
	[dn420quykhacsh] [float] NULL,
	[dn421lnsauthue] [float] NULL,
	[dn421alnkytruoc] [float] NULL,
	[dn421blnkynay] [float] NULL,
	[dn422vonxdcb] [float] NULL,
	[dn431nkinhphi] [float] NULL,
	[dn432kpthanhtscd] [float] NULL,
	[dn411acophieupt] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
 CONSTRAINT [PK_RPtdetailCDKT200lientuc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtdetailKQKD200]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtdetailKQKD200](
	[nay01dt] [float] NULL,
	[nay02giamdt] [float] NULL,
	[nay11giavon] [float] NULL,
	[naydttaichinh] [float] NULL,
	[naycftaichinh] [float] NULL,
	[naycflaivay] [float] NULL,
	[naycfbanhang] [float] NULL,
	[naycfquanlydn] [float] NULL,
	[naythunhapkhac] [float] NULL,
	[naycfkhac] [float] NULL,
	[naycftndnhienhanh] [float] NULL,
	[nayfdnhoanlai] [float] NULL,
	[naylaicbcophieu] [float] NULL,
	[naylaigiaomtrencphieu] [float] NULL,
	[truoc01dt] [float] NULL,
	[truoc02giamdt] [float] NULL,
	[truoc11giavon] [float] NULL,
	[truocdttaichinh] [float] NULL,
	[truoccftaichinh] [float] NULL,
	[truoccflaivay] [float] NULL,
	[truoccfbanhang] [float] NULL,
	[truoccfquanlydn] [float] NULL,
	[truocthunhapkhac] [float] NULL,
	[truoccfkhac] [float] NULL,
	[truoccftndnhienhanh] [float] NULL,
	[truoccfdnhoanlai] [float] NULL,
	[truoclaicbcophieu] [float] NULL,
	[truoclaigiaomtrencphieu] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
 CONSTRAINT [PK_RPtdetailKQKD200] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtdetaillchuyenttttiep]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtdetaillchuyenttttiep](
	[nn01thudthu] [float] NULL,
	[nn02chiccap] [float] NULL,
	[nn03chilaodong] [float] NULL,
	[nn05chithuetndn] [float] NULL,
	[nn06thukhac] [float] NULL,
	[nn07chikhac] [float] NULL,
	[nn20llkd] [float] NULL,
	[nn21chitsan] [float] NULL,
	[nn22thutaisan] [float] NULL,
	[nn23chichovay] [float] NULL,
	[nn25chidtdonvikhac] [float] NULL,
	[nn26thudtdonvikhac] [float] NULL,
	[nn27thulaicotuc] [float] NULL,
	[nn31thucophieu] [float] NULL,
	[nn32chitravon] [float] NULL,
	[nn33thudivay] [float] NULL,
	[nn34tragoc] [float] NULL,
	[nn35tragocthue] [float] NULL,
	[nn36tracotuc] [float] NULL,
	[nn50lltrongky] [float] NULL,
	[nn60tiendauky] [float] NULL,
	[nn61tientygia] [float] NULL,
	[nn70tiencuoiky] [float] NULL,
	[nt01thudthu] [float] NULL,
	[nt02chiccap] [float] NULL,
	[nt03chilaodong] [float] NULL,
	[nt04chilaivay] [float] NULL,
	[nt05chithuetndn] [float] NULL,
	[nt06thukhac] [float] NULL,
	[nt07chikhac] [float] NULL,
	[nt21chitsan] [float] NULL,
	[nt22thutaisan] [float] NULL,
	[nt23chichovay] [float] NULL,
	[nt24thuchovay] [float] NULL,
	[nt25chidtdonvikhac] [float] NULL,
	[nt26thudtdonvikhac] [float] NULL,
	[nt31thucophieu] [float] NULL,
	[nt32chitravon] [float] NULL,
	[nt33thudivay] [float] NULL,
	[nt34tragoc] [float] NULL,
	[nt27thulaicotuc] [float] NULL,
	[nt20llkd] [float] NULL,
	[nn24thuchovay] [float] NULL,
	[nn04chilaivay] [float] NULL,
	[nt35tragocthue] [float] NULL,
	[nt36tracotuc] [float] NULL,
	[nt50lltrongky] [float] NULL,
	[nt60tiendauky] [float] NULL,
	[nt70tiencuoiky] [float] NULL,
	[nt61tientygia] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
 CONSTRAINT [PK_RPtdetaillchuyenttttiep] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RptdetailSoCai]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RptdetailSoCai](
	[username] [nvarchar](50) NULL,
	[Ngaychungtu] [datetime] NULL,
	[machungtu] [nvarchar](10) NOT NULL,
	[diengiai] [nvarchar](225) NULL,
	[taikhoandoiung] [nvarchar](50) NULL,
	[psco] [float] NULL,
	[psno] [float] NULL,
	[ton] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RptdetailSoCai] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RptdetailSocaichitiet]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RptdetailSocaichitiet](
	[username] [nvarchar](50) NULL,
	[Ngaychungtu] [datetime] NULL,
	[machungtu] [nvarchar](10) NOT NULL,
	[diengiai] [nvarchar](225) NULL,
	[taikhoandoiung] [nvarchar](50) NULL,
	[psco] [float] NULL,
	[psno] [float] NULL,
	[ton] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RptdetailSocaichitiet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RptdetailSoQuy]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RptdetailSoQuy](
	[username] [nvarchar](50) NULL,
	[Ngaychungtu] [datetime] NULL,
	[machungtuthu] [nvarchar](10) NOT NULL,
	[machungtuchi] [nvarchar](10) NULL,
	[diengiai] [nvarchar](225) NULL,
	[taikhoandoiung] [nvarchar](50) NULL,
	[psco] [float] NULL,
	[psno] [float] NULL,
	[ton] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RptdetailSoQuy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RptdetaiNKC]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RptdetaiNKC](
	[username] [nvarchar](50) NULL,
	[Ngaychungtu] [datetime] NULL,
	[machungtu] [nvarchar](50) NOT NULL,
	[diengiai] [nvarchar](225) NULL,
	[taikhoandoiung] [nvarchar](50) NULL,
	[psco] [float] NULL,
	[psno] [float] NULL,
	[ton] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RptdetaiNKC] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RptdetaiTHchitiet]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RptdetaiTHchitiet](
	[username] [nvarchar](50) NULL,
	[tenchitiet] [nvarchar](225) NULL,
	[stt] [int] NULL,
	[Nodk] [float] NULL,
	[Codk] [float] NULL,
	[Psno] [float] NULL,
	[Psco] [float] NULL,
	[Cock] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nock] [float] NULL,
	[machitiet] [int] NULL,
 CONSTRAINT [PK_RptdetaiTHchitiet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RptdetaiTHxuatnhapton]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RptdetaiTHxuatnhapton](
	[username] [nvarchar](50) NULL,
	[mahanghoa] [nvarchar](225) NULL,
	[stt] [int] NULL,
	[donvi] [nvarchar](50) NULL,
	[tenhanghoa] [nvarchar](225) NULL,
	[tondaukysoluong] [float] NULL,
	[tondaukythanhtien] [float] NULL,
	[nhaptrongkysoluong] [float] NULL,
	[nhaptrongkythanhtien] [float] NULL,
	[xuattrongkysoluong] [float] NULL,
	[xuattrongkythanhtien] [float] NULL,
	[toncuoikysoluong] [float] NULL,
	[toncuoikythanhtien] [float] NULL,
	[dongiaton] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RptdetaiTHxuatnhapton] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtheadCDKT200mau01]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtheadCDKT200mau01](
	[nam] [nvarchar](4) NULL,
	[giamdoc] [nvarchar](50) NULL,
	[ketoantruong] [nvarchar](50) NULL,
	[nguoighiso] [nvarchar](50) NULL,
	[tencongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](50) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[taikhoan] [nvarchar](50) NULL,
 CONSTRAINT [PK_RPtheadCDKT200mau01] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtheadCDPS]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtheadCDPS](
	[tungay] [datetime] NULL,
	[denngay] [datetime] NULL,
	[giamdoc] [nvarchar](50) NULL,
	[ketoantruong] [nvarchar](50) NULL,
	[nguoighiso] [nvarchar](50) NULL,
	[tencongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](50) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[taikhoan] [nvarchar](50) NULL,
 CONSTRAINT [PK_RPtheadCDPS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtheadKQKD200]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtheadKQKD200](
	[nam] [nvarchar](4) NULL,
	[giamdoc] [nvarchar](50) NULL,
	[ketoantruong] [nvarchar](50) NULL,
	[nguoighiso] [nvarchar](50) NULL,
	[tencongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](50) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[taikhoan] [nvarchar](50) NULL,
 CONSTRAINT [PK_RPtheadKQKD200] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtheadLCTTTtiep]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtheadLCTTTtiep](
	[nam] [nvarchar](4) NULL,
	[giamdoc] [nvarchar](50) NULL,
	[ketoantruong] [nvarchar](50) NULL,
	[nguoighiso] [nvarchar](50) NULL,
	[tencongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](50) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[taikhoan] [nvarchar](50) NULL,
 CONSTRAINT [PK_RPtheadLCTTTtiep] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtheadNKC]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtheadNKC](
	[nam] [nvarchar](4) NULL,
	[giamdoc] [nvarchar](50) NULL,
	[ketoantruong] [nvarchar](50) NULL,
	[nguoighiso] [nvarchar](50) NULL,
	[tencongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](50) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[taikhoan] [nvarchar](50) NULL,
 CONSTRAINT [PK_RPtheadNKC] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtheadSocai]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtheadSocai](
	[tungay] [datetime] NULL,
	[denngay] [datetime] NULL,
	[nodauky] [float] NULL,
	[codauky] [float] NULL,
	[psno] [float] NULL,
	[psco] [float] NULL,
	[cocuoiky] [float] NULL,
	[nocuoiky] [float] NULL,
	[tencongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](50) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[taikhoan] [nvarchar](50) NULL,
 CONSTRAINT [PK_RPtheadSocai] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtheadSocaichitiet]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtheadSocaichitiet](
	[tungay] [datetime] NULL,
	[denngay] [datetime] NULL,
	[nodauky] [float] NULL,
	[codauky] [float] NULL,
	[psno] [float] NULL,
	[psco] [float] NULL,
	[cocuoiky] [float] NULL,
	[nocuoiky] [float] NULL,
	[tencongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](50) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[taikhoan] [nvarchar](50) NULL,
	[tenchitiettk] [nvarchar](225) NULL,
 CONSTRAINT [PK_RPtheadSocaichitiet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtheadTHchitiet]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtheadTHchitiet](
	[tencongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](50) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[taikhoan] [nvarchar](50) NULL,
	[tungay] [datetime] NULL,
	[denngay] [datetime] NULL,
 CONSTRAINT [PK_RPtheadTHchitiet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtheadTHxuatnhapton]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtheadTHxuatnhapton](
	[tencongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](50) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[tungay] [datetime] NULL,
	[denngay] [datetime] NULL,
	[kho] [nvarchar](225) NULL,
 CONSTRAINT [PK_RPtheadTHxuatnhapton] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RptPhatsinhcdkt200]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RptPhatsinhcdkt200](
	[matk] [nvarchar](10) NULL,
	[loainganhan] [bit] NULL,
	[machitiet] [int] NULL,
	[tPSNo] [float] NULL,
	[tPSCo] [float] NULL,
	[tPsNotruPSco] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[useRpt] [nvarchar](225) NULL,
	[tenchitiet] [nvarchar](225) NULL,
	[tentk] [nvarchar](225) NULL,
 CONSTRAINT [PK_RptPhatsinhcdkt200] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rptphieunhapkhodetail01]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rptphieunhapkhodetail01](
	[stt] [int] NULL,
	[username] [nvarchar](50) NULL,
	[tensanpham] [nvarchar](225) NULL,
	[masanpham] [nvarchar](225) NULL,
	[donvi] [nvarchar](50) NULL,
	[sophieunhap] [nvarchar](50) NULL,
	[soluongyeucau] [float] NULL,
	[soluongthucte] [float] NULL,
	[dongia] [float] NULL,
	[thanhtien] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Rptphieunhapkhodetail01] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rptphieunhapkhohead]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rptphieunhapkhohead](
	[tencongty] [nvarchar](225) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](225) NULL,
	[tengiamdoc] [nvarchar](225) NULL,
	[tenketoantruong] [nvarchar](225) NULL,
	[ngaychungtu] [datetime] NULL,
	[nguoigiao] [nvarchar](100) NULL,
	[nguoilapphieu] [nvarchar](100) NULL,
	[nhaptaikho] [nvarchar](225) NULL,
	[diachikho] [nvarchar](225) NULL,
	[sotienbangchu] [nvarchar](225) NULL,
	[sochungtugoc] [nvarchar](225) NULL,
	[username] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tkno] [nvarchar](10) NULL,
	[tkco] [nvarchar](225) NULL,
	[theodonhang] [nvarchar](225) NULL,
	[phieunhapso] [nvarchar](50) NULL,
 CONSTRAINT [PK_Rptphieunhapkhohead] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rptphieuxuatkhodetail01]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rptphieuxuatkhodetail01](
	[stt] [int] NULL,
	[username] [nvarchar](50) NULL,
	[tensanpham] [nvarchar](225) NULL,
	[masanpham] [nvarchar](225) NULL,
	[donvi] [nvarchar](50) NULL,
	[sophieu] [nvarchar](50) NULL,
	[soluongyeucau] [float] NULL,
	[soluongthucte] [float] NULL,
	[dongia] [float] NULL,
	[thanhtien] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Rptphieuxuatkhodetail01] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rptphieuxuatkhohead]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rptphieuxuatkhohead](
	[tencongty] [nvarchar](225) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](225) NULL,
	[tengiamdoc] [nvarchar](225) NULL,
	[tenketoantruong] [nvarchar](225) NULL,
	[ngaychungtu] [datetime] NULL,
	[nguoinhan] [nvarchar](100) NULL,
	[nguoilapphieu] [nvarchar](100) NULL,
	[xuattaikho] [nvarchar](225) NULL,
	[diachibophan] [nvarchar](225) NULL,
	[sotienbangchu] [nvarchar](225) NULL,
	[sochungtugoc] [nvarchar](225) NULL,
	[username] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tkno] [nvarchar](10) NULL,
	[tkco] [nvarchar](225) NULL,
	[lydoxuat] [nvarchar](225) NULL,
	[phieuso] [nvarchar](50) NULL,
	[sotien] [float] NULL,
 CONSTRAINT [PK_Rptphieuxuatkhohead] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPtsoQuy]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPtsoQuy](
	[loaiquy] [nvarchar](50) NULL,
	[tungay] [datetime] NULL,
	[denngay] [datetime] NULL,
	[nodauky] [float] NULL,
	[codauky] [float] NULL,
	[psno] [float] NULL,
	[psco] [float] NULL,
	[cocuoiky] [float] NULL,
	[nocuoiky] [float] NULL,
	[tencongty] [nvarchar](225) NULL,
	[masothue] [nvarchar](50) NULL,
	[diachicongty] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[taikhoan] [nvarchar](50) NULL,
 CONSTRAINT [PK_RPtsoQuy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_congty]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_congty](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tengiamdoc] [nvarchar](50) NULL,
	[diachicoty] [nvarchar](225) NULL,
	[tencongty] [nvarchar](225) NULL,
	[Masothue] [nvarchar](50) NULL,
	[chedoketoanapdung] [nvarchar](225) NULL,
	[tenketoantruong] [nvarchar](50) NULL,
 CONSTRAINT [PK_congty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_ctkhachhang]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ctkhachhang](
	[Matk] [nchar](10) NULL,
	[NameTk] [nchar](50) NULL,
	[No] [float] NULL,
	[Co] [float] NULL,
	[SoduDk] [float] NULL,
	[SoduCk] [float] NULL,
	[SoduHT] [float] NULL,
	[Diengiai] [nchar](225) NULL,
	[SophuTK] [nchar](10) NULL,
	[Sophu] [bit] NOT NULL,
	[Ghichu] [nchar](225) NULL,
	[Ngayghiso] [datetime] NULL,
	[Ngayctu] [datetime] NULL,
	[SochitietTK] [nchar](10) NULL,
	[Sochitiet] [bit] NOT NULL,
	[Nghiepvuso] [int] NULL,
	[id] [int] NOT NULL,
 CONSTRAINT [PK_Sochitiet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_ctnganhang]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ctnganhang](
	[Matk] [nchar](10) NULL,
	[NameTk] [nchar](50) NULL,
	[No] [float] NULL,
	[Co] [float] NULL,
	[SoduDk] [float] NULL,
	[SoduCk] [float] NULL,
	[SoduHT] [float] NULL,
	[Diengiai] [nchar](225) NULL,
	[SophuTK] [nchar](10) NULL,
	[Sophu] [bit] NOT NULL,
	[Ghichu] [nchar](225) NULL,
	[Ngayghiso] [datetime] NULL,
	[Ngayctu] [datetime] NULL,
	[SochitietTK] [nchar](10) NULL,
	[Sochitiet] [bit] NOT NULL,
	[Nghiepvuso] [int] NULL,
	[id] [int] NOT NULL,
 CONSTRAINT [PK_Sochitiettnganhang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_ctnhacungcap]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ctnhacungcap](
	[Matk] [nchar](10) NULL,
	[NameTk] [nchar](50) NULL,
	[No] [float] NULL,
	[Co] [float] NULL,
	[SoduDk] [float] NULL,
	[SoduCk] [float] NULL,
	[SoduHT] [float] NULL,
	[Diengiai] [nchar](225) NULL,
	[SophuTK] [nchar](10) NULL,
	[Sophu] [bit] NOT NULL,
	[Ghichu] [nchar](225) NULL,
	[Ngayghiso] [datetime] NULL,
	[Ngayctu] [datetime] NULL,
	[SochitietTK] [nchar](10) NULL,
	[Sochitiet] [bit] NOT NULL,
	[Nghiepvuso] [int] NULL,
	[id] [int] NOT NULL,
 CONSTRAINT [PK_Sochitietncc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_cttamung]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_cttamung](
	[Matk] [nchar](10) NULL,
	[NameTk] [nchar](50) NULL,
	[No] [float] NULL,
	[Co] [float] NULL,
	[SoduDk] [float] NULL,
	[SoduCk] [float] NULL,
	[SoduHT] [float] NULL,
	[Diengiai] [nchar](225) NULL,
	[SophuTK] [nchar](10) NULL,
	[Sophu] [bit] NOT NULL,
	[Ghichu] [nchar](225) NULL,
	[Ngayghiso] [datetime] NULL,
	[Ngayctu] [datetime] NULL,
	[SochitietTK] [nchar](10) NULL,
	[Sochitiet] [bit] NOT NULL,
	[Nghiepvuso] [int] NULL,
	[id] [int] NOT NULL,
 CONSTRAINT [PK_Sochitiettamung] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Customer]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[tbl_Customer](
	[Customer] [float] NULL,
	[SalesOrg] [nvarchar](10) NULL,
	[FullNameN] [nvarchar](255) NULL,
	[Street] [nvarchar](255) NULL,
	[District] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[Region] [nvarchar](10) NULL,
	[Telephone1] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentTerms] [nchar](10) NULL,
	[PriceList] [nchar](10) NULL,
	[KeyAcc] [nvarchar](50) NULL,
	[SalesDistrict] [nvarchar](50) NULL,
	[CreatedOn] [date] NULL,
	[ReconciliationAcct] [nvarchar](50) NULL,
	[VATregistrationNo] [nvarchar](50) NULL,
	[CentralOrBlk] [nvarchar](50) NULL,
	[OrBlk] [varchar](50) NULL,
	[CTDescription] [nvarchar](225) NULL,
	[KANAME] [nvarchar](225) NULL,
	[UPDDAT] [date] NULL,
	[CCDescription] [nvarchar](225) NULL,
	[KAGROUP] [nvarchar](50) NULL,
	[CHN] [nvarchar](50) NULL,
	[BU] [nvarchar](50) NULL,
	[Vendor] [nvarchar](50) NULL,
	[Createdby] [nvarchar](50) NULL,
	[Representative] [nvarchar](225) NULL,
	[Grpcode] [bit] NOT NULL,
	[SFAcode] [bit] NOT NULL,
	[SapCode] [bit] NOT NULL,
	[indirectCode] [bit] NOT NULL,
	[SALORG_CTR] [nchar](10) NULL,
 CONSTRAINT [PK_tblCustomer_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_danhsachkhachang]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_danhsachkhachang](
	[makhachhang] [nvarchar](50) NULL,
	[tenkhachhang] [nvarchar](255) NULL,
	[sonha] [nvarchar](255) NULL,
	[duongpho] [nvarchar](255) NULL,
	[huyenquan] [nvarchar](255) NULL,
	[thanhpho] [nvarchar](10) NULL,
	[dienthoai] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[masothue] [nvarchar](50) NULL,
	[sotaikhoannganhang] [nvarchar](50) NULL,
	[tennganhang] [nvarchar](225) NULL,
	[ghichunganhnghe] [nvarchar](225) NULL,
	[nguoidaidien] [nvarchar](225) NULL,
	[quocgia] [nvarchar](10) NULL,
	[usertao] [nvarchar](50) NULL,
	[ngaytao] [datetime] NULL,
 CONSTRAINT [PK_tbl_danhsachkhachang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_danhsachnhacungcap]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_danhsachnhacungcap](
	[maNcc] [nvarchar](50) NULL,
	[tenNcc] [nvarchar](255) NULL,
	[sonha] [nvarchar](255) NULL,
	[duongpho] [nvarchar](255) NULL,
	[huyenquan] [nvarchar](255) NULL,
	[thanhpho] [nvarchar](10) NULL,
	[dienthoai] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[masothue] [nvarchar](50) NULL,
	[sotaikhoannganhang] [nvarchar](50) NULL,
	[tennganhang] [nvarchar](225) NULL,
	[ghichunganhnghe] [nvarchar](225) NULL,
	[nguoidaidien] [nvarchar](225) NULL,
	[quocgia] [nvarchar](10) NULL,
	[usertao] [nvarchar](50) NULL,
	[ngaytao] [datetime] NULL,
 CONSTRAINT [PK_tbl_danhsachnhacungcap] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_DonhangtheoSPvaMKH]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DonhangtheoSPvaMKH](
	[So_van_don] [nvarchar](255) NULL,
	[A/R_Amount] [float] NULL,
	[Material] [nvarchar](255) NULL,
	[Seri] [nvarchar](255) NULL,
	[TEN_HANG] [nvarchar](255) NULL,
	[ShipTo_Name] [nvarchar](255) NULL,
	[ShipTo_Tel] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[Deadline] [nvarchar](255) NULL,
	[NOTE] [nvarchar](255) NULL,
	[District] [nvarchar](255) NULL,
	[Dia_chi] [nvarchar](255) NULL,
	[Delivery_Qty] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[macty] [nvarchar](50) NULL,
	[biensoxe] [nvarchar](50) NULL,
	[ngayghepdon] [datetime] NULL,
	[manhaxe] [nvarchar](50) NULL,
	[tennhaxe] [nvarchar](50) NULL,
	[loaidon] [nvarchar](50) NULL,
	[loadnumber] [nvarchar](50) NULL,
	[Gia_VChuyen] [float] NULL,
	[Tempview] [int] NOT NULL CONSTRAINT [DF_tbl_netcoDonhang_Tempview]  DEFAULT ((1)),
	[Gia_Thue] [float] NULL,
	[Ngayvanchuyen] [datetime] NULL,
	[maKH] [nvarchar](50) NULL,
	[NhomSP] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_netcoDonhang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_DonhangtheoSPvaMKHTemp]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DonhangtheoSPvaMKHTemp](
	[So_van_don] [nvarchar](255) NULL,
	[A/R_Amount] [float] NULL,
	[Material] [nvarchar](255) NULL,
	[Seri] [nvarchar](255) NULL,
	[TEN_HANG] [nvarchar](255) NULL,
	[ShipTo_Name] [nvarchar](255) NULL,
	[ShipTo_Tel] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[Deadline] [nvarchar](255) NULL,
	[NOTE] [nvarchar](255) NULL,
	[District] [nvarchar](255) NULL,
	[Dia_chi] [nvarchar](255) NULL,
	[Delivery_Qty] [float] NULL,
	[Username] [nvarchar](50) NULL,
	[Uploadstatus] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[macty] [nvarchar](50) NULL,
	[makhachhang] [nvarchar](50) NULL,
	[Gia_VChuyen] [float] NULL,
	[mainid] [int] NULL,
	[Gia_thue] [float] NULL,
	[Ngayvanchuyen] [datetime] NULL,
	[maKH] [nvarchar](50) NULL,
	[NhomSP] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_netcoDonhangTMP] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_DonhangtheoSPvaMKHThauPhu]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DonhangtheoSPvaMKHThauPhu](
	[City] [nvarchar](255) NULL,
	[Ma_NVT] [nvarchar](50) NULL,
	[District] [nvarchar](255) NULL,
	[TEN_HANG] [nvarchar](255) NULL,
	[Cuoc_Van_Chuyen] [float] NULL,
	[Fromdate] [datetime] NULL,
	[Todate] [datetime] NULL,
	[Username] [nvarchar](50) NULL,
	[macty] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tbl_netcoGiaNhaThau] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_dstaikhoan]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_dstaikhoan](
	[matk] [nchar](10) NULL,
	[tentk] [nchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[captk] [int] NOT NULL CONSTRAINT [DF_tbl_dstaikhoan_captk]  DEFAULT ((1)),
	[matktren] [nchar](10) NULL CONSTRAINT [DF_tbl_dstaikhoan_matktren]  DEFAULT ((0)),
	[loaitkid] [nchar](50) NULL CONSTRAINT [DF_tbl_dstaikhoan_loaitkid]  DEFAULT ((4)),
	[loaichitiet] [bit] NOT NULL CONSTRAINT [DF_tbl_dstaikhoan_loaichitiet]  DEFAULT ((0)),
	[nodk] [float] NULL CONSTRAINT [DF_tbl_dstaikhoan_nodk]  DEFAULT ((0)),
	[codk] [float] NULL CONSTRAINT [DF_tbl_dstaikhoan_codk]  DEFAULT ((0)),
	[maKQKD] [nvarchar](10) NULL,
	[maCDKT] [nvarchar](10) NULL,
	[maLCTT] [nvarchar](10) NULL,
 CONSTRAINT [PK_tbl_dstaikhoan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_GiaHDtheoMCTvaSP]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_GiaHDtheoMCTvaSP](
	[City] [nvarchar](255) NULL,
	[District] [nvarchar](255) NULL,
	[TENHANG] [nvarchar](255) NULL,
	[Gia] [float] NULL,
	[Fromdate] [datetime] NULL,
	[Todate] [datetime] NULL,
	[Username] [nvarchar](50) NULL,
	[macty] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[maKH] [nvarchar](50) NULL,
	[NhomSP] [nvarchar](50) NULL,
	[maSP] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_netcoGiaHD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_GiaHDtheoMCTvaSPTemp]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_GiaHDtheoMCTvaSPTemp](
	[City] [nvarchar](255) NULL,
	[District] [nvarchar](255) NULL,
	[TENHANG] [nvarchar](255) NULL,
	[Gia] [float] NULL,
	[Fromdate] [datetime] NULL,
	[Todate] [datetime] NULL,
	[Username] [nvarchar](50) NULL,
	[macty] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tbl_netcoGiaHDTemp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_kho_dichvu]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_kho_dichvu](
	[madv] [nvarchar](50) NULL,
	[tendv] [nvarchar](225) NULL,
	[mavach] [nvarchar](50) NULL,
	[donvi] [nvarchar](10) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idmanhomsp] [nvarchar](10) NULL,
	[ghichu] [nvarchar](225) NULL,
 CONSTRAINT [PK_tbl_kho_dichvu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_kho_nhomsanpham]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_kho_nhomsanpham](
	[manhomsanpham] [nchar](10) NULL,
	[tennhomsanpham] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_manhomsanpham] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_kho_phieunhap_detail]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_kho_phieunhap_detail](
	[mahang] [nvarchar](50) NULL,
	[tenhang] [nvarchar](225) NULL,
	[donvi] [nvarchar](10) NULL,
	[dongia] [float] NULL,
	[thanhtien] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[phieuso] [nvarchar](50) NULL,
	[soluongyeucau] [float] NULL,
	[soluongnhap] [float] NULL,
	[subid] [int] NULL,
	[makho] [nvarchar](50) NULL,
	[ngayphieunhap] [datetime] NULL,
	[macty] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_kho_detail_phieunhapkho] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_kho_phieunhap_head]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_kho_phieunhap_head](
	[ngayphieunhap] [datetime] NULL,
	[nguoigiao] [nvarchar](50) NULL,
	[theodonhang] [nvarchar](225) NULL,
	[makho] [nvarchar](50) NULL,
	[hoadondikhem] [nvarchar](50) NULL,
	[notk] [nvarchar](50) NULL,
	[cotk] [nvarchar](50) NULL,
	[createby] [nvarchar](50) NULL,
	[createdate] [datetime] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[phieuso] [nvarchar](50) NULL,
	[MaCTietTKCo] [int] NULL,
	[MaCTietTKNo] [int] NULL,
	[diengiai] [nvarchar](225) NULL,
	[sotien] [float] NULL,
	[TenCTietTKCo] [nvarchar](225) NULL,
	[TenCTietTKNo] [nvarchar](225) NULL,
	[tenkho] [nvarchar](225) NULL,
	[macty] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_kho_head_phieunhapkho] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_kho_phieuxuat_detail]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_kho_phieuxuat_detail](
	[mahang] [nvarchar](50) NULL,
	[tenhang] [nvarchar](225) NULL,
	[donvi] [nvarchar](10) NULL,
	[dongia] [float] NULL,
	[thanhtien] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[phieuso] [nvarchar](50) NULL,
	[soluongyeucau] [float] NULL,
	[soluongxuat] [float] NULL,
	[subid] [int] NULL,
	[makho] [nvarchar](50) NULL,
	[ngayphieuxuat] [datetime] NULL,
	[macty] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_kho_detail_phieuxuatkho] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_kho_phieuxuat_head]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_kho_phieuxuat_head](
	[ngayphieuxuat] [datetime] NULL,
	[nguoinhanhang] [nvarchar](50) NULL,
	[diachibophan] [nvarchar](225) NULL,
	[makho] [nvarchar](50) NULL,
	[hoadondikhem] [nvarchar](50) NULL,
	[notk] [nvarchar](50) NULL,
	[cotk] [nvarchar](50) NULL,
	[createby] [nvarchar](50) NULL,
	[createdate] [datetime] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[phieuso] [nvarchar](50) NULL,
	[MaCTietTKCo] [int] NULL,
	[MaCTietTKNo] [int] NULL,
	[diengiai] [nvarchar](225) NULL,
	[sotien] [float] NULL,
	[TenCTietTKCo] [nvarchar](225) NULL,
	[TenCTietTKNo] [nvarchar](225) NULL,
	[tenkho] [nvarchar](225) NULL,
	[macty] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_kho_head_phieuxuatkho] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_kho_sanpham]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_kho_sanpham](
	[masp] [nvarchar](50) NULL,
	[tensp] [nvarchar](225) NULL,
	[mavach] [nvarchar](50) NULL,
	[donvi] [nvarchar](10) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[trongluong] [float] NULL,
	[khoiluong] [float] NULL,
	[idmanhomsp] [nvarchar](10) NULL,
	[ghichu] [nvarchar](225) NULL,
	[tondksoluong] [float] NULL CONSTRAINT [DF_tbl_kho_sanpham_tondksoluong]  DEFAULT ((0)),
	[tondkthanhtien] [float] NULL CONSTRAINT [DF_tbl_kho_sanpham_tondkthanhtien]  DEFAULT ((0)),
	[makho] [nvarchar](10) NULL,
	[tenkho] [nvarchar](225) NULL,
	[macty] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_kho_sanpham] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_khohang]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_khohang](
	[tenkho] [nvarchar](50) NULL,
	[makho] [nvarchar](10) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[diachikho] [nvarchar](50) NULL,
	[ghichu] [nvarchar](50) NULL,
	[macty] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_khohang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_loaitk]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_loaitk](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NULL,
	[idloaitk] [nchar](50) NULL,
 CONSTRAINT [PK_tbl_loaitk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_machitiettk]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_machitiettk](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenchitiet] [nvarchar](50) NULL,
	[matk] [nvarchar](50) NULL,
	[machitiet] [int] NULL,
	[ghichu] [nvarchar](225) NULL,
	[nodk] [float] NULL CONSTRAINT [DF_tbl_machitiettk_nodk]  DEFAULT ((0)),
	[codk] [float] NULL CONSTRAINT [DF_tbl_machitiettk_codk]  DEFAULT ((0)),
 CONSTRAINT [PK_tbl_machitiettk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_NP_danhsachxe]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NP_danhsachxe](
	[maNVT] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bienso] [nvarchar](50) NULL,
	[tenlaixe] [nvarchar](225) NULL,
	[cmtlaixe] [nvarchar](50) NULL,
	[dienthoailaixe] [nvarchar](50) NULL,
	[sotantai] [float] NULL,
	[sokhoithungxe] [float] NULL,
	[tenNVT] [nvarchar](225) NULL,
 CONSTRAINT [PK_tbl_danhsachxe] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_NP_giavantaitheotuyen]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NP_giavantaitheotuyen](
	[maKH] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[matuyen] [nvarchar](225) NULL,
	[tentuyen] [nvarchar](225) NULL,
	[loaidonxe] [float] NULL,
	[km] [float] NULL,
	[trichcongty] [float] NULL,
	[giathue] [float] NULL,
	[giahoadon] [float] NULL,
	[trichdoitac] [float] NULL,
	[dtkhac] [float] NULL,
	[bocxep] [float] NULL,
	[giadau] [float] NULL,
	[dinhmucdau] [float] NULL,
	[cfxang] [float] NULL,
	[cflaixe] [float] NULL,
	[cfcongan] [float] NULL,
	[cfcauduong] [float] NULL,
	[cfkhauhao] [float] NULL,
	[tongcfuoctinh] [float] NULL,
	[ghichucf] [nvarchar](225) NULL,
	[lntuyen] [float] NULL,
	[ngayapdung] [datetime] NULL,
	[ngayhethan] [datetime] NULL CONSTRAINT [DF_tbl_NP_giavantaitheotuyen_ngayhethan]  DEFAULT (((311)/(12))/(9999)),
 CONSTRAINT [PK_tbl_giavantaitheotuyen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_NP_khachhangvanchuyen]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NP_khachhangvanchuyen](
	[maKH] [nvarchar](50) NULL,
	[tenKH] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[diachiKH] [nvarchar](225) NULL,
	[masothueKH] [nvarchar](225) NULL,
	[sotaikhoannganhangKH] [nvarchar](225) NULL,
	[diachinganhangKH] [nvarchar](225) NULL,
 CONSTRAINT [PK_tbl_khachhangvanchuyen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_NP_Nhacungungvantai]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NP_Nhacungungvantai](
	[tenNVT] [nvarchar](225) NULL,
	[maNVT] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[diachiNVT] [nvarchar](225) NULL,
	[masothueNVT] [nvarchar](225) NULL,
	[dienthoaiNVT] [nvarchar](225) NULL,
	[sotaikhoannganhangNVT] [nvarchar](225) NULL,
	[diachinganhangNVT] [nvarchar](225) NULL,
 CONSTRAINT [PK_tbl_Nhacungungvantai] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_shipment]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_shipment](
	[So_van_don] [nvarchar](255) NULL,
	[So_Shipment] [nvarchar](255) NULL,
	[Bien_so_xe] [nvarchar](255) NULL,
	[Ma_Nha_xe] [nvarchar](255) NULL,
	[Ten_Nha_xe] [nvarchar](255) NULL,
	[Loai_Don] [nvarchar](255) NULL,
	[Ngay_giao_hang] [datetime] NOT NULL,
	[Tien_cuoc_thu_ve] [float] NULL,
	[Tien_cuoc_tra_NCC] [float] NULL,
	[Username] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[macty] [nvarchar](50) NULL,
	[makhachhang] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_shipmentTMP] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Socai]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Socai](
	[Diengiai] [nchar](225) NULL,
	[Ngayghiso] [datetime] NULL,
	[Ngayctu] [datetime] NULL,
	[manghiepvu] [nvarchar](10) NULL,
	[username] [nvarchar](10) NULL,
	[TkNo] [nvarchar](10) NULL,
	[TkCo] [nvarchar](10) NULL,
	[MaCTietTKCo] [int] NULL,
	[MaCTietTKNo] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenchitietCo] [nvarchar](225) NULL,
	[tenchitietNo] [nvarchar](225) NULL,
	[PsNo] [float] NULL,
	[PsCo] [float] NULL,
	[Sohieuchungtu] [nvarchar](50) NULL,
	[nganhan] [bit] NULL CONSTRAINT [DF_tbl_Socai_nganhan_1]  DEFAULT ((1)),
	[macty] [nvarchar](50) NULL,
 CONSTRAINT [PK_Socai] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_SoQuy]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SoQuy](
	[TKtienmat] [nvarchar](10) NULL,
	[ChitietTM] [int] NULL,
	[Ngayctu] [datetime] NOT NULL,
	[Machungtu] [nvarchar](10) NULL,
	[PsNo] [float] NULL,
	[PsCo] [float] NULL,
	[Diengiai] [nvarchar](225) NULL,
	[Chitietdoiung] [int] NULL,
	[Nguoinopnhantien] [nvarchar](100) NULL,
	[Diachinguoinhannop] [nvarchar](225) NULL,
	[Chungtugockemtheo] [int] NOT NULL,
	[Ngayghiso] [datetime] NULL,
	[Username] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TKdoiung] [nvarchar](225) NULL,
	[TenchitietTM] [nvarchar](225) NULL,
	[Sophieu] [nvarchar](50) NULL,
	[requestAproval] [bit] NOT NULL CONSTRAINT [DF_tbl_SoQuy_requestAproval]  DEFAULT ((0)),
	[fundcheckout] [bit] NOT NULL CONSTRAINT [DF_tbl_SoQuy_fundcheckout]  DEFAULT ((0)),
	[cashavancerequest] [bit] NOT NULL CONSTRAINT [DF_tbl_SoQuy_cashavancerequest]  DEFAULT ((0)),
	[cashadvandapproval1] [bit] NOT NULL CONSTRAINT [DF_tbl_SoQuy_cashadvandapproval1]  DEFAULT ((0)),
	[cashadvanapproval2] [bit] NOT NULL CONSTRAINT [DF_tbl_SoQuy_cashadvanapproval2]  DEFAULT ((0)),
	[macty] [nvarchar](50) NULL,
 CONSTRAINT [PK_SoQuy2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Temp]    Script Date: 1/16/2019 5:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Temp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Version] [int] NULL,
	[RegionCode] [nchar](225) NULL,
	[Username] [nchar](225) NULL,
	[Password] [nchar](225) NULL,
	[Userright] [int] NULL,
	[Note] [nchar](225) NULL,
	[Inputcontract] [bit] NOT NULL CONSTRAINT [DF_tbl_Temp_inputcontract]  DEFAULT ((0)),
	[Name] [nvarchar](50) NULL,
	[Phân_quyền] [bit] NOT NULL CONSTRAINT [DF_tbl_Temp_Inputcontract1]  DEFAULT ((0)),
	[Thiết_lập_tài_khoản] [bit] NOT NULL CONSTRAINT [DF_tbl_Temp_Thiết_lập_tài_khoản]  DEFAULT ((1)),
	[Macty] [nvarchar](50) NULL,
 CONSTRAINT [PK_temp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CDKT200Dauky] ON 

INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 111, N'1. Tiền', N' Dư Nợ TK 111, 112, 113', 0, 1, 1, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 112, N'2. Các khoản tương đương tiền', N'Dư Nợ TK 1281,1288 - Thời hạn gốc không quá 3 tháng', 0, 1, 2, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 121, N'1. Chứng khoán kinh doanh', N' Dư Nợ TK 121 - dưới 12 tháng', 0, 1, 3, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 122, N'2. Dự phòng giảm giá chứng khoán kinh doanh (*)', N'Dư có 2291 (Ghi âm) < 12 tháng', 0, 1, 4, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 123, N'3. Đầu tư nắm giữ đến ngày đáo hạn', N'Dự 1281, 1282, 1288 - MS112', 0, 1, 5, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 131, N'1. Phải thu ngắn hạn của khách hàng', N' Dư Nợ chi tiết TK 131 - dưới 1 năm', 0, 0, 6, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 132, N'2. Trả trước cho người bán ngắn hạn', N' Dư Nợ chi tiết TK 331 - dưới 1 năm ', 0, 0, 7, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 133, N'3. Phải thu nội bộ ngắn hạn', N'Dư Nợ chi tiết TK 1362,1363,1368 –
 dưới 1 năm', 0, 0, 8, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 134, N'4. Phải thu theo tiến độ kế hoạch hợp đồng xây dựng', N'Dư Nợ TK 337', 0, 1, 9, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 135, N'5. Phải thu về cho vay ngắn hạn', N' Dư Nợ chi tiết TK 1283 - dưới 1 năm', 0, 1, 10, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 136, N'6. Phải thu ngắn hạn khác', N'Dư Nợ chi tiết TK 1385, 1388, 334,
 338, 141, 244 - dưới 1 năm', 0, 1, 11, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 137, N'7. Dự phòng phải thu ngắn hạn khó đòi (*)', N'Dư Có chi tiết TK 2293 - dưới 1 năm', 0, 1, 12, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 139, N'8. Tài sản thiếu chờ xử lý', N'Dư Nợ TK 1381', 0, 1, 13, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 141, N'1. Hàng tồn kho', N'Dư Nợ TK 151, 152, 153, 154, 155,
 156, 157, 158', 0, 1, 14, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 149, N'2. Dự phòng giảm giá hàng tồn kho (*)', N'Dư Có chi tiết TK 2294 (Ghi âm)', 0, 1, 15, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 151, N'1. Chi phí trả trước ngắn hạn', N'Dư Nợ chi tiết TK 242 < 12 tháng', 0, 1, 16, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 152, N'2. Thuế giá trị gia tăng được khấu trừ', N' Dư Nợ TK 133', 0, 1, 17, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 153, N'3. Thuế và các khoản phải thu Nhà nước', N'Dư Nợ chi tiết TK 333', 0, 1, 18, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 154, N'4. Giao dịch mua bán lại trái phiếu chính phủ', N'Dư Nợ TK 171', 0, 1, 19, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 155, N'5. Tài sản ngắn hạn khác', N' Dư Nợ chi tiết TK 2288 - dưới 12 tháng', 0, 1, 20, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 211, N'1. Phải thu dài hạn của khách hàng', N'Dư Nợ chi tiết TK 131 > 12 tháng', 0, 1, 21, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 212, N'2. Trả trước cho người bán dài hạn', N'Dư Nợ chi tiết TK 331 > 12 tháng ', 0, 1, 22, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 213, N'3. Vốn kinh doanh ở đơn vị trực thuộc', N'Dư Nợ TK 1361', 0, 1, 23, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 214, N'4. Phải thu nội bộ dài hạn', N'	
 Dư Nợ chi tiết TK 1362, 1363,
1368 - trên 12 tháng', 0, 1, 24, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 215, N'5. Phải thu về cho vay dài hạn', N'Dư Nợ chi tiết TK 1283 - trên
12 tháng', 0, 1, 25, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 216, N'6. Phải thu dài hạn khác', N' Dư Nợ chi tiết TK 1385, 1388, 334,
 338, 141, 244 - dưới 12 tháng', 0, 1, 26, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 219, N'7. Dự phòng phải thu dài hạn khó đòi (*)', N' Dư Có chi tiết TK 2293 - trên
12 tháng', 0, 1, 27, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 222, N' Nguyên giá cố định hữu hình', N'Dư  Nợ TK 211', 0, 1, 28, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 223, N'Giá trị hao mòn luỹ kế (* cố định hữu hình)', N'Dư  Có TK 2141', 0, 1, 29, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 225, N'Nguyên giá Tài sản cố định thuê tài chính', N'Dư  Nợ TK 212', 0, 1, 30, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 226, N' Giá trị hao mòn luỹ kế (*) Tài sản cố định thuê tài chính', N'Dư  Có TK 2142', 0, 1, 31, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 228, N'Nguyên giá Tài sản cố định vô hình', N' Dư  Nợ TK 213', 0, 1, 32, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 229, N'Giá trị hao mòn luỹ kế (*) Tài sản cố định vô hình', N' Dư  Có TK 2143', 0, 1, 33, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 231, N'1. Nguyên giá Bất động sản đầu tư', N'Dư  Nợ TK 217', 0, 1, 34, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 232, N'2. Giá trị hao mòn luỹ kế (*) Bất động sản đầu tư', N'Dư  Có TK 2147', 0, 1, 35, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 241, N'1. Chi phí sản xuất kinh doanh dở dang dài hạn', N'Dư Nợ chi tiết TK 154 và dư Có
chi tiết TK 2294 - trên 12 tháng', 0, 1, 36, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 242, N'2. Chi phí xây dựng cơ bản dở dang', N'Dư Nợ TK 241', 0, 1, 37, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 251, N'1. Đầu tư vào công ty con', N'Dư  Nợ TK 221', 0, 1, 38, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 252, N'2. Đầu tư vào công ty liên doanh liên kết', N'Dư  Nợ TK 222', 0, 1, 39, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 253, N'3. Đầu tư góp vốn vào đơn vị khác', N'Dư  Nợ chi tiết TK 2281', 0, 1, 40, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 254, N'4. Dự phòng đầu tư tài chính dài hạn (*)', N'	
 Dư  Có chi tiết TK 2292', 0, 1, 41, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 255, N'5. Đầu tư nắm giữ đến ngày đáo hạn', N'Dư Nợ TK 1281, 1282, 1288 - trên
12 tháng', 0, 1, 42, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 261, N'1. Chi phí trả trước dài hạn', N' Dư  Nợ chi tiết TK 242 - trên
12 tháng', 0, 1, 43, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 262, N'2. Tài sản thuế thu nhập hoãn lại', N'Dư  Nợ TK 243', 0, 1, 44, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 263, N'3. Thiết bị, vật tư, phụ tùng thay thế dài hạn', N' Dư Nợ chi tiết TK 1534 và dư Có
chi tiết TK 2294 - trên 12 tháng', 0, 1, 45, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 268, N'4. Tài sản dài hạn khác', N'Dư  Nợ chi tiết TK 2288', 0, 1, 46, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 311, N'1. Phải trả người bán ngắn hạn', N'Dư Có chi tiết TK 331 < 12 tháng', 0, 1, 47, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 312, N'2. Người mua trả tiền trước ngắn hạn', N'Dư Có chi tiết TK 131 < 12 tháng', 0, 1, 48, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 313, N'3. Thuế và các khoản phải nộp Nhà nước', N'Dư Có TK 333 - dưới 12 tháng', 0, 1, 49, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 314, N'4. Phải trả người lao động', N'Dư Có TK 334 - dưới 12 tháng', 0, 1, 50, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 315, N'5. Chi phí phải trả ngắn hạn', N' Dư Có TK 335 - dưới 12 tháng', 0, 1, 51, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 316, N'6. Phải trả nội bộ ngắn hạn', N'Dư Có chi tiết TK 3362, 3363,
3368 - dưới 12 tháng', 0, 1, 52, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 317, N'7. Phải trả theo tiến độ kế hoạch hợp đồng xây dựng', N'Dư Có TK 337', 0, 1, 53, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 318, N'8. Doanh thu chưa thực hiện ngắn hạn', N'Dư Có chi tiết TK 3387 < 12 tháng', 0, 1, 54, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 319, N'9. Phải trả ngắn hạn khác', N'Dư Có chi tiết TK 338, 138,
344 - dưới 12 tháng', 0, 1, 55, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 320, N'10. Vay và nợ thuê tài chính ngắn hạn', N' Dư Có chi tiết TK 341 và 34311 ', 0, 1, 56, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 321, N'11. Dự phòng phải trả ngắn hạn', N' Dư Có chi tiết TK 352 - dưới
12 tháng', 0, 1, 57, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 322, N'12. Quỹ khen thưởng phúc lợi', N' Dư Có của TK 353', 0, 1, 58, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 323, N'13. Quỹ bình ổn giá', N' Dư Có của TK 357', 0, 1, 59, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 324, N'14. Giao dịch mua bán lại trái phiếu chính phủ', N'Dư Có TK 171', 0, 1, 60, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 331, N'1. Phải trả người bán dài hạn', N' Dư Có TK 331 - Thời hạn trên
12 tháng', 0, 1, 61, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 332, N'2. Người mua trả tiền trước dài hạn', N' Dư Có chi tiết TK 131 - Thời hạn
trên 12 tháng', 0, 1, 62, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 333, N'3. Chi phí phải trả dài hạn', N'Dư Có TK 335 - Thời hạn
trên 12 tháng', 0, 1, 63, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 334, N'4. Phải trả nội bộ về vốn kinh doanh', N'Dư Có chi tiết TK 3361', 0, 1, 64, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 335, N'5. Phải trả nội bộ dài hạn', N' Dư Có chi tiết TK 3362, 3363,
3368 - Thời hạn trên 12 tháng', 0, 1, 65, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 336, N'6. Doanh thu chưa thực hiện dài hạn', N'Dư Có chi tiết TK3387 –
trên 12 tháng', 0, 1, 66, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 337, N'7. Phải trả dài hạn khác', N'Dư Có chi tiết TK 338, 344
trên 12 tháng', 0, 1, 67, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 338, N'8. Vay và nợ thuê tài chính dài hạn', N'Dư Có chi tiết TK 341 và
Dư Có TK 34311 trừ (-) dư Nợ TK
34312 cộng (+) dư Có TK 34313.', 0, 1, 68, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 339, N'9. Trái phiếu chuyển đổi', N'Dư Có chi tiết của TK 3432 ', 0, 1, 69, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 340, N'0. Cổ phiếu ưu đãi', N'Dư Có chi tiết TK 41112 –
chi tiết Nợ phải trả', 0, 1, 70, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 341, N'1. Thuế thu nhập hoãn lại phải trả', N'Dư Có TK 347', 0, 1, 71, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 342, N'12. Dự phòng phải trả dài hạn', N'Dư Có chi tiết TK 352 >12 tháng', 0, 1, 72, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 343, N'13. Quỹ phát triển khoa học và công nghệ', N'Dư Có của TK 356', 0, 1, 73, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 411, N'1. Vốn góp của chủ sở hữu', N'Dư Có TK 4111', 0, 1, 74, N'tr1')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 4111, N'Cổ phiếu phổ thông có quyền biểu quyết
', N'Dư Có TK 41111', 0, 1, 75, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 4112, N'Cổ phiếu ưu đẫi', N'Dư Có chi tiết TK 41112', 0, 1, 76, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 412, N'2. Thặng dư vốn cổ phần', N' Số dư TK 4112 (Dư Nợ: ghi âm)', 0, 1, 77, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 413, N'3. Quyền chọn chuyển đổi trái phiếu', N' Dư Có chi tiết TK 4113', 0, 1, 78, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 414, N'4. Vốn khác của chủ sở hữu', N'Dư Có Tài khoản 4118', 0, 1, 79, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 415, N'5. Cổ phiếu quỹ (*)', N'Dư Nợ TK 419 (ghi âm)', 0, 1, 80, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 416, N'6. Chênh lệch đánh giá lại tài sản', N'Số dư Có TK 412, (Dư Nợ: ghi âm)', 0, 1, 81, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 417, N'7. Chênh lệch tỷ giá hối đoái', N'Số dư Có TK 413 (Dư Nợ: ghi âm)', 0, 1, 82, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 418, N'8. Quỹ đầu tư phát triển', N' Dư Có TK 414', 0, 1, 83, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 419, N'9. Quỹ hỗ trợ sắp xếp doanh nghiệp', N'Dư Có TK 417', 0, 1, 84, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 420, N'10. Quỹ khác thuộc vốn chủ sở hữu', N'Dư Có TK 418', 0, 1, 85, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 421, N'11. Lợi nhuận sau thuế chưa phân phối', N' Số dư TK 421', 0, 1, 86, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 4211, N'- LNST chưa phân phối lũy kế đến cuối kỳ trước', N' Số Dư TK 4211 (Dư Nợ: ghi âm)', 0, 1, 87, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 4212, N'- LNST chưa phân phối kỳ này', N'Số Dư TK 4212 (Dư Nợ: ghi âm)', 0, 1, 88, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 422, N'12. Nguồn vốn đầu tư XDCB', N' Dư Có TK 441', 0, 1, 89, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 431, N'1. Nguồn kinh phí', N' Dư Có TK 461 - Dư Nợ TK 161', 0, 1, 90, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2006, 432, N'2. Nguồn kinh phí đã hình thành TSCĐ', N' Dư Có TK 466', 0, 1, 91, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (NULL, NULL, NULL, NULL, NULL, 1, 93, NULL)
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 111, N'1. Tiền', N' Dư Nợ TK 111, 112, 113', 0, 0, 94, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 112, N'2. Các khoản tương đương tiền', N'Dư Nợ TK 1281,1288 - Thời hạn gốc không quá 3 tháng', 0, 0, 95, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 121, N'1. Chứng khoán kinh doanh', N' Dư Nợ TK 121 - dưới 12 tháng', 0, 0, 96, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 122, N'2. Dự phòng giảm giá chứng khoán kinh doanh (*)', N'Dư có 2291 (Ghi âm) < 12 tháng', 0, 0, 97, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 123, N'3. Đầu tư nắm giữ đến ngày đáo hạn', N'Dự 1281, 1282, 1288 - MS112', 0, 0, 98, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 131, N'1. Phải thu ngắn hạn của khách hàng', N' Dư Nợ chi tiết TK 131 - dưới 1 năm', 0, 0, 99, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 132, N'2. Trả trước cho người bán ngắn hạn', N' Dư Nợ chi tiết TK 331 - dưới 1 năm ', 0, 0, 100, N'Mai Văn Trường')
GO
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 133, N'3. Phải thu nội bộ ngắn hạn', N'Dư Nợ chi tiết TK 1362,1363,1368 –
 dưới 1 năm', 0, 0, 101, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 134, N'4. Phải thu theo tiến độ kế hoạch hợp đồng xây dựng', N'Dư Nợ TK 337', 0, 0, 102, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 135, N'5. Phải thu về cho vay ngắn hạn', N' Dư Nợ chi tiết TK 1283 - dưới 1 năm', 0, 0, 103, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 136, N'6. Phải thu ngắn hạn khác', N'Dư Nợ chi tiết TK 1385, 1388, 334,
 338, 141, 244 - dưới 1 năm', 0, 0, 104, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 137, N'7. Dự phòng phải thu ngắn hạn khó đòi (*)', N'Dư Có chi tiết TK 2293 - dưới 1 năm', 0, 0, 105, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 139, N'8. Tài sản thiếu chờ xử lý', N'Dư Nợ TK 1381', 0, 0, 106, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 141, N'1. Hàng tồn kho', N'Dư Nợ TK 151, 152, 153, 154, 155,
 156, 157, 158', 0, 0, 107, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 149, N'2. Dự phòng giảm giá hàng tồn kho (*)', N'Dư Có chi tiết TK 2294 (Ghi âm)', 0, 0, 108, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 151, N'1. Chi phí trả trước ngắn hạn', N'Dư Nợ chi tiết TK 242 < 12 tháng', 0, 0, 109, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 152, N'2. Thuế giá trị gia tăng được khấu trừ', N' Dư Nợ TK 133', 0, 0, 110, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 153, N'3. Thuế và các khoản phải thu Nhà nước', N'Dư Nợ chi tiết TK 333', 0, 0, 111, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 154, N'4. Giao dịch mua bán lại trái phiếu chính phủ', N'Dư Nợ TK 171', 0, 0, 112, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 155, N'5. Tài sản ngắn hạn khác', N' Dư Nợ chi tiết TK 2288 - dưới 12 tháng', 0, 0, 113, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 211, N'1. Phải thu dài hạn của khách hàng', N'Dư Nợ chi tiết TK 131 > 12 tháng', 0, 0, 114, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 212, N'2. Trả trước cho người bán dài hạn', N'Dư Nợ chi tiết TK 331 > 12 tháng ', 0, 0, 115, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 213, N'3. Vốn kinh doanh ở đơn vị trực thuộc', N'Dư Nợ TK 1361', 0, 0, 116, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 214, N'4. Phải thu nội bộ dài hạn', N'	
 Dư Nợ chi tiết TK 1362, 1363,
1368 - trên 12 tháng', 0, 0, 117, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 215, N'5. Phải thu về cho vay dài hạn', N'Dư Nợ chi tiết TK 1283 - trên
12 tháng', 0, 0, 118, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 216, N'6. Phải thu dài hạn khác', N' Dư Nợ chi tiết TK 1385, 1388, 334,
 338, 141, 244 - dưới 12 tháng', 0, 0, 119, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 219, N'7. Dự phòng phải thu dài hạn khó đòi (*)', N' Dư Có chi tiết TK 2293 - trên
12 tháng', 0, 0, 120, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 222, N' Nguyên giá cố định hữu hình', N'Dư  Nợ TK 211', 0, 0, 121, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 223, N'Giá trị hao mòn luỹ kế (* cố định hữu hình)', N'Dư  Có TK 2141', 0, 0, 122, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 225, N'Nguyên giá Tài sản cố định thuê tài chính', N'Dư  Nợ TK 212', 0, 0, 123, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 226, N' Giá trị hao mòn luỹ kế (*) Tài sản cố định thuê tài chính', N'Dư  Có TK 2142', 0, 0, 124, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 228, N'Nguyên giá Tài sản cố định vô hình', N' Dư  Nợ TK 213', 0, 0, 125, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 229, N'Giá trị hao mòn luỹ kế (*) Tài sản cố định vô hình', N' Dư  Có TK 2143', 0, 0, 126, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 231, N'1. Nguyên giá Bất động sản đầu tư', N'Dư  Nợ TK 217', 0, 0, 127, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 232, N'2. Giá trị hao mòn luỹ kế (*) Bất động sản đầu tư', N'Dư  Có TK 2147', 0, 0, 128, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 241, N'1. Chi phí sản xuất kinh doanh dở dang dài hạn', N'Dư Nợ chi tiết TK 154 và dư Có
chi tiết TK 2294 - trên 12 tháng', 0, 0, 129, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 242, N'2. Chi phí xây dựng cơ bản dở dang', N'Dư Nợ TK 241', 0, 0, 130, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 251, N'1. Đầu tư vào công ty con', N'Dư  Nợ TK 221', 0, 0, 131, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 252, N'2. Đầu tư vào công ty liên doanh liên kết', N'Dư  Nợ TK 222', 0, 0, 132, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 253, N'3. Đầu tư góp vốn vào đơn vị khác', N'Dư  Nợ chi tiết TK 2281', 0, 0, 133, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 254, N'4. Dự phòng đầu tư tài chính dài hạn (*)', N'	
 Dư  Có chi tiết TK 2292', 0, 0, 134, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 255, N'5. Đầu tư nắm giữ đến ngày đáo hạn', N'Dư Nợ TK 1281, 1282, 1288 - trên
12 tháng', 0, 0, 135, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 261, N'1. Chi phí trả trước dài hạn', N' Dư  Nợ chi tiết TK 242 - trên
12 tháng', 0, 0, 136, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 262, N'2. Tài sản thuế thu nhập hoãn lại', N'Dư  Nợ TK 243', 0, 0, 137, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 263, N'3. Thiết bị, vật tư, phụ tùng thay thế dài hạn', N' Dư Nợ chi tiết TK 1534 và dư Có
chi tiết TK 2294 - trên 12 tháng', 0, 0, 138, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 268, N'4. Tài sản dài hạn khác', N'Dư  Nợ chi tiết TK 2288', 0, 0, 139, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 311, N'1. Phải trả người bán ngắn hạn', N'Dư Có chi tiết TK 331 < 12 tháng', 0, 0, 140, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 312, N'2. Người mua trả tiền trước ngắn hạn', N'Dư Có chi tiết TK 131 < 12 tháng', 0, 0, 141, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 313, N'3. Thuế và các khoản phải nộp Nhà nước', N'Dư Có TK 333 - dưới 12 tháng', 0, 0, 142, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 314, N'4. Phải trả người lao động', N'Dư Có TK 334 - dưới 12 tháng', 0, 0, 143, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 315, N'5. Chi phí phải trả ngắn hạn', N' Dư Có TK 335 - dưới 12 tháng', 0, 0, 144, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 316, N'6. Phải trả nội bộ ngắn hạn', N'Dư Có chi tiết TK 3362, 3363,
3368 - dưới 12 tháng', 0, 0, 145, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 317, N'7. Phải trả theo tiến độ kế hoạch hợp đồng xây dựng', N'Dư Có TK 337', 0, 0, 146, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 318, N'8. Doanh thu chưa thực hiện ngắn hạn', N'Dư Có chi tiết TK 3387 < 12 tháng', 0, 0, 147, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 319, N'9. Phải trả ngắn hạn khác', N'Dư Có chi tiết TK 338, 138,
344 - dưới 12 tháng', 0, 0, 148, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 320, N'10. Vay và nợ thuê tài chính ngắn hạn', N' Dư Có chi tiết TK 341 và 34311 ', 0, 0, 149, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 321, N'11. Dự phòng phải trả ngắn hạn', N' Dư Có chi tiết TK 352 - dưới
12 tháng', 0, 0, 150, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 322, N'12. Quỹ khen thưởng phúc lợi', N' Dư Có của TK 353', 0, 0, 151, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 323, N'13. Quỹ bình ổn giá', N' Dư Có của TK 357', 0, 0, 152, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 324, N'14. Giao dịch mua bán lại trái phiếu chính phủ', N'Dư Có TK 171', 0, 0, 153, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 331, N'1. Phải trả người bán dài hạn', N' Dư Có TK 331 - Thời hạn trên
12 tháng', 0, 0, 154, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 332, N'2. Người mua trả tiền trước dài hạn', N' Dư Có chi tiết TK 131 - Thời hạn
trên 12 tháng', 0, 0, 155, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 333, N'3. Chi phí phải trả dài hạn', N'Dư Có TK 335 - Thời hạn
trên 12 tháng', 0, 0, 156, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 334, N'4. Phải trả nội bộ về vốn kinh doanh', N'Dư Có chi tiết TK 3361', 0, 0, 157, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 335, N'5. Phải trả nội bộ dài hạn', N' Dư Có chi tiết TK 3362, 3363,
3368 - Thời hạn trên 12 tháng', 0, 0, 158, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 336, N'6. Doanh thu chưa thực hiện dài hạn', N'Dư Có chi tiết TK3387 –
trên 12 tháng', 0, 0, 159, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 337, N'7. Phải trả dài hạn khác', N'Dư Có chi tiết TK 338, 344
trên 12 tháng', 0, 0, 160, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 338, N'8. Vay và nợ thuê tài chính dài hạn', N'Dư Có chi tiết TK 341 và
Dư Có TK 34311 trừ (-) dư Nợ TK
34312 cộng (+) dư Có TK 34313.', 0, 0, 161, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 339, N'9. Trái phiếu chuyển đổi', N'Dư Có chi tiết của TK 3432 ', 0, 0, 162, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 340, N'0. Cổ phiếu ưu đãi', N'Dư Có chi tiết TK 41112 –
chi tiết Nợ phải trả', 0, 0, 163, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 341, N'1. Thuế thu nhập hoãn lại phải trả', N'Dư Có TK 347', 0, 0, 164, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 342, N'12. Dự phòng phải trả dài hạn', N'Dư Có chi tiết TK 352 >12 tháng', 0, 0, 165, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 343, N'13. Quỹ phát triển khoa học và công nghệ', N'Dư Có của TK 356', 0, 0, 166, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 411, N'1. Vốn góp của chủ sở hữu', N'Dư Có TK 4111', 0, 0, 167, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 4111, N'Cổ phiếu phổ thông có quyền biểu quyết
', N'Dư Có TK 41111', 0, 0, 168, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 4112, N'Cổ phiếu ưu đẫi', N'Dư Có chi tiết TK 41112', 0, 0, 169, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 412, N'2. Thặng dư vốn cổ phần', N' Số dư TK 4112 (Dư Nợ: ghi âm)', 0, 0, 170, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 413, N'3. Quyền chọn chuyển đổi trái phiếu', N' Dư Có chi tiết TK 4113', 0, 0, 171, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 414, N'4. Vốn khác của chủ sở hữu', N'Dư Có Tài khoản 4118', 0, 0, 172, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 415, N'5. Cổ phiếu quỹ (*)', N'Dư Nợ TK 419 (ghi âm)', 0, 0, 173, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 416, N'6. Chênh lệch đánh giá lại tài sản', N'Số dư Có TK 412, (Dư Nợ: ghi âm)', 0, 0, 174, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 417, N'7. Chênh lệch tỷ giá hối đoái', N'Số dư Có TK 413 (Dư Nợ: ghi âm)', 0, 0, 175, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 418, N'8. Quỹ đầu tư phát triển', N' Dư Có TK 414', 0, 0, 176, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 419, N'9. Quỹ hỗ trợ sắp xếp doanh nghiệp', N'Dư Có TK 417', 0, 0, 177, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 420, N'10. Quỹ khác thuộc vốn chủ sở hữu', N'Dư Có TK 418', 0, 0, 178, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 421, N'11. Lợi nhuận sau thuế chưa phân phối', N' Số dư TK 421', 0, 0, 179, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 4211, N'- LNST chưa phân phối lũy kế đến cuối kỳ trước', N' Số Dư TK 4211 (Dư Nợ: ghi âm)', 0, 0, 180, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 4212, N'- LNST chưa phân phối kỳ này', N'Số Dư TK 4212 (Dư Nợ: ghi âm)', 0, 0, 181, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 422, N'12. Nguồn vốn đầu tư XDCB', N' Dư Có TK 441', 0, 0, 182, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 431, N'1. Nguồn kinh phí', N' Dư Có TK 461 - Dư Nợ TK 161', 0, 0, 183, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2017, 432, N'2. Nguồn kinh phí đã hình thành TSCĐ', N' Dư Có TK 466', 0, 0, 184, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 111, N'1. Tiền', N' Dư Nợ TK 111, 112, 113', 1212, 0, 185, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 112, N'2. Các khoản tương đương tiền', N'Dư Nợ TK 1281,1288 - Thời hạn gốc không quá 3 tháng', 12, 0, 186, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 121, N'1. Chứng khoán kinh doanh', N' Dư Nợ TK 121 - dưới 12 tháng', 0, 0, 187, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 122, N'2. Dự phòng giảm giá chứng khoán kinh doanh (*)', N'Dư có 2291 (Ghi âm) < 12 tháng', 12, 0, 188, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 123, N'3. Đầu tư nắm giữ đến ngày đáo hạn', N'Dự 1281, 1282, 1288 - MS112', 0, 0, 189, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 131, N'1. Phải thu ngắn hạn của khách hàng', N' Dư Nợ chi tiết TK 131 - dưới 1 năm', 12, 0, 190, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 132, N'2. Trả trước cho người bán ngắn hạn', N' Dư Nợ chi tiết TK 331 - dưới 1 năm ', 0, 0, 191, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 133, N'3. Phải thu nội bộ ngắn hạn', N'Dư Nợ chi tiết TK 1362,1363,1368 –
 dưới 1 năm', 12, 0, 192, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 134, N'4. Phải thu theo tiến độ kế hoạch hợp đồng xây dựng', N'Dư Nợ TK 337', 0, 0, 193, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 135, N'5. Phải thu về cho vay ngắn hạn', N' Dư Nợ chi tiết TK 1283 - dưới 1 năm', 12, 0, 194, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 136, N'6. Phải thu ngắn hạn khác', N'Dư Nợ chi tiết TK 1385, 1388, 334,
 338, 141, 244 - dưới 1 năm', 0, 0, 195, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 137, N'7. Dự phòng phải thu ngắn hạn khó đòi (*)', N'Dư Có chi tiết TK 2293 - dưới 1 năm', 0, 0, 196, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 139, N'8. Tài sản thiếu chờ xử lý', N'Dư Nợ TK 1381', 12, 0, 197, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 141, N'1. Hàng tồn kho', N'Dư Nợ TK 151, 152, 153, 154, 155,
 156, 157, 158', 0, 0, 198, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 149, N'2. Dự phòng giảm giá hàng tồn kho (*)', N'Dư Có chi tiết TK 2294 (Ghi âm)', 0, 0, 199, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 151, N'1. Chi phí trả trước ngắn hạn', N'Dư Nợ chi tiết TK 242 < 12 tháng', 0, 0, 200, N'Mai Văn Trường')
GO
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 152, N'2. Thuế giá trị gia tăng được khấu trừ', N' Dư Nợ TK 133', 0, 0, 201, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 153, N'3. Thuế và các khoản phải thu Nhà nước', N'Dư Nợ chi tiết TK 333', 0, 0, 202, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 154, N'4. Giao dịch mua bán lại trái phiếu chính phủ', N'Dư Nợ TK 171', 0, 0, 203, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 155, N'5. Tài sản ngắn hạn khác', N' Dư Nợ chi tiết TK 2288 - dưới 12 tháng', 0, 0, 204, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 211, N'1. Phải thu dài hạn của khách hàng', N'Dư Nợ chi tiết TK 131 > 12 tháng', 0, 0, 205, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 212, N'2. Trả trước cho người bán dài hạn', N'Dư Nợ chi tiết TK 331 > 12 tháng ', 0, 0, 206, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 213, N'3. Vốn kinh doanh ở đơn vị trực thuộc', N'Dư Nợ TK 1361', 0, 0, 207, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 214, N'4. Phải thu nội bộ dài hạn', N'	
 Dư Nợ chi tiết TK 1362, 1363,
1368 - trên 12 tháng', 0, 0, 208, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 215, N'5. Phải thu về cho vay dài hạn', N'Dư Nợ chi tiết TK 1283 - trên
12 tháng', 0, 0, 209, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 216, N'6. Phải thu dài hạn khác', N' Dư Nợ chi tiết TK 1385, 1388, 334,
 338, 141, 244 - dưới 12 tháng', 0, 0, 210, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 219, N'7. Dự phòng phải thu dài hạn khó đòi (*)', N' Dư Có chi tiết TK 2293 - trên
12 tháng', 0, 0, 211, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 222, N' Nguyên giá cố định hữu hình', N'Dư  Nợ TK 211', 0, 0, 212, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 223, N'Giá trị hao mòn luỹ kế (* cố định hữu hình)', N'Dư  Có TK 2141', 0, 0, 213, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 225, N'Nguyên giá Tài sản cố định thuê tài chính', N'Dư  Nợ TK 212', 0, 0, 214, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 226, N' Giá trị hao mòn luỹ kế (*) Tài sản cố định thuê tài chính', N'Dư  Có TK 2142', 0, 0, 215, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 228, N'Nguyên giá Tài sản cố định vô hình', N' Dư  Nợ TK 213', 0, 0, 216, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 229, N'Giá trị hao mòn luỹ kế (*) Tài sản cố định vô hình', N' Dư  Có TK 2143', 0, 0, 217, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 231, N'1. Nguyên giá Bất động sản đầu tư', N'Dư  Nợ TK 217', 0, 0, 218, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 232, N'2. Giá trị hao mòn luỹ kế (*) Bất động sản đầu tư', N'Dư  Có TK 2147', 0, 0, 219, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 241, N'1. Chi phí sản xuất kinh doanh dở dang dài hạn', N'Dư Nợ chi tiết TK 154 và dư Có
chi tiết TK 2294 - trên 12 tháng', 0, 0, 220, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 242, N'2. Chi phí xây dựng cơ bản dở dang', N'Dư Nợ TK 241', 0, 0, 221, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 251, N'1. Đầu tư vào công ty con', N'Dư  Nợ TK 221', 0, 0, 222, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 252, N'2. Đầu tư vào công ty liên doanh liên kết', N'Dư  Nợ TK 222', 0, 0, 223, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 253, N'3. Đầu tư góp vốn vào đơn vị khác', N'Dư  Nợ chi tiết TK 2281', 0, 0, 224, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 254, N'4. Dự phòng đầu tư tài chính dài hạn (*)', N'	
 Dư  Có chi tiết TK 2292', 0, 0, 225, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 255, N'5. Đầu tư nắm giữ đến ngày đáo hạn', N'Dư Nợ TK 1281, 1282, 1288 - trên
12 tháng', 0, 0, 226, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 261, N'1. Chi phí trả trước dài hạn', N' Dư  Nợ chi tiết TK 242 - trên
12 tháng', 0, 0, 227, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 262, N'2. Tài sản thuế thu nhập hoãn lại', N'Dư  Nợ TK 243', 0, 0, 228, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 263, N'3. Thiết bị, vật tư, phụ tùng thay thế dài hạn', N' Dư Nợ chi tiết TK 1534 và dư Có
chi tiết TK 2294 - trên 12 tháng', 0, 0, 229, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 268, N'4. Tài sản dài hạn khác', N'Dư  Nợ chi tiết TK 2288', 0, 0, 230, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 311, N'1. Phải trả người bán ngắn hạn', N'Dư Có chi tiết TK 331 < 12 tháng', 0, 0, 231, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 312, N'2. Người mua trả tiền trước ngắn hạn', N'Dư Có chi tiết TK 131 < 12 tháng', 0, 0, 232, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 313, N'3. Thuế và các khoản phải nộp Nhà nước', N'Dư Có TK 333 - dưới 12 tháng', 0, 0, 233, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 314, N'4. Phải trả người lao động', N'Dư Có TK 334 - dưới 12 tháng', 0, 0, 234, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 315, N'5. Chi phí phải trả ngắn hạn', N' Dư Có TK 335 - dưới 12 tháng', 0, 0, 235, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 316, N'6. Phải trả nội bộ ngắn hạn', N'Dư Có chi tiết TK 3362, 3363,
3368 - dưới 12 tháng', 0, 0, 236, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 317, N'7. Phải trả theo tiến độ kế hoạch hợp đồng xây dựng', N'Dư Có TK 337', 0, 0, 237, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 318, N'8. Doanh thu chưa thực hiện ngắn hạn', N'Dư Có chi tiết TK 3387 < 12 tháng', 0, 0, 238, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 319, N'9. Phải trả ngắn hạn khác', N'Dư Có chi tiết TK 338, 138,
344 - dưới 12 tháng', 0, 0, 239, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 320, N'10. Vay và nợ thuê tài chính ngắn hạn', N' Dư Có chi tiết TK 341 và 34311 ', 0, 0, 240, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 321, N'11. Dự phòng phải trả ngắn hạn', N' Dư Có chi tiết TK 352 - dưới
12 tháng', 0, 0, 241, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 322, N'12. Quỹ khen thưởng phúc lợi', N' Dư Có của TK 353', 0, 0, 242, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 323, N'13. Quỹ bình ổn giá', N' Dư Có của TK 357', 0, 0, 243, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 324, N'14. Giao dịch mua bán lại trái phiếu chính phủ', N'Dư Có TK 171', 0, 0, 244, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 331, N'1. Phải trả người bán dài hạn', N' Dư Có TK 331 - Thời hạn trên
12 tháng', 0, 0, 245, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 332, N'2. Người mua trả tiền trước dài hạn', N' Dư Có chi tiết TK 131 - Thời hạn
trên 12 tháng', 0, 0, 246, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 333, N'3. Chi phí phải trả dài hạn', N'Dư Có TK 335 - Thời hạn
trên 12 tháng', 0, 0, 247, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 334, N'4. Phải trả nội bộ về vốn kinh doanh', N'Dư Có chi tiết TK 3361', 0, 0, 248, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 335, N'5. Phải trả nội bộ dài hạn', N' Dư Có chi tiết TK 3362, 3363,
3368 - Thời hạn trên 12 tháng', 0, 0, 249, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 336, N'6. Doanh thu chưa thực hiện dài hạn', N'Dư Có chi tiết TK3387 –
trên 12 tháng', 0, 0, 250, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 337, N'7. Phải trả dài hạn khác', N'Dư Có chi tiết TK 338, 344
trên 12 tháng', 0, 0, 251, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 338, N'8. Vay và nợ thuê tài chính dài hạn', N'Dư Có chi tiết TK 341 và
Dư Có TK 34311 trừ (-) dư Nợ TK
34312 cộng (+) dư Có TK 34313.', 0, 0, 252, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 339, N'9. Trái phiếu chuyển đổi', N'Dư Có chi tiết của TK 3432 ', 0, 0, 253, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 340, N'0. Cổ phiếu ưu đãi', N'Dư Có chi tiết TK 41112 –
chi tiết Nợ phải trả', 0, 0, 254, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 341, N'1. Thuế thu nhập hoãn lại phải trả', N'Dư Có TK 347', 0, 0, 255, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 342, N'12. Dự phòng phải trả dài hạn', N'Dư Có chi tiết TK 352 >12 tháng', 0, 0, 256, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 343, N'13. Quỹ phát triển khoa học và công nghệ', N'Dư Có của TK 356', 0, 0, 257, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 411, N'1. Vốn góp của chủ sở hữu', N'Dư Có TK 4111', 0, 0, 258, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 4111, N'Cổ phiếu phổ thông có quyền biểu quyết
', N'Dư Có TK 41111', 0, 0, 259, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 4112, N'Cổ phiếu ưu đẫi', N'Dư Có chi tiết TK 41112', 0, 0, 260, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 412, N'2. Thặng dư vốn cổ phần', N' Số dư TK 4112 (Dư Nợ: ghi âm)', 0, 0, 261, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 413, N'3. Quyền chọn chuyển đổi trái phiếu', N' Dư Có chi tiết TK 4113', 0, 0, 262, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 414, N'4. Vốn khác của chủ sở hữu', N'Dư Có Tài khoản 4118', 0, 0, 263, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 415, N'5. Cổ phiếu quỹ (*)', N'Dư Nợ TK 419 (ghi âm)', 0, 0, 264, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 416, N'6. Chênh lệch đánh giá lại tài sản', N'Số dư Có TK 412, (Dư Nợ: ghi âm)', 0, 0, 265, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 417, N'7. Chênh lệch tỷ giá hối đoái', N'Số dư Có TK 413 (Dư Nợ: ghi âm)', 0, 0, 266, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 418, N'8. Quỹ đầu tư phát triển', N' Dư Có TK 414', 0, 0, 267, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 419, N'9. Quỹ hỗ trợ sắp xếp doanh nghiệp', N'Dư Có TK 417', 0, 0, 268, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 420, N'10. Quỹ khác thuộc vốn chủ sở hữu', N'Dư Có TK 418', 0, 0, 269, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 421, N'11. Lợi nhuận sau thuế chưa phân phối', N' Số dư TK 421', 0, 0, 270, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 4211, N'- LNST chưa phân phối lũy kế đến cuối kỳ trước', N' Số Dư TK 4211 (Dư Nợ: ghi âm)', 0, 0, 271, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 4212, N'- LNST chưa phân phối kỳ này', N'Số Dư TK 4212 (Dư Nợ: ghi âm)', 0, 0, 272, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 422, N'12. Nguồn vốn đầu tư XDCB', N' Dư Có TK 441', 0, 0, 273, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 431, N'1. Nguồn kinh phí', N' Dư Có TK 461 - Dư Nợ TK 161', 0, 0, 274, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2016, 432, N'2. Nguồn kinh phí đã hình thành TSCĐ', N' Dư Có TK 466', 0, 0, 275, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 111, N'1. Tiền', N' Dư Nợ TK 111, 112, 113', 0, 0, 276, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 112, N'2. Các khoản tương đương tiền', N'Dư Nợ TK 1281,1288 - Thời hạn gốc không quá 3 tháng', 13, 0, 277, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 121, N'1. Chứng khoán kinh doanh', N' Dư Nợ TK 121 - dưới 12 tháng', 0, 0, 278, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 122, N'2. Dự phòng giảm giá chứng khoán kinh doanh (*)', N'Dư có 2291 (Ghi âm) < 12 tháng', 2, 0, 279, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 123, N'3. Đầu tư nắm giữ đến ngày đáo hạn', N'Dự 1281, 1282, 1288 - MS112', 13, 0, 280, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 131, N'1. Phải thu ngắn hạn của khách hàng', N' Dư Nợ chi tiết TK 131 - dưới 1 năm', 0, 0, 281, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 132, N'2. Trả trước cho người bán ngắn hạn', N' Dư Nợ chi tiết TK 331 - dưới 1 năm ', 0, 0, 282, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 133, N'3. Phải thu nội bộ ngắn hạn', N'Dư Nợ chi tiết TK 1362,1363,1368 –
 dưới 1 năm', 3124, 0, 283, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 134, N'4. Phải thu theo tiến độ kế hoạch hợp đồng xây dựng', N'Dư Nợ TK 337', 0, 0, 284, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 135, N'5. Phải thu về cho vay ngắn hạn', N' Dư Nợ chi tiết TK 1283 - dưới 1 năm', 0, 0, 285, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 136, N'6. Phải thu ngắn hạn khác', N'Dư Nợ chi tiết TK 1385, 1388, 334,
 338, 141, 244 - dưới 1 năm', 321, 0, 286, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 137, N'7. Dự phòng phải thu ngắn hạn khó đòi (*)', N'Dư Có chi tiết TK 2293 - dưới 1 năm', 4, 0, 287, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 139, N'8. Tài sản thiếu chờ xử lý', N'Dư Nợ TK 1381', 0, 0, 288, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 141, N'1. Hàng tồn kho', N'Dư Nợ TK 151, 152, 153, 154, 155,
 156, 157, 158', 0, 0, 289, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 149, N'2. Dự phòng giảm giá hàng tồn kho (*)', N'Dư Có chi tiết TK 2294 (Ghi âm)', 3214321, 0, 290, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 151, N'1. Chi phí trả trước ngắn hạn', N'Dư Nợ chi tiết TK 242 < 12 tháng', 0, 0, 291, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 152, N'2. Thuế giá trị gia tăng được khấu trừ', N' Dư Nợ TK 133', 0, 0, 292, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 153, N'3. Thuế và các khoản phải thu Nhà nước', N'Dư Nợ chi tiết TK 333', 3214, 0, 293, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 154, N'4. Giao dịch mua bán lại trái phiếu chính phủ', N'Dư Nợ TK 171', 4, 0, 294, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 155, N'5. Tài sản ngắn hạn khác', N' Dư Nợ chi tiết TK 2288 - dưới 12 tháng', 0, 0, 295, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 211, N'1. Phải thu dài hạn của khách hàng', N'Dư Nợ chi tiết TK 131 > 12 tháng', 3124, 0, 296, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 212, N'2. Trả trước cho người bán dài hạn', N'Dư Nợ chi tiết TK 331 > 12 tháng ', 2314, 0, 297, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 213, N'3. Vốn kinh doanh ở đơn vị trực thuộc', N'Dư Nợ TK 1361', 0, 0, 298, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 214, N'4. Phải thu nội bộ dài hạn', N'	
 Dư Nợ chi tiết TK 1362, 1363,
1368 - trên 12 tháng', 1234, 0, 299, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 215, N'5. Phải thu về cho vay dài hạn', N'Dư Nợ chi tiết TK 1283 - trên
12 tháng', 0, 0, 300, N'Mai Văn Trường')
GO
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 216, N'6. Phải thu dài hạn khác', N' Dư Nợ chi tiết TK 1385, 1388, 334,
 338, 141, 244 - dưới 12 tháng', 0, 0, 301, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 219, N'7. Dự phòng phải thu dài hạn khó đòi (*)', N' Dư Có chi tiết TK 2293 - trên
12 tháng', 0, 0, 302, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 222, N' Nguyên giá cố định hữu hình', N'Dư  Nợ TK 211', 0, 0, 303, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 223, N'Giá trị hao mòn luỹ kế (* cố định hữu hình)', N'Dư  Có TK 2141', 0, 0, 304, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 225, N'Nguyên giá Tài sản cố định thuê tài chính', N'Dư  Nợ TK 212', 0, 0, 305, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 226, N' Giá trị hao mòn luỹ kế (*) Tài sản cố định thuê tài chính', N'Dư  Có TK 2142', 0, 0, 306, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 228, N'Nguyên giá Tài sản cố định vô hình', N' Dư  Nợ TK 213', 0, 0, 307, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 229, N'Giá trị hao mòn luỹ kế (*) Tài sản cố định vô hình', N' Dư  Có TK 2143', 0, 0, 308, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 231, N'1. Nguyên giá Bất động sản đầu tư', N'Dư  Nợ TK 217', 0, 0, 309, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 232, N'2. Giá trị hao mòn luỹ kế (*) Bất động sản đầu tư', N'Dư  Có TK 2147', 0, 0, 310, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 241, N'1. Chi phí sản xuất kinh doanh dở dang dài hạn', N'Dư Nợ chi tiết TK 154 và dư Có
chi tiết TK 2294 - trên 12 tháng', 0, 0, 311, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 242, N'2. Chi phí xây dựng cơ bản dở dang', N'Dư Nợ TK 241', 0, 0, 312, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 251, N'1. Đầu tư vào công ty con', N'Dư  Nợ TK 221', 0, 0, 313, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 252, N'2. Đầu tư vào công ty liên doanh liên kết', N'Dư  Nợ TK 222', 0, 0, 314, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 253, N'3. Đầu tư góp vốn vào đơn vị khác', N'Dư  Nợ chi tiết TK 2281', 0, 0, 315, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 254, N'4. Dự phòng đầu tư tài chính dài hạn (*)', N'	
 Dư  Có chi tiết TK 2292', 0, 0, 316, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 255, N'5. Đầu tư nắm giữ đến ngày đáo hạn', N'Dư Nợ TK 1281, 1282, 1288 - trên
12 tháng', 0, 0, 317, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 261, N'1. Chi phí trả trước dài hạn', N' Dư  Nợ chi tiết TK 242 - trên
12 tháng', 0, 0, 318, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 262, N'2. Tài sản thuế thu nhập hoãn lại', N'Dư  Nợ TK 243', 0, 0, 319, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 263, N'3. Thiết bị, vật tư, phụ tùng thay thế dài hạn', N' Dư Nợ chi tiết TK 1534 và dư Có
chi tiết TK 2294 - trên 12 tháng', 0, 0, 320, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 268, N'4. Tài sản dài hạn khác', N'Dư  Nợ chi tiết TK 2288', 0, 0, 321, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 311, N'1. Phải trả người bán ngắn hạn', N'Dư Có chi tiết TK 331 < 12 tháng', 0, 0, 322, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 312, N'2. Người mua trả tiền trước ngắn hạn', N'Dư Có chi tiết TK 131 < 12 tháng', 0, 0, 323, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 313, N'3. Thuế và các khoản phải nộp Nhà nước', N'Dư Có TK 333 - dưới 12 tháng', 0, 0, 324, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 314, N'4. Phải trả người lao động', N'Dư Có TK 334 - dưới 12 tháng', 0, 0, 325, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 315, N'5. Chi phí phải trả ngắn hạn', N' Dư Có TK 335 - dưới 12 tháng', 0, 0, 326, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 316, N'6. Phải trả nội bộ ngắn hạn', N'Dư Có chi tiết TK 3362, 3363,
3368 - dưới 12 tháng', 0, 0, 327, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 317, N'7. Phải trả theo tiến độ kế hoạch hợp đồng xây dựng', N'Dư Có TK 337', 0, 0, 328, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 318, N'8. Doanh thu chưa thực hiện ngắn hạn', N'Dư Có chi tiết TK 3387 < 12 tháng', 0, 0, 329, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 319, N'9. Phải trả ngắn hạn khác', N'Dư Có chi tiết TK 338, 138,
344 - dưới 12 tháng', 0, 0, 330, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 320, N'10. Vay và nợ thuê tài chính ngắn hạn', N' Dư Có chi tiết TK 341 và 34311 ', 0, 0, 331, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 321, N'11. Dự phòng phải trả ngắn hạn', N' Dư Có chi tiết TK 352 - dưới
12 tháng', 0, 0, 332, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 322, N'12. Quỹ khen thưởng phúc lợi', N' Dư Có của TK 353', 0, 0, 333, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 323, N'13. Quỹ bình ổn giá', N' Dư Có của TK 357', 0, 0, 334, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 324, N'14. Giao dịch mua bán lại trái phiếu chính phủ', N'Dư Có TK 171', 0, 0, 335, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 331, N'1. Phải trả người bán dài hạn', N' Dư Có TK 331 - Thời hạn trên
12 tháng', 0, 0, 336, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 332, N'2. Người mua trả tiền trước dài hạn', N' Dư Có chi tiết TK 131 - Thời hạn
trên 12 tháng', 0, 0, 337, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 333, N'3. Chi phí phải trả dài hạn', N'Dư Có TK 335 - Thời hạn
trên 12 tháng', 0, 0, 338, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 334, N'4. Phải trả nội bộ về vốn kinh doanh', N'Dư Có chi tiết TK 3361', 0, 0, 339, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 335, N'5. Phải trả nội bộ dài hạn', N' Dư Có chi tiết TK 3362, 3363,
3368 - Thời hạn trên 12 tháng', 0, 0, 340, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 336, N'6. Doanh thu chưa thực hiện dài hạn', N'Dư Có chi tiết TK3387 –
trên 12 tháng', 0, 0, 341, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 337, N'7. Phải trả dài hạn khác', N'Dư Có chi tiết TK 338, 344
trên 12 tháng', 0, 0, 342, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 338, N'8. Vay và nợ thuê tài chính dài hạn', N'Dư Có chi tiết TK 341 và
Dư Có TK 34311 trừ (-) dư Nợ TK
34312 cộng (+) dư Có TK 34313.', 0, 0, 343, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 339, N'9. Trái phiếu chuyển đổi', N'Dư Có chi tiết của TK 3432 ', 0, 0, 344, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 340, N'0. Cổ phiếu ưu đãi', N'Dư Có chi tiết TK 41112 –
chi tiết Nợ phải trả', 0, 0, 345, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 341, N'1. Thuế thu nhập hoãn lại phải trả', N'Dư Có TK 347', 0, 0, 346, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 342, N'12. Dự phòng phải trả dài hạn', N'Dư Có chi tiết TK 352 >12 tháng', 0, 0, 347, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 343, N'13. Quỹ phát triển khoa học và công nghệ', N'Dư Có của TK 356', 0, 0, 348, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 411, N'1. Vốn góp của chủ sở hữu', N'Dư Có TK 4111', 0, 0, 349, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 4111, N'Cổ phiếu phổ thông có quyền biểu quyết
', N'Dư Có TK 41111', 0, 0, 350, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 4112, N'Cổ phiếu ưu đẫi', N'Dư Có chi tiết TK 41112', 0, 0, 351, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 412, N'2. Thặng dư vốn cổ phần', N' Số dư TK 4112 (Dư Nợ: ghi âm)', 0, 0, 352, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 413, N'3. Quyền chọn chuyển đổi trái phiếu', N' Dư Có chi tiết TK 4113', 0, 0, 353, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 414, N'4. Vốn khác của chủ sở hữu', N'Dư Có Tài khoản 4118', 0, 0, 354, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 415, N'5. Cổ phiếu quỹ (*)', N'Dư Nợ TK 419 (ghi âm)', 0, 0, 355, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 416, N'6. Chênh lệch đánh giá lại tài sản', N'Số dư Có TK 412, (Dư Nợ: ghi âm)', 0, 0, 356, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 417, N'7. Chênh lệch tỷ giá hối đoái', N'Số dư Có TK 413 (Dư Nợ: ghi âm)', 0, 0, 357, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 418, N'8. Quỹ đầu tư phát triển', N' Dư Có TK 414', 0, 0, 358, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 419, N'9. Quỹ hỗ trợ sắp xếp doanh nghiệp', N'Dư Có TK 417', 0, 0, 359, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 420, N'10. Quỹ khác thuộc vốn chủ sở hữu', N'Dư Có TK 418', 0, 0, 360, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 421, N'11. Lợi nhuận sau thuế chưa phân phối', N' Số dư TK 421', 0, 0, 361, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 4211, N'- LNST chưa phân phối lũy kế đến cuối kỳ trước', N' Số Dư TK 4211 (Dư Nợ: ghi âm)', 0, 0, 362, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 4212, N'- LNST chưa phân phối kỳ này', N'Số Dư TK 4212 (Dư Nợ: ghi âm)', 0, 0, 363, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 422, N'12. Nguồn vốn đầu tư XDCB', N' Dư Có TK 441', 0, 0, 364, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 431, N'1. Nguồn kinh phí', N' Dư Có TK 461 - Dư Nợ TK 161', 0, 0, 365, N'Mai Văn Trường')
INSERT [dbo].[CDKT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [stat], [id], [username]) VALUES (2018, 432, N'2. Nguồn kinh phí đã hình thành TSCĐ', N' Dư Có TK 466', 0, 0, 366, N'Mai Văn Trường')
SET IDENTITY_INSERT [dbo].[CDKT200Dauky] OFF
SET IDENTITY_INSERT [dbo].[KQKD200Dauky] ON 

INSERT [dbo].[KQKD200Dauky] ([nam], [dthu01], [giamdt02], [giavon11], [dttaichinh], [cftaichinh], [cflaivay], [cfbanhang], [cfquanlydn], [thunhapkhac], [cfkhac], [cftndnhienhanh], [cfdnhoanlai], [laicbcophieu], [laigiaomtrencphieu], [id], [username]) VALUES (2016, 13123, 123, 213, 123, 3123, 3123, 3123, 1313, 0, 12312, 312312, 312312, 312, 123, 1, NULL)
INSERT [dbo].[KQKD200Dauky] ([nam], [dthu01], [giamdt02], [giavon11], [dttaichinh], [cftaichinh], [cflaivay], [cfbanhang], [cfquanlydn], [thunhapkhac], [cfkhac], [cftndnhienhanh], [cfdnhoanlai], [laicbcophieu], [laigiaomtrencphieu], [id], [username]) VALUES (2018, 111111112, 11111, 13241, 1234, 1234, 123, 1234, 1234, 1324, 1234, 134, 1234, 324, 1234, 2, NULL)
INSERT [dbo].[KQKD200Dauky] ([nam], [dthu01], [giamdt02], [giavon11], [dttaichinh], [cftaichinh], [cflaivay], [cfbanhang], [cfquanlydn], [thunhapkhac], [cfkhac], [cftndnhienhanh], [cfdnhoanlai], [laicbcophieu], [laigiaomtrencphieu], [id], [username]) VALUES (2017, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, NULL)
SET IDENTITY_INSERT [dbo].[KQKD200Dauky] OFF
SET IDENTITY_INSERT [dbo].[LTTT200Dauky] ON 

INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 1, N'1. Tiền thu từ bán hàng, cung cấp dịch vụ và doanh thu khác', N' PS Nợ 111+112 / Có 511,3331,131, 515,121 (515,121 chi tiết số tiền thu từ bán chứng khoán kinh doanh)', 0, 1, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 2, N'2. Tiền chi trả cho người cung cấp hàng hóa và dịch vụ', N'PS Có 111+112 / Nợ 331, 151, 152, 153, 154, 155, 156, 157,…', 0, 2, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 3, N'3. Tiền chi trả cho người lao động', N'PS Có 111+112 / Nợ 334', 0, 3, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 4, N'4. Tiền lãi vay đã trả', N' PS Có 111+112+113 / Nợ 635-chi tiết lãi vay', 0, 4, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 5, N'5. Thuế thu nhập doanh nghiệp đã nộp', N'PS Có 111+112+113 / Nợ 3334', 0, 5, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 6, N'6. Tiền thu khác từ hoạt động kinh doanh', N'	
 PS Nợ 111+112 / Có 711, 133, 141, 244…(các khoản THU khác từ hoạt động KD mà ko thuộc chỉ tiêu 01)', 0, 6, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 7, N'7. Tiền chi khác từ hoạt động kinh doanh', N' PS Có 111+112+113 / Nợ 811, 161, 244, 333, 338, 344, 352, 353, 356…(các khoản CHI khác từ hoạt động KD mà ko thuộc chỉ tiêu 02+03+04+05)', 0, 7, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 21, N'1. Tiền chi để mua sắm, xây dựng TSCĐ, BĐS đầu tư và các tài sản dài hạn khác', N' PS Có 111+112+113 / Nợ 211, 213, 217, 241 …', 0, 8, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 22, N'2. Tiền thu từ thanh lý, nhượng bán TSCĐ, BĐS đầu tư và các tài sản dài hạn khác', N'Chênh lệch dương (+) hoặc âm (-) giữa:
- Thu: PS nợ 111+112+113 / Có 711, 5117, 131…), và
- Chi (PS có 111+112+113 / Nợ 632, 811…)
chi tiết về thanh lý, nhượng bán TSCĐ, BĐSĐT và các tài sản dài hạn khác', 0, 9, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 23, N'3. Tiền chi cho vay, mua các công cụ nợ của đơn vị khác', N'PS Có 111+112+113 / Nợ 128, 171 …', 0, 10, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 24, N'4. Tiền thu hồi cho vay, bán lại các công cụ nợ của đơn vị khác', N' PS Nợ 111+112+113 / Có 128, 171 …', 0, 11, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 25, N'5. Tiền chi đầu tư góp vốn vào đơn vị khác', N' PS Có 111+112+113 / Nợ 221, 222, 2281…', 0, 12, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 26, N'6. Tiền thu hồi đầu tư góp vốn vào đơn vị khác', N' PS Nợ 111+112+113 / Có 221, 222, 2281…', 0, 13, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 27, N'7. Tiền thu lãi cho vay, cổ tức và lợi nhuận được chia', N'PS Nợ 111+112+113 / Có 515 (lãi, cổ tức, lợi nhuận được chia)', 0, 14, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 31, N'1. Tiền thu từ phát hành cổ phiếu, nhận vốn góp của chủ sở hữu', N'PS Nợ 111+112+113 Có 411', 0, 15, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 32, N'2. Tiền trả lại vốn góp cho các chủ sở hữu, mua lại cổ phiếu  của doanh nghiệp đã phát hành   ', N'PS Nợ 411/ Có 111-112-113', 0, 16, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 33, N'3. Tiền thu từ đi vay', N'PS Nợ 111-112-113 PS Có 341', 0, 17, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 34, N'4. Tiền trả nợ gốc vay', N'PS Nợ 341 /PS Có 111-112-113', 0, 18, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 35, N'5. Tiền trả nợ gốc thuê tài chính', NULL, 0, 19, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 36, N'6. Cổ tức, lợi nhuận đã trả cho chủ sở hữu', NULL, 0, 20, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 60, N'Tiền và tương đương tiền đầu kỳ', NULL, 0, 21, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2006, 61, N'Ảnh hưởng của thay đổi tỷ giá hối đoái quy đổi ngoại tệ', NULL, 0, 22, N'tr1')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 1, N'1. Tiền thu từ bán hàng, cung cấp dịch vụ và doanh thu khác', NULL, 0, 23, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 2, N'2. Tiền chi trả cho người cung cấp hàng hóa và dịch vụ', NULL, 0, 24, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 3, N'3. Tiền chi trả cho người lao động', NULL, 0, 25, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 4, N'4. Tiền lãi vay đã trả', NULL, 0, 26, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 5, N'5. Thuế thu nhập doanh nghiệp đã nộp', NULL, 0, 27, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 6, N'6. Tiền thu khác từ hoạt động kinh doanh', NULL, 0, 28, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 7, N'7. Tiền chi khác từ hoạt động kinh doanh', NULL, 0, 29, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 21, N'1. Tiền chi để mua sắm, xây dựng TSCĐ, BĐS đầu tư và các tài sản dài hạn khác', NULL, 0, 30, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 22, N'2. Tiền thu từ thanh lý, nhượng bán TSCĐ, BĐS đầu tư và các tài sản dài hạn khác', NULL, 0, 31, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 23, N'3. Tiền chi cho vay, mua các công cụ nợ của đơn vị khác', NULL, 0, 32, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 24, N'4. Tiền thu hồi cho vay, bán lại các công cụ nợ của đơn vị khác', NULL, 0, 33, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 25, N'5. Tiền chi đầu tư góp vốn vào đơn vị khác', NULL, 0, 34, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 26, N'6. Tiền thu hồi đầu tư góp vốn vào đơn vị khác', NULL, 0, 35, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 27, N'7. Tiền thu lãi cho vay, cổ tức và lợi nhuận được chia', NULL, 0, 36, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 31, N'1. Tiền thu từ phát hành cổ phiếu, nhận vốn góp của chủ sở hữu', NULL, 0, 37, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 32, N'2. Tiền trả lại vốn góp cho các chủ sở hữu, mua lại cổ phiếu  của doanh nghiệp đã phát hành   ', NULL, 0, 38, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 33, N'3. Tiền thu từ đi vay', NULL, 0, 39, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 34, N'4. Tiền trả nợ gốc vay', NULL, 0, 40, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 35, N'5. Tiền trả nợ gốc thuê tài chính', NULL, 0, 41, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 36, N'6. Cổ tức, lợi nhuận đã trả cho chủ sở hữu', NULL, 0, 42, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 60, N'Tiền và tương đương tiền đầu kỳ', NULL, 0, 43, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2017, 61, N'Ảnh hưởng của thay đổi tỷ giá hối đoái quy đổi ngoại tệ', NULL, 0, 44, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 1, N'1. Tiền thu từ bán hàng, cung cấp dịch vụ và doanh thu khác', NULL, 33333, 45, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 2, N'2. Tiền chi trả cho người cung cấp hàng hóa và dịch vụ', NULL, 0, 46, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 3, N'3. Tiền chi trả cho người lao động', NULL, 132, 47, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 4, N'4. Tiền lãi vay đã trả', NULL, 0, 48, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 5, N'5. Thuế thu nhập doanh nghiệp đã nộp', NULL, 0, 49, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 6, N'6. Tiền thu khác từ hoạt động kinh doanh', NULL, 0, 50, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 7, N'7. Tiền chi khác từ hoạt động kinh doanh', NULL, 21, 51, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 21, N'1. Tiền chi để mua sắm, xây dựng TSCĐ, BĐS đầu tư và các tài sản dài hạn khác', NULL, 3, 52, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 22, N'2. Tiền thu từ thanh lý, nhượng bán TSCĐ, BĐS đầu tư và các tài sản dài hạn khác', NULL, 0, 53, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 23, N'3. Tiền chi cho vay, mua các công cụ nợ của đơn vị khác', NULL, 0, 54, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 24, N'4. Tiền thu hồi cho vay, bán lại các công cụ nợ của đơn vị khác', NULL, 21, 55, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 25, N'5. Tiền chi đầu tư góp vốn vào đơn vị khác', NULL, 3, 56, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 26, N'6. Tiền thu hồi đầu tư góp vốn vào đơn vị khác', NULL, 0, 57, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 27, N'7. Tiền thu lãi cho vay, cổ tức và lợi nhuận được chia', NULL, 213, 58, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 31, N'1. Tiền thu từ phát hành cổ phiếu, nhận vốn góp của chủ sở hữu', NULL, 213, 59, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 32, N'2. Tiền trả lại vốn góp cho các chủ sở hữu, mua lại cổ phiếu  của doanh nghiệp đã phát hành   ', NULL, 0, 60, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 33, N'3. Tiền thu từ đi vay', NULL, 0, 61, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 34, N'4. Tiền trả nợ gốc vay', NULL, 213123, 62, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 35, N'5. Tiền trả nợ gốc thuê tài chính', NULL, 12, 63, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 36, N'6. Cổ tức, lợi nhuận đã trả cho chủ sở hữu', NULL, 3213, 64, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 60, N'Tiền và tương đương tiền đầu kỳ', NULL, 0, 65, N'Mai Văn Trường')
INSERT [dbo].[LTTT200Dauky] ([nam], [Machitieu], [Tenchitieu], [Cachghi], [Sotien], [id], [username]) VALUES (2018, 61, N'Ảnh hưởng của thay đổi tỷ giá hối đoái quy đổi ngoại tệ', NULL, 21, 66, N'Mai Văn Trường')
SET IDENTITY_INSERT [dbo].[LTTT200Dauky] OFF
SET IDENTITY_INSERT [dbo].[Rpt_PhieuThu] ON 

INSERT [dbo].[Rpt_PhieuThu] ([tencongty], [diachicongty], [masothue], [tengiamdoc], [tenketoantruong], [ngaychungtu], [nguoinoptien], [nguoilapphieu], [diachinguoinop], [lydothu], [sotien], [sotienbangchu], [sochungtugoc], [username], [id], [tkno], [quyenso], [tkco], [phieuthuso]) VALUES (N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'Duyên Thái,Thường Tín,Hà nội', N'012122848', N'Mai Văn Trường', N'Trần Thị Phương Thu', CAST(N'2018-06-13 00:00:00.000' AS DateTime), N'ádfdasf', N'Mai Văn Trường', N'đấ', N'dsafasdf', 123123, N'Một trăm hai mươi ba ngàn một trăm hai mươi ba đồng.', 1, N'tr1', 40, N'111       ', NULL, N'1112', N'1')
SET IDENTITY_INSERT [dbo].[Rpt_PhieuThu] OFF
SET IDENTITY_INSERT [dbo].[RptBTTHdetail] ON 

INSERT [dbo].[RptBTTHdetail] ([matk], [tentk], [noidung], [psno], [psco], [username], [id]) VALUES (N'911', N'Xác định kế quả kinh doanh                    ', N'AD                                                                                                                                                                                                                               ', 0, 23134, NULL, 1)
INSERT [dbo].[RptBTTHdetail] ([matk], [tentk], [noidung], [psno], [psco], [username], [id]) VALUES (N'911', N'Tiền mặt                                        ', N'AD                                                                                                                                                                                                                               ', 0, 23134, NULL, 2)
INSERT [dbo].[RptBTTHdetail] ([matk], [tentk], [noidung], [psno], [psco], [username], [id]) VALUES (N'111', NULL, N'AD                                                                                                                                                                                                                               ', 23134, 0, NULL, 3)
INSERT [dbo].[RptBTTHdetail] ([matk], [tentk], [noidung], [psno], [psco], [username], [id]) VALUES (N'911', N'Kho nguyên vật liệu                             ', N'AD        Á                                                                                                                                                                                                                      ', 0, 2313444, NULL, 4)
INSERT [dbo].[RptBTTHdetail] ([matk], [tentk], [noidung], [psno], [psco], [username], [id]) VALUES (N'152', NULL, N'AD        Á                                                                                                                                                                                                                      ', 2313444, 0, NULL, 5)
INSERT [dbo].[RptBTTHdetail] ([matk], [tentk], [noidung], [psno], [psco], [username], [id]) VALUES (N'911', N'Kho nguyên vật liệu                             ', N'AD        Á                                                                                                                                                                                                                      ', 0, 2313444, NULL, 6)
INSERT [dbo].[RptBTTHdetail] ([matk], [tentk], [noidung], [psno], [psco], [username], [id]) VALUES (N'152', NULL, N'AD        Á                                                                                                                                                                                                                      ', 2313444, 0, NULL, 7)
INSERT [dbo].[RptBTTHdetail] ([matk], [tentk], [noidung], [psno], [psco], [username], [id]) VALUES (N'911', N'Tiền mặt                                        ', N'AD                                                                                                                                                                                                                               ', 0, 23134, NULL, 8)
INSERT [dbo].[RptBTTHdetail] ([matk], [tentk], [noidung], [psno], [psco], [username], [id]) VALUES (N'111', NULL, N'AD                                                                                                                                                                                                                               ', 23134, 0, NULL, 9)
INSERT [dbo].[RptBTTHdetail] ([matk], [tentk], [noidung], [psno], [psco], [username], [id]) VALUES (N'141', N'Tạm ứng', N'ádsasd', 0, 1212, N'tr1', 276)
INSERT [dbo].[RptBTTHdetail] ([matk], [tentk], [noidung], [psno], [psco], [username], [id]) VALUES (N'1113', N'Vàng tiền tệ', N'ádsasd', 1212, 0, N'tr1', 277)
SET IDENTITY_INSERT [dbo].[RptBTTHdetail] OFF
SET IDENTITY_INSERT [dbo].[RptBTTHhead] ON 

INSERT [dbo].[RptBTTHhead] ([tencongty], [diachicongty], [masothue], [tengiamdoc], [tenketoantruong], [ngaychungtu], [nguoilapphieu], [username], [id], [phieuso]) VALUES (N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'Duyên Thái,Thường Tín,Hà nội', N'0106881171', N'Mai Văn Trường', N'Nguyễn Thị Hồng Nguyên', CAST(N'2019-01-16 00:00:00.000' AS DateTime), N'Mai Văn Trường', N'tr1', 61, N'1')
SET IDENTITY_INSERT [dbo].[RptBTTHhead] OFF
SET IDENTITY_INSERT [dbo].[RptdetaiCDPS] ON 

INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Bản quyền, bằng sáng chế                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21185, 0, N'2133      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Bao bì luân chuyển                                                                                                                                                                                                               ', 0, 0, NULL, NULL, 0, 21186, 0, N'1532      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Bảo hiểm thất nghiệp                                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21187, 0, N'3386      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Bảo hiểm xã hội                                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21188, 0, N'3383      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Bảo hiểm y tế                                                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21189, 0, N'3384      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Bất động sản đầu tư                                                                                                                                                                                                              ', 0, 0, NULL, NULL, 0, 21190, 0, N'217       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Các khoản đầu tư khác nắm giữ đến ngày đáo hạn                                                                                                                                                                                   ', 0, 0, NULL, NULL, 0, 21191, 0, N'1288      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Các khoản đi vay                                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21192, 0, N'3411      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Các khoản giảm trừ doanh thu                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21193, 0, N'521       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Các loại thuế khác                                                                                                                                                                                                               ', 0, 0, NULL, NULL, 0, 21194, 0, N'33382     ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Các quỹ khác thuộc vốn chủ sở hữu                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21195, 0, N'418       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Cầm cố, thế chấp, ký quỹ, ký cược                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21196, 0, N'244       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Cây lâu năm, súc vật làm việc và cho sản phẩm                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21197, 0, N'2115      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chênh lệch đánh giá lại tài sản                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21198, 0, N'412       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chênh lệch tỷ giá do đánh giá lại các khoản mục tiền tệ có gốc ngoại tệ                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21199, 0, N'4131      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chênh lệch tỷ giá hối đoái                                                                                                                                                                                                       ', 0, 0, NULL, NULL, 0, 21200, 0, N'413       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chênh lệch tỷ giá hối đoái trong giai đoạn trước hoạt động                                                                                                                                                                       ', 0, 0, NULL, NULL, 0, 21201, 0, N'4132      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí bán hàng                                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21202, 0, N'641       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí bằng tiền khác                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21203, 0, N'6238      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí bằng tiền khác                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21204, 0, N'6278      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí bằng tiền khác                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21205, 0, N'6418      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí bằng tiền khác                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21206, 0, N'6428      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí bảo hành                                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21207, 0, N'6415      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí dịch vụ mua ngoài                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21208, 0, N'6237      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí dịch vụ mua ngoài                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21209, 0, N'6277      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí dịch vụ mua ngoài                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21210, 0, N'6417      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí dịch vụ mua ngoài                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21211, 0, N'6427      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí đồ dùng văn phòng                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21212, 0, N'6423      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí dự phòng                                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21213, 0, N'6426      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí dụng cụ sản xuất                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21214, 0, N'6233      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí dụng cụ sản xuất                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21215, 0, N'6273      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí dụng cụ, đồ dùng                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21216, 0, N'6413      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí khác                                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21217, 0, N'811       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí khấu hao máy thi công                                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21218, 0, N'6234      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí khấu hao TSCĐ                                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21219, 0, N'6274      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí khấu hao TSCĐ                                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21220, 0, N'6414      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí khấu hao TSCĐ                                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21221, 0, N'6424      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí nguyên vật liệu, bao bì                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21222, 0, N'6412      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí nguyên, vật liệu                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21223, 0, N'6232      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí nguyên, vật liệu                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21224, 0, N'6272      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí nhân công                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21225, 0, N'6231      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí nhân công trực tiếp                                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21226, 0, N'622       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí nhân viên                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21227, 0, N'6411      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí nhân viên phân xưởng                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21228, 0, N'6271      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí nhân viên quản lý                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21229, 0, N'6421      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí phải trả                                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21230, 0, N'335       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí quản lý doanh nghiệp                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21231, 0, N'642       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí sản xuất chung                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21232, 0, N'627       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí sản xuất, kinh doanh dở dang                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21233, 0, N'154       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí sử dụng máy thi công                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21234, 0, N'623       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí tài chính                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21235, 0, N'635       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí thu mua hàng hóa                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21236, 0, N'1562      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí thuế thu nhập doanh nghiệp                                                                                                                                                                                               ', 0, 0, NULL, NULL, 0, 21237, 0, N'821       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí thuế TNDN hiện hành                                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21238, 0, N'8211      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí thuế TNDN hoãn lại                                                                                                                                                                                                       ', 0, 0, NULL, NULL, 0, 21239, 0, N'8212      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí trả trước                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21240, 0, N'242       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi phí vật liệu quản lý                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21241, 0, N'6422      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi sự nghiệp                                                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21242, 0, N'161       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chi sự nghiệp năm nay                                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21243, 0, N'1612      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chiết khấu thương mại                                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21244, 0, N'5211      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chiết khấu trái phiếu                                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21245, 0, N'34312     ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Cho vay                                                                                                                                                                                                                          ', 0, 0, 0, 14544, 14544, 21246, 0, N'1283      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chứng khoán kinh doanh                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21247, 0, N'121       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chứng khoán và công cụ tài chính khác                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21248, 0, N'1218      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Chương trình phần mềm                                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21249, 0, N'2135      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Cổ phiếu                                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21250, 0, N'1211      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Cổ phiếu phổ thông có quyền biểu quyết                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21251, 0, N'41111     ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Cổ phiếu quỹ                                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21252, 0, N'419       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Cổ phiếu ưu đãi                                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21253, 0, N'41112     ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Công cụ, dụng cụ                                                                                                                                                                                                                 ', 0, 0, 0, 14544, 14544, 21254, 0, N'153       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Công cụ, dụng cụ                                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21255, 0, N'1531      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Đầu tư góp vốn vào đơn vị khác                                                                                                                                                                                                   ', 0, 0, NULL, NULL, 0, 21256, 0, N'2281      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Đầu tư khác                                                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21257, 0, N'228       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Đầu tư khác                                                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21258, 0, N'2288      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Đầu tư nắm giữ đến ngày đáo hạn                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21259, 0, N'128       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Đầu tư vào công ty con                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21260, 0, N'221       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Đầu tư vào công ty liên doanh, liên kết                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21261, 0, N'222       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Đồ dùng cho thuê                                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21262, 0, N'1533      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Doanh thu bán các thành phẩm                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21263, 0, N'5112      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Doanh thu bán hàng hóa                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21264, 0, N'5111      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Doanh thu bán hàng và cung cấp dịch vụ                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21265, 0, N'511       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Doanh thu chưa thực hiện                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21266, 0, N'3387      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Doanh thu cung cấp dịch vụ                                                                                                                                                                                                       ', 0, 0, NULL, NULL, 0, 21267, 0, N'5113      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Doanh thu hoạt động tài chính                                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21268, 0, N'515       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Doanh thu khác                                                                                                                                                                                                                   ', 0, 0, NULL, NULL, 0, 21269, 0, N'5118      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Doanh thu kinh doanh bất động sản đầu tư                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21270, 0, N'5117      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Doanh thu trợ cấp, trợ giá                                                                                                                                                                                                       ', 0, 0, NULL, NULL, 0, 21271, 0, N'5114      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Dự phòng bảo hành công trình xây dựng                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21272, 0, N'3522      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Dự phòng bảo hành sản phẩm hàng hóa                                                                                                                                                                                              ', 0, 0, NULL, NULL, 0, 21273, 0, N'3521      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Dự phòng giảm giá chứng khoán kinh doanh                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21274, 0, N'2291      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Dự phòng giảm giá hàng tồn kho                                                                                                                                                                                                   ', 0, 0, NULL, NULL, 0, 21275, 0, N'2294      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Dự phòng phải thu khó đòi                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21276, 0, N'2293      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Dự phòng phải trả                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21277, 0, N'352       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Dự phòng phải trả khác                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21278, 0, N'3524      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Dự phòng tái cơ cấu doanh nghiệp                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21279, 0, N'3523      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Dự phòng tổn thất đầu tư vào đơn vị khác                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21280, 0, N'2292      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Dự phòng tổn thất tài sản                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21281, 0, N'229       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Giá mua hàng hóa                                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21282, 0, N'1561      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Giá thành sản xuất                                                                                                                                                                                                               ', 0, 0, NULL, NULL, 0, 21283, 0, N'631       ')
GO
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Giá vốn hàng bán                                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21284, 0, N'632       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Giảm giá hàng bán                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21285, 0, N'5212      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Giao dịch mua bán lại trái phiếu chính phủ                                                                                                                                                                                       ', 0, 0, NULL, NULL, 0, 21286, 0, N'171       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Giấy phép và giấy phép nhượng quyền                                                                                                                                                                                              ', 0, 0, NULL, NULL, 0, 21287, 0, N'2136      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Hàng bán bị trả lại                                                                                                                                                                                                              ', 0, 0, NULL, NULL, 0, 21288, 0, N'5213      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Hàng gửi đi bán                                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21289, 0, N'157       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Hàng hóa                                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21290, 0, N'156       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Hàng hóa bất động sản                                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21291, 0, N'1567      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Hàng hoá kho bảo thuế                                                                                                                                                                                                            ', 0, 0, 0, 2544, 2544, 21292, 0, N'158       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Hàng mua đang đi đường                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21293, 0, N'151       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Hao mòn bất động sản đầu tư                                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21294, 0, N'2147      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Hao mòn tài sản cố định                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21295, 0, N'214       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Hao mòn TSCĐ hữu hình                                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21296, 0, N'2141      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Hao mòn TSCĐ thuê tài chính                                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21297, 0, N'2142      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Hao mòn TSCĐ vô hình                                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21298, 0, N'2143      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Kinh phí công đoàn                                                                                                                                                                                                               ', 0, 0, NULL, NULL, 0, 21299, 0, N'3382      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Lợi nhuận sau thuế chưa phân phối                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21300, 0, N'421       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Lợi nhuận sau thuế chưa phân phối năm nay                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21301, 0, N'4212      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Lợi nhuận sau thuế chưa phân phối năm trước                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21302, 0, N'4211      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Máy móc, thiết bị                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21303, 0, N'2112      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Mệnh giá trái phiếu                                                                                                                                                                                                              ', 0, 0, NULL, NULL, 0, 21304, 0, N'34311     ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Mua hàng                                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21305, 0, N'611       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Mua hàng hóa                                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21306, 0, N'6112      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Mua nguyên liệu, vật liệu                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21307, 0, N'6111      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Mua sắm TSCĐ                                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21308, 0, N'2411      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Ngoại tệ                                                                                                                                                                                                                         ', 0, 0, 0, 123123, 123123, 21309, 0, N'1112      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Ngoại tệ                                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21310, 0, N'1122      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Ngoại tệ                                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21311, 0, N'1132      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Nguồn kinh phí đã hình thành TSCĐ                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21312, 0, N'466       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Nguồn kinh phí sự nghiệp                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21313, 0, N'461       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Nguồn kinh phí sự nghiệp năm nay                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21314, 0, N'4612      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Nguồn kinh phí sự nghiệp năm trước                                                                                                                                                                                               ', 0, 0, NULL, NULL, 0, 21315, 0, N'4611      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Nguồn vốn đầu tư xây dựng cơ bản                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21316, 0, N'441       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Nguyên liệu, vật liệu                                                                                                                                                                                                            ', 0, 0, 14544, 1585476, 1570932, 21317, 0, N'152       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Nhà cửa, vật kiến trúc                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21318, 0, N'2111      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Nhãn hiệu, tên thương mại                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21319, 0, N'2134      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Nhận ký quỹ, ký cược                                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21320, 0, N'344       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Nợ thuê tài chính                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21321, 0, N'3412      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải thu của khách hàng                                                                                                                                                                                                          ', 0, 0, 2544, 0, 0, 21322, 2544, N'131       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải thu khác                                                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21323, 0, N'138       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải thu khác                                                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21324, 0, N'1388      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải thu nội bộ                                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21325, 0, N'136       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải thu nội bộ khác                                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21326, 0, N'1368      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải thu nội bộ về chênh lệch tỷ giá                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21327, 0, N'1362      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải thu nội bộ về chi phí đi vay đủ điều kiện được vốn hoá                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21328, 0, N'1363      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải thu về cổ phần hoá                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21329, 0, N'1385      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả cho người bán                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21330, 0, N'331       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả công nhân viên                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21331, 0, N'3341      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả người lao động                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21332, 0, N'334       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả người lao động khác                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21333, 0, N'3348      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả nội bộ                                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21334, 0, N'336       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả nội bộ khác                                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21335, 0, N'3368      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả nội bộ về chênh lệch tỷ giá                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21336, 0, N'3362      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả nội bộ về chi phí đi vay đủ điều kiện được vốn hoá                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21337, 0, N'3363      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả nội bộ về vốn kinh doanh                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21338, 0, N'3361      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả về cổ phần hoá                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21339, 0, N'3385      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả, phải nộp khác                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21340, 0, N'338       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phải trả, phải nộp khác                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21341, 0, N'3388      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phí, lệ phí và các khoản phải nộp khác                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21342, 0, N'3339      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phụ trội trái phiếu                                                                                                                                                                                                              ', 0, 0, NULL, NULL, 0, 21343, 0, N'34313     ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Phương tiện vận tải, truyền dẫn                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21344, 0, N'2113      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quỹ bình ổn giá                                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21345, 0, N'357       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quỹ đầu tư phát triển                                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21346, 0, N'414       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quỹ hỗ trợ sắp xếp doanh nghiệp                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21347, 0, N'417       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quỹ khen thưởng                                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21348, 0, N'3531      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quỹ khen thưởng phúc lợi                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21349, 0, N'353       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quỹ phát triển khoa học và công nghệ                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21350, 0, N'356       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quỹ phát triển khoa học và công nghệ                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21351, 0, N'3561      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quỹ phát triển khoa học và công nghệ đã hình thành TSCĐ                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21352, 0, N'3562      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quỹ phúc lợi                                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21353, 0, N'3532      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quỹ phúc lợi đã hình thành TSCĐ                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21354, 0, N'3533      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quỹ thưởng ban quản lý điều hành công ty                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21355, 0, N'3534      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quyền chọn chuyển đổi trái phiếu                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21356, 0, N'4113      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quyền phát hành                                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21357, 0, N'2132      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Quyền sử dụng đất                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21358, 0, N'2131      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Sửa chữa lớn TSCĐ                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21359, 0, N'2413      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tài sản cố định hữu hình                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21360, 0, N'211       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tài sản cố định thuê tài chính                                                                                                                                                                                                   ', 0, 0, NULL, NULL, 0, 21361, 0, N'212       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tài sản cố định vô hình                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21362, 0, N'213       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tài sản thiếu chờ xử lý                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21363, 0, N'1381      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tài sản thừa chờ giải quyết                                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21364, 0, N'3381      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tài sản thuế thu nhập hoãn lại                                                                                                                                                                                                   ', 0, 0, NULL, NULL, 0, 21365, 0, N'243       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tạm ứng                                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21366, 0, N'141       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thặng dư vốn cổ phần                                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21367, 0, N'4112      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thành phẩm                                                                                                                                                                                                                       ', 0, 0, NULL, NULL, 0, 21368, 0, N'155       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thành phẩm bất động sản                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21369, 0, N'1557      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thành phẩm nhập kho                                                                                                                                                                                                              ', 0, 0, NULL, NULL, 0, 21370, 0, N'1551      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thanh toán theo tiến độ kế hoạch hợp đồng xây dựng                                                                                                                                                                               ', 0, 0, NULL, NULL, 0, 21371, 0, N'337       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thiết bị, dụng cụ quản lý                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21372, 0, N'2114      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thiết bị, phụ tùng thay thế                                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21373, 0, N'1534      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế bảo vệ môi trường                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21374, 0, N'33381     ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế bảo vệ môi trường và các loại thuế khác                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21375, 0, N'3338      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế giá trị gia tăng phải nộp                                                                                                                                                                                                   ', 0, 0, NULL, NULL, 0, 21376, 0, N'3331      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế GTGT đầu ra                                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21377, 0, N'33311     ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế GTGT được khấu trừ                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21378, 0, N'133       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế GTGT được khấu trừ của hàng hóa, dịch vụ                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21379, 0, N'1331      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế GTGT được khấu trừ của TSCĐ                                                                                                                                                                                                 ', 0, 0, 232, 0, 0, 21380, 232, N'1332      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế GTGT hàng nhập khẩu                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21381, 0, N'33312     ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế nhà đất, tiền thuê đất                                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21382, 0, N'3337      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế tài nguyên                                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21383, 0, N'3336      ')
GO
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế thu nhập cá nhân                                                                                                                                                                                                            ', 0, 0, NULL, NULL, 0, 21384, 0, N'3335      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế thu nhập doanh nghiệp                                                                                                                                                                                                       ', 0, 0, NULL, NULL, 0, 21385, 0, N'3334      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế thu nhập hoãn lại phải trả                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21386, 0, N'347       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế tiêu thụ đặc biệt                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21387, 0, N'3332      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế và các khoản phải nộp Nhà nước                                                                                                                                                                                              ', 0, 0, NULL, NULL, 0, 21388, 0, N'333       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế xuất, nhập khẩu                                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21389, 0, N'3333      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Thuế, phí và lệ phí                                                                                                                                                                                                              ', 0, 0, NULL, NULL, 0, 21390, 0, N'6425      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tiền đang chuyển                                                                                                                                                                                                                 ', 0, 0, NULL, NULL, 0, 21391, 0, N'113       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tiền gửi có kỳ hạn                                                                                                                                                                                                               ', 0, 0, NULL, NULL, 0, 21392, 0, N'1281      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tiền gửi Ngân hàng                                                                                                                                                                                                               ', 0, 0, NULL, NULL, 0, 21393, 0, N'112       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tiền mặt                                                                                                                                                                                                                         ', 0, 0, 123123, 0, 0, 21394, 123123, N'111       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tiền Việt Nam                                                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21395, 0, N'1111      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tiền Việt Nam                                                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21396, 0, N'1121      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Tiền Việt Nam                                                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21397, 0, N'1131      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Trái phiếu                                                                                                                                                                                                                       ', 0, 0, 1600020, 232, 0, 21398, 1599788, N'1212      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Trái phiếu                                                                                                                                                                                                                       ', 0, 0, NULL, NULL, 0, 21399, 0, N'1282      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Trái phiếu phát hành                                                                                                                                                                                                             ', 0, 0, NULL, NULL, 0, 21400, 0, N'343       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Trái phiếu thường                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21401, 0, N'3431      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'TSCĐ hữu hình thuê tài chính.                                                                                                                                                                                                    ', 0, 0, NULL, NULL, 0, 21402, 0, N'2121      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'TSCĐ khác                                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21403, 0, N'2118      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'TSCĐ vô hình khác                                                                                                                                                                                                                ', 0, 0, NULL, NULL, 0, 21404, 0, N'2138      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'TSCĐ vô hình thuê tài chính                                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21405, 0, N'2122      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Vàng tiền tệ                                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21406, 0, N'1113      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Vàng tiền tệ                                                                                                                                                                                                                     ', 0, 0, NULL, NULL, 0, 21407, 0, N'1123      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Vay và nợ thuê tài chính                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21408, 0, N'341       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Vốn đầu tư của chủ sở hữu                                                                                                                                                                                                        ', 0, 0, NULL, NULL, 0, 21409, 0, N'411       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Vốn góp của chủ sở hữu                                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21410, 0, N'4111      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Vốn khác                                                                                                                                                                                                                         ', 0, 0, NULL, NULL, 0, 21411, 0, N'4118      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Vốn kinh doanh ở các đơn vị trực thuộc                                                                                                                                                                                           ', 0, 0, NULL, NULL, 0, 21412, 0, N'1361      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Xác định kết quả kinh doanh                                                                                                                                                                                                      ', 0, 0, NULL, NULL, 0, 21413, 0, N'911       ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Xây dựng cơ bản                                                                                                                                                                                                                  ', 0, 0, NULL, NULL, 0, 21414, 0, N'2412      ')
INSERT [dbo].[RptdetaiCDPS] ([username], [tentk], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [matk]) VALUES (N'tr1', N'Xây dựng cơ bản dở dang                                                                                                                                                                                                          ', 0, 0, NULL, NULL, 0, 21415, 0, N'241       ')
SET IDENTITY_INSERT [dbo].[RptdetaiCDPS] OFF
SET IDENTITY_INSERT [dbo].[RPtdetailCDKT200lientuc] ON 

INSERT [dbo].[RPtdetailCDKT200lientuc] ([cn111tien], [cn112tientduong], [cn121chungkhoan], [cn122ckduphong], [cn123dtdenngay], [cn131ptkhach], [cn132tratruoc], [cn133pthunbnganh], [cn134pthutiendokh], [cn135pthuchovay], [cn136ptnganhan], [cn137dpptnganhan], [cn139tsthieucho], [cn141hangton], [cn149duphonght], [cn151cftratruoc], [cn152vatkhautru], [cn153thuepthukac], [cn154traiphieu], [cn155tskhacnh], [cn211ptkhach], [cn212tratruocdh], [cn213vonodonvi], [cn214pthunbo], [cn215pthuchovay], [cn216pthukhac], [cn219duphongpt], [cn222tscdngia], [cn223tskhauh], [cn225tscdthung], [cn226tscdthuekha], [cn228tscdvohnggia], [cn229tscdvhkhauh], [cn231bdsngia], [cn232bdshaomon], [cn241cfkddd], [cn242cfxddd], [cn251dtuctycon], [cn252dtuctylienket], [cn253dtukhac], [cn254duphongdt], [cn255dtudaohan], [cn261cftratruocdn], [cn262thuetndnhl], [cn263vtuthietbidn], [cn268tskhac], [cn311ptnbannh], [cn312ngmuatratr], [cn313thuephainop], [cn314ptracnhan], [cn315cphiptranh], [cn316cfptranbonh], [cn317ptrtheoluong], [cn318pthuchunhan], [cn319ptranhan], [cn320vaynotcnhan], [cn321duphptranh], [cn322quykhen], [cn323quygia], [cn324bantraiphieu], [cn331nodnngban], [cn332ngmuatratdn], [cn333cphiphaitra], [cn334ptranbvevon], [cn335ptranbdaihan], [cn336dthuchthdn], [cn337ptradnkhac], [cn338vaynodn], [cn339traiphieu], [cn340cophieu], [cn341tnhoanlai], [cn342duphongdn], [cn343quykhoahoc], [cn411vongopcsh], [cn411bcpudai], [cn412thangduvon], [cn413traiphieu], [cn414voncshkhac], [cn415cphieuquy], [cn416chenhlechts], [cn417tygia], [cn418dautuptrien], [cn419quyxxdn], [cn420quykhacsh], [cn421lnsauthue], [cn421alnkytruoc], [cn421blnkynay], [cn422vonxdcb], [cn431nkinhphi], [cn432kpthanhtscd], [cn411acophieupt], [dn111tien], [dn112tientduong], [dn121chungkhoan], [dn122ckduphong], [dn123dtdenngay], [dn131ptkhach], [dn132tratruoc], [dn133pthunbnganh], [dn134pthutiendokh], [dn135pthuchovay], [dn136ptnganhan], [dn137dpptnganhan], [dn139tsthieucho], [dn141hangton], [dn149duphonght], [dn151cftratruoc], [dn152vatkhautru], [dn153thuepthukac], [dn154traiphieu], [dn155tskhacnh], [dn211ptkhach], [dn212tratruocdh], [dn213vonodonvi], [dn214pthunbo], [dn215pthuchovay], [dn216pthukhac], [dn219duphongpt], [dn222tscdngia], [dn223tskhauh], [dn225tscdthung], [dn226tscdthuekha], [dn228tscdvohnggia], [dn229tscdvhkhauh], [dn231bdsngia], [dn232bdshaomon], [dn241cfkddd], [dn242cfxddd], [dn251dtuctycon], [dn252dtuctylienket], [dn253dtukhac], [dn254duphongdt], [dn255dtudaohan], [dn261cftratruocdn], [dn262thuetndnhl], [dn263vtuthietbidn], [dn268tskhac], [dn311ptnbannh], [dn312ngmuatratr], [dn313thuephainop], [dn314ptracnhan], [dn315cphiptranh], [dn316cfptranbonh], [dn317ptrtheoluong], [dn318pthuchunhan], [dn319ptranhan], [dn320vaynotcnhan], [dn321duphptranh], [dn322quykhen], [dn323quygia], [dn324bantraiphieu], [dn331nodnngban], [dn332ngmuatratdn], [dn333cphiphaitra], [dn334ptranbvevon], [dn335ptranbdaihan], [dn336dthuchthdn], [dn337ptradnkhac], [dn338vaynodn], [dn339traiphieu], [dn340cophieu], [dn341tnhoanlai], [dn342duphongdn], [dn343quykhoahoc], [dn411vongopcsh], [dn411bcpudai], [dn412thangduvon], [dn413traiphieu], [dn414voncshkhac], [dn415cphieuquy], [dn416chenhlechts], [dn417tygia], [dn418dautuptrien], [dn419quyxxdn], [dn420quykhacsh], [dn421lnsauthue], [dn421alnkytruoc], [dn421blnkynay], [dn422vonxdcb], [dn431nkinhphi], [dn432kpthanhtscd], [dn411acophieupt], [id], [username]) VALUES (-12218111, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 232, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 13, 0, 2, 13, 0, 0, 3124, 0, 0, 321, 4, 0, 0, 0, 0, 0, 3214, 4, 0, 3124, 2314, 0, 1234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 69, N'tr1')
SET IDENTITY_INSERT [dbo].[RPtdetailCDKT200lientuc] OFF
SET IDENTITY_INSERT [dbo].[RPtdetailKQKD200] ON 

INSERT [dbo].[RPtdetailKQKD200] ([nay01dt], [nay02giamdt], [nay11giavon], [naydttaichinh], [naycftaichinh], [naycflaivay], [naycfbanhang], [naycfquanlydn], [naythunhapkhac], [naycfkhac], [naycftndnhienhanh], [nayfdnhoanlai], [naylaicbcophieu], [naylaigiaomtrencphieu], [truoc01dt], [truoc02giamdt], [truoc11giavon], [truocdttaichinh], [truoccftaichinh], [truoccflaivay], [truoccfbanhang], [truoccfquanlydn], [truocthunhapkhac], [truoccfkhac], [truoccftndnhienhanh], [truoccfdnhoanlai], [truoclaicbcophieu], [truoclaigiaomtrencphieu], [id], [username]) VALUES (0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 126, N'tr1')
SET IDENTITY_INSERT [dbo].[RPtdetailKQKD200] OFF
SET IDENTITY_INSERT [dbo].[RPtdetaillchuyenttttiep] ON 

INSERT [dbo].[RPtdetaillchuyenttttiep] ([nn01thudthu], [nn02chiccap], [nn03chilaodong], [nn05chithuetndn], [nn06thukhac], [nn07chikhac], [nn20llkd], [nn21chitsan], [nn22thutaisan], [nn23chichovay], [nn25chidtdonvikhac], [nn26thudtdonvikhac], [nn27thulaicotuc], [nn31thucophieu], [nn32chitravon], [nn33thudivay], [nn34tragoc], [nn35tragocthue], [nn36tracotuc], [nn50lltrongky], [nn60tiendauky], [nn61tientygia], [nn70tiencuoiky], [nt01thudthu], [nt02chiccap], [nt03chilaodong], [nt04chilaivay], [nt05chithuetndn], [nt06thukhac], [nt07chikhac], [nt21chitsan], [nt22thutaisan], [nt23chichovay], [nt24thuchovay], [nt25chidtdonvikhac], [nt26thudtdonvikhac], [nt31thucophieu], [nt32chitravon], [nt33thudivay], [nt34tragoc], [nt27thulaicotuc], [nt20llkd], [nn24thuchovay], [nn04chilaivay], [nt35tragocthue], [nt36tracotuc], [nt50lltrongky], [nt60tiendauky], [nt70tiencuoiky], [nt61tientygia], [id], [username]) VALUES (0, 0, 0, 0, 123123, -123123, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, 0, NULL, 33333, 0, 132, 0, 0, 0, 21, 3, 0, 0, 21, 3, 0, 213, 0, 0, 213123, 213, NULL, 0, 0, 12, 3213, 0, 0, NULL, 21, 92, N'tr1')
SET IDENTITY_INSERT [dbo].[RPtdetaillchuyenttttiep] OFF
SET IDENTITY_INSERT [dbo].[RptdetailSocaichitiet] ON 

INSERT [dbo].[RptdetailSocaichitiet] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'TH 12', N'ádasdfasfds', N'111', 12321323, 0, NULL, 27)
INSERT [dbo].[RptdetailSocaichitiet] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-20 00:00:00.000' AS DateTime), N'PT 122', N'adsfasf', N'155', 0, 123123, NULL, 28)
SET IDENTITY_INSERT [dbo].[RptdetailSocaichitiet] OFF
SET IDENTITY_INSERT [dbo].[RptdetaiNKC] ON 

INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-01-18 00:00:00.000' AS DateTime), N'PT 23', N'ADDASFSAF', N'111', 0, 1212, NULL, 2462)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-01-18 00:00:00.000' AS DateTime), N'PT 23', N'ADDASFSAF', N'33381', 1212, 0, NULL, 2463)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-01-18 00:00:00.000' AS DateTime), N'PC 67', N'ÁDFASDFSDF', N'1218', 0, 1413234, NULL, 2464)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-01-18 00:00:00.000' AS DateTime), N'PC 67', N'ÁDFASDFSDF', N'111', 1413234, 0, NULL, 2465)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-01-18 00:00:00.000' AS DateTime), N'PC 67', N'ÁDFASDFSDF', N'1218', 0, 1413234, NULL, 2466)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-01-18 00:00:00.000' AS DateTime), N'PC 67', N'ÁDFASDFSDF', N'111', 1413234, 0, NULL, 2467)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-01-18 00:00:00.000' AS DateTime), N'PC 345', N'ADSAF', N'141', 0, 123, NULL, 2468)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-01-18 00:00:00.000' AS DateTime), N'PC 345', N'ADSAF', N'111', 123, 0, NULL, 2469)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-01-18 00:00:00.000' AS DateTime), N'PC 345', N'ADSAF', N'141', 0, 123, NULL, 2470)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-01-18 00:00:00.000' AS DateTime), N'PC 345', N'ADSAF', N'111', 123, 0, NULL, 2471)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-19 00:00:00.000' AS DateTime), N'TH sa', N'SA', N'111', 0, 12, NULL, 2472)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-19 00:00:00.000' AS DateTime), N'TH sa', N'SA', N'128', 12, 0, NULL, 2473)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-19 00:00:00.000' AS DateTime), N'TH sa', N'SAqd', N'111', 0, 12, NULL, 2474)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-19 00:00:00.000' AS DateTime), N'TH sa', N'SAqd', N'128', 12, 0, NULL, 2475)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-19 00:00:00.000' AS DateTime), N'PT 2', N'1212', N'111', 0, 12, NULL, 2476)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-19 00:00:00.000' AS DateTime), N'PT 2', N'1212', N'131', 12, 0, NULL, 2477)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-19 00:00:00.000' AS DateTime), N'PT 2', N'ÁDASFDSAF', N'111', 0, 1200, NULL, 2478)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-19 00:00:00.000' AS DateTime), N'PT 2', N'ÁDASFDSAF', N'214', 1200, 0, NULL, 2479)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-20 00:00:00.000' AS DateTime), N'PT 12', N'', N'111', 0, 1221, NULL, 2480)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-20 00:00:00.000' AS DateTime), N'PT 12', N'', N'1113', 1221, 0, NULL, 2481)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-20 00:00:00.000' AS DateTime), N'PT 12', N'ádADS', N'111', 0, 233321, NULL, 2482)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-20 00:00:00.000' AS DateTime), N'PT 12', N'ádADS', N'2147', 233321, 0, NULL, 2483)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-20 00:00:00.000' AS DateTime), N'PT 122', N'adsfasf', N'111', 0, 123123, NULL, 2484)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-20 00:00:00.000' AS DateTime), N'PT 122', N'adsfasf', N'155', 123123, 0, NULL, 2485)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-21 00:00:00.000' AS DateTime), N'TH 121', N'`12', N'136', 0, 123, NULL, 2486)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-21 00:00:00.000' AS DateTime), N'TH 121', N'`12', N'1361', 123, 0, NULL, 2487)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-21 00:00:00.000' AS DateTime), N'TH 33', N'13321', N'161', 0, 23, NULL, 2488)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-21 00:00:00.000' AS DateTime), N'TH 33', N'13321', N'1362', 23, 0, NULL, 2489)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-21 00:00:00.000' AS DateTime), N'TH 33', N'13321', N'161', 0, 334, NULL, 2490)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-21 00:00:00.000' AS DateTime), N'TH 33', N'13321', N'1362', 334, 0, NULL, 2491)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-21 00:00:00.000' AS DateTime), N'TH 33', N'13321', N'161', 0, 123123, NULL, 2492)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-21 00:00:00.000' AS DateTime), N'TH 33', N'13321', N'1362', 123123, 0, NULL, 2493)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-21 00:00:00.000' AS DateTime), N'TH 33', N'13321', N'2133', 0, 211323, NULL, 2494)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-21 00:00:00.000' AS DateTime), N'TH 33', N'13321', N'1362', 211323, 0, NULL, 2495)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'TH 14', N'đac', N'1361', 0, 33123, NULL, 2496)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'TH 14', N'đac', N'1331', 33123, 0, NULL, 2497)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'TH HD 13', N'Doanh thu tháng 1 mistu', N'131', 0, 123123216, NULL, 2498)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'TH HD 13', N'Doanh thu tháng 1 mistu', N'5111', 123123216, 0, NULL, 2499)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PC 12', N'tạm ứng công tác', N'141', 0, 10000000, NULL, 2500)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PC 12', N'tạm ứng công tác', N'111', 10000000, 0, NULL, 2501)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PC 12', N'ứng trả be a', N'141', 0, 12000000, NULL, 2502)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PC 12', N'ứng trả be a', N'111', 12000000, 0, NULL, 2503)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PC 12', N'tạm ứng công tác', N'141', 0, 10000000, NULL, 2504)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PC 12', N'tạm ứng công tác', N'111', 10000000, 0, NULL, 2505)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PC 12', N'ứng trả be a', N'141', 0, 12000000, NULL, 2506)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PC 12', N'ứng trả be a', N'111', 12000000, 0, NULL, 2507)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'TH 12', N'ádasdfasfds', N'111', 0, 12321323, NULL, 2508)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'TH 12', N'ádasdfasfds', N'111', 12321323, 0, NULL, 2509)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 3444', N'1đáSDA', N'111', 0, 1212, NULL, 2510)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 3444', N'1đáSDA', N'112', 1212, 0, NULL, 2511)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 3444', N'ADFADSFASDF', N'111', 0, 1212, NULL, 2512)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 3444', N'ADFADSFASDF', N'141', 1212, 0, NULL, 2513)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 23323', N'dsADS', N'111', 0, 22312, NULL, 2514)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 23323', N'dsADS', N'112', 22312, 0, NULL, 2515)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 23323', N'adsasd', N'111', 0, 223, NULL, 2516)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 23323', N'adsasd', N'141', 223, 0, NULL, 2517)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 23323', N'dsADS', N'111', 0, 22312, NULL, 2518)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 23323', N'dsADS', N'112', 22312, 0, NULL, 2519)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 23323', N'adsasd', N'111', 0, 223, NULL, 2520)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 23323', N'adsasd', N'141', 223, 0, NULL, 2521)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 1556', N'scsadf', N'111', 0, 123123, NULL, 2522)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 1556', N'scsadf', N'1361', 123123, 0, NULL, 2523)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 1556', N'scsadf', N'111', 0, 123123, NULL, 2524)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-22 00:00:00.000' AS DateTime), N'PT 1556', N'scsadf', N'1361', 123123, 0, NULL, 2525)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PT 44', N'dsafdasf', N'111', 0, 12, NULL, 2526)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PT 44', N'dsafdasf', N'2292', 12, 0, NULL, 2527)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PT 44', N'adsfdsfsdf', N'111', 0, 123111, NULL, 2528)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PT 44', N'adsfdsfsdf', N'141', 123111, 0, NULL, 2529)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PT 454', N'SADFADSF', N'111', 0, 123123, NULL, 2530)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PT 454', N'SADFADSF', N'214', 123123, 0, NULL, 2531)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PC 233', N'đà', N'111', 0, 123123, NULL, 2532)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PC 233', N'đà', N'111', 123123, 0, NULL, 2533)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PT 12222', N'ádfdsafdsaf', N'111', 0, 123123, NULL, 2534)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PT 12222', N'ádfdsafdsaf', N'141', 123123, 0, NULL, 2535)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PC 33', N'ádfdsaf', N'141', 0, 123123, NULL, 2536)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PC 33', N'ádfdsaf', N'111', 123123, 0, NULL, 2537)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PC 33', N'dsafdsaf', N'171', 0, 123123, NULL, 2538)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-23 00:00:00.000' AS DateTime), N'PC 33', N'dsafdsaf', N'111', 123123, 0, NULL, 2539)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-29 00:00:00.000' AS DateTime), N'TH 13', N'2323', N'1111', 0, 23232, NULL, 2540)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-29 00:00:00.000' AS DateTime), N'TH 13', N'2323', N'113', 23232, 0, NULL, 2541)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-29 00:00:00.000' AS DateTime), N'TH 13', N'2323', N'1111', 0, 8080808, NULL, 2542)
INSERT [dbo].[RptdetaiNKC] ([username], [Ngaychungtu], [machungtu], [diengiai], [taikhoandoiung], [psco], [psno], [ton], [id]) VALUES (N'tr1', CAST(N'2018-03-29 00:00:00.000' AS DateTime), N'TH 13', N'2323', N'113', 8080808, 0, NULL, 2543)
SET IDENTITY_INSERT [dbo].[RptdetaiNKC] OFF
SET IDENTITY_INSERT [dbo].[RptdetaiTHchitiet] ON 

INSERT [dbo].[RptdetaiTHchitiet] ([username], [tenchitiet], [stt], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [machitiet]) VALUES (N'tr1', N'Nguyễn Mai Khanh', 1, 0, 0, 0, 0, 0, 29, 0, 1)
INSERT [dbo].[RptdetaiTHchitiet] ([username], [tenchitiet], [stt], [Nodk], [Codk], [Psno], [Psco], [Cock], [id], [Nock], [machitiet]) VALUES (N'tr1', N'Phan Đình Đức', 2, 0, 0, 0, 0, 0, 30, 0, 2)
SET IDENTITY_INSERT [dbo].[RptdetaiTHchitiet] OFF
SET IDENTITY_INSERT [dbo].[RptdetaiTHxuatnhapton] ON 

INSERT [dbo].[RptdetaiTHxuatnhapton] ([username], [mahanghoa], [stt], [donvi], [tenhanghoa], [tondaukysoluong], [tondaukythanhtien], [nhaptrongkysoluong], [nhaptrongkythanhtien], [xuattrongkysoluong], [xuattrongkythanhtien], [toncuoikysoluong], [toncuoikythanhtien], [dongiaton], [id]) VALUES (N'tr1', N'ádfasdf31123', 1, N'cây', N'phấn', 12, 34, 0, 0, 0, 0, 12, 34, 2.8333333333333335, 94)
INSERT [dbo].[RptdetaiTHxuatnhapton] ([username], [mahanghoa], [stt], [donvi], [tenhanghoa], [tondaukysoluong], [tondaukythanhtien], [nhaptrongkysoluong], [nhaptrongkythanhtien], [xuattrongkysoluong], [xuattrongkythanhtien], [toncuoikysoluong], [toncuoikythanhtien], [dongiaton], [id]) VALUES (N'tr1', N'34eadÁ', 2, N'cÁI', N'ZCZXC', 0, 0, 0, 0, 0, 0, 0, 0, 0, 95)
SET IDENTITY_INSERT [dbo].[RptdetaiTHxuatnhapton] OFF
SET IDENTITY_INSERT [dbo].[RPtheadCDKT200mau01] ON 

INSERT [dbo].[RPtheadCDKT200mau01] ([nam], [giamdoc], [ketoantruong], [nguoighiso], [tencongty], [masothue], [diachicongty], [id], [username], [taikhoan]) VALUES (N'2018', N'Mai Văn Trường', N'Nguyễn Thị Hồng Nguyên', N'Mai Văn Trường', N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'0106881171', N'Duyên Thái,Thường Tín,Hà nội', 159, N'tr1', NULL)
SET IDENTITY_INSERT [dbo].[RPtheadCDKT200mau01] OFF
SET IDENTITY_INSERT [dbo].[RPtheadCDPS] ON 

INSERT [dbo].[RPtheadCDPS] ([tungay], [denngay], [giamdoc], [ketoantruong], [nguoighiso], [tencongty], [masothue], [diachicongty], [id], [username], [taikhoan]) VALUES (CAST(N'2018-01-01 00:00:00.000' AS DateTime), CAST(N'2018-12-31 00:00:00.000' AS DateTime), N'Mai Văn Trường', N'Nguyễn Thị Hồng Nguyên', N'Mai Văn Trường', N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'0106881171', N'Duyên Thái,Thường Tín,Hà nội', 118, N'tr1', NULL)
SET IDENTITY_INSERT [dbo].[RPtheadCDPS] OFF
SET IDENTITY_INSERT [dbo].[RPtheadKQKD200] ON 

INSERT [dbo].[RPtheadKQKD200] ([nam], [giamdoc], [ketoantruong], [nguoighiso], [tencongty], [masothue], [diachicongty], [id], [username], [taikhoan]) VALUES (N'2019', N'Mai Văn Trường', N'Nguyễn Thị Hồng Nguyên', N'Mai Văn Trường', N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'0106881171', N'Duyên Thái,Thường Tín,Hà nội', 136, N'tr1', NULL)
SET IDENTITY_INSERT [dbo].[RPtheadKQKD200] OFF
SET IDENTITY_INSERT [dbo].[RPtheadLCTTTtiep] ON 

INSERT [dbo].[RPtheadLCTTTtiep] ([nam], [giamdoc], [ketoantruong], [nguoighiso], [tencongty], [masothue], [diachicongty], [id], [username], [taikhoan]) VALUES (N'2018', N'Mai Văn Trường', N'Nguyễn Thị Hồng Nguyên', N'Mai Văn Trường', N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'0106881171', N'Duyên Thái,Thường Tín,Hà nội', 92, N'tr1', NULL)
SET IDENTITY_INSERT [dbo].[RPtheadLCTTTtiep] OFF
SET IDENTITY_INSERT [dbo].[RPtheadNKC] ON 

INSERT [dbo].[RPtheadNKC] ([nam], [giamdoc], [ketoantruong], [nguoighiso], [tencongty], [masothue], [diachicongty], [id], [username], [taikhoan]) VALUES (N'2018', N'Mai Văn Trường', N'Trần Thị Thu', N'Mai Văn Trường', N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'012122848', N'Duyên Thái,Thường Tín,Hà nội', 51, N'tr1', NULL)
SET IDENTITY_INSERT [dbo].[RPtheadNKC] OFF
SET IDENTITY_INSERT [dbo].[RPtheadSocai] ON 

INSERT [dbo].[RPtheadSocai] ([tungay], [denngay], [nodauky], [codauky], [psno], [psco], [cocuoiky], [nocuoiky], [tencongty], [masothue], [diachicongty], [id], [username], [taikhoan]) VALUES (CAST(N'2018-11-01 00:00:00.000' AS DateTime), CAST(N'2018-11-13 00:00:00.000' AS DateTime), 0, 0, 0, 0, 0, 0, N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'0106881171', N'Duyên Thái,Thường Tín,Hà nội', 45, N'tr1', N'1282      :Trái phiếu')
SET IDENTITY_INSERT [dbo].[RPtheadSocai] OFF
SET IDENTITY_INSERT [dbo].[RPtheadSocaichitiet] ON 

INSERT [dbo].[RPtheadSocaichitiet] ([tungay], [denngay], [nodauky], [codauky], [psno], [psco], [cocuoiky], [nocuoiky], [tencongty], [masothue], [diachicongty], [id], [username], [taikhoan], [tenchitiettk]) VALUES (CAST(N'2018-03-01 00:00:00.000' AS DateTime), CAST(N'2018-03-22 00:00:00.000' AS DateTime), 121659, 3418, 123123, 12321323, 12324741, 244782, N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'012122848', N'Duyên Thái,Thường Tín,Hà nội', 14, N'tr1', N'111       :Tiền mặt', N'Mai Văn Trường')
SET IDENTITY_INSERT [dbo].[RPtheadSocaichitiet] OFF
SET IDENTITY_INSERT [dbo].[RPtheadTHchitiet] ON 

INSERT [dbo].[RPtheadTHchitiet] ([tencongty], [masothue], [diachicongty], [id], [username], [taikhoan], [tungay], [denngay]) VALUES (N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'012122848', N'Duyên Thái,Thường Tín,Hà nội', 22, N'tr1', N'331       :Phải trả cho người bán', CAST(N'2018-02-25 00:00:00.000' AS DateTime), CAST(N'2018-03-27 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[RPtheadTHchitiet] OFF
SET IDENTITY_INSERT [dbo].[RPtheadTHxuatnhapton] ON 

INSERT [dbo].[RPtheadTHxuatnhapton] ([tencongty], [masothue], [diachicongty], [id], [username], [tungay], [denngay], [kho]) VALUES (N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'0106881171', N'Duyên Thái,Thường Tín,Hà nội', 61, N'tr1', CAST(N'2017-08-19 06:29:10.000' AS DateTime), CAST(N'2017-08-31 06:29:34.000' AS DateTime), N'Kho sH')
SET IDENTITY_INSERT [dbo].[RPtheadTHxuatnhapton] OFF
SET IDENTITY_INSERT [dbo].[RptPhatsinhcdkt200] ON 

INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'111', 1, -1, 24, 0, 24, 1, NULL, NULL, NULL, N'Tiền mặt                                                                                                                                                                                                                         ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'111', NULL, 1, 23134, 0, 23134, 2, NULL, NULL, NULL, N'Tiền mặt                                                                                                                                                                                                                         ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'111       ', 1, 1, 98525, 746, 97779, 3, NULL, NULL, NULL, N'Tiền mặt                                                                                                                                                                                                                         ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'1111', NULL, -1, 4432345432064, 0, 4432345432064, 4, NULL, NULL, NULL, N'Tiền Việt Nam                                                                                                                                                                                                                    ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'1121      ', NULL, -1, 0, 23234324, -23234324, 5, NULL, NULL, NULL, N'Tiền Việt Nam                                                                                                                                                                                                                    ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'141', 1, 0, 0, 12, -12, 6, NULL, NULL, NULL, N'Tạm ứng                                                                                                                                                                                                                          ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'141', 1, 1, 0, 732, -732, 7, NULL, NULL, NULL, N'Tạm ứng                                                                                                                                                                                                                          ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'152', NULL, -1, 2313444, 0, 2313444, 8, NULL, NULL, NULL, N'Nguyên liệu, vật liệu                                                                                                                                                                                                            ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'152', 1, -1, 1310, 1296, 14, 9, NULL, NULL, NULL, N'Nguyên liệu, vật liệu                                                                                                                                                                                                            ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'154', 1, -1, 144, 97205, -97061, 10, NULL, NULL, NULL, N'Chi phí sản xuất, kinh doanh dở dang                                                                                                                                                                                             ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'155', NULL, -1, 2313444, 0, 2313444, 11, NULL, NULL, NULL, N'Thành phẩm                                                                                                                                                                                                                       ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'211       ', NULL, -1, 23234324, 0, 23234324, 12, NULL, NULL, NULL, N'Tài sản cố định hữu hình                                                                                                                                                                                                         ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'331', 1, -1, 0, 12, -12, 13, NULL, NULL, NULL, N'Phải trả cho người bán                                                                                                                                                                                                           ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'411', NULL, -1, 0, 4432345432064, -4432345432064, 14, NULL, NULL, NULL, N'Vốn đầu tư của chủ sở hữu                                                                                                                                                                                                        ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'911', NULL, -1, 0, 4650022, -4650022, 15, NULL, NULL, NULL, N'Xác định kết quả kinh doanh                                                                                                                                                                                                      ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'111       ', NULL, -1, 123123, 0, 123123, 2703, N'tr1', NULL, NULL, N'Tiền mặt                                                                                                                                                                                                                         ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'111       ', NULL, -1, 123123, 0, 123123, 2704, N'tr1', NULL, N'', N'Tiền mặt                                                                                                                                                                                                                         ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'1112', NULL, 0, 0, 123123, -123123, 2705, N'tr1', NULL, NULL, N'Ngoại tệ                                                                                                                                                                                                                         ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'1131      ', NULL, -1, 0, 12341234, -12341234, 2706, N'tr1', NULL, N'', N'Tiền Việt Nam                                                                                                                                                                                                                    ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'1212      ', NULL, -1, 1600020, 232, 1599788, 2707, N'tr1', NULL, N'', N'Trái phiếu                                                                                                                                                                                                                       ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'1283      ', NULL, -1, 0, 14544, -14544, 2708, N'tr1', NULL, N'', N'Cho vay                                                                                                                                                                                                                          ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'131       ', NULL, 3, 2544, 0, 2544, 2709, N'tr1', NULL, N'Aba', N'Phải thu của khách hàng                                                                                                                                                                                                          ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'1332      ', NULL, -1, 232, 0, 232, 2710, N'tr1', NULL, N'', N'Thuế GTGT được khấu trừ của TSCĐ                                                                                                                                                                                                 ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'136       ', NULL, -1, 12341234, 0, 12341234, 2711, N'tr1', NULL, N'', N'Phải thu nội bộ                                                                                                                                                                                                                  ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'1361      ', NULL, -1, 0, 123123, -123123, 2712, N'tr1', NULL, N'', N'Vốn kinh doanh ở các đơn vị trực thuộc                                                                                                                                                                                           ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'152       ', NULL, -1, 14544, 1585476, -1570932, 2713, N'tr1', NULL, N'', N'Nguyên liệu, vật liệu                                                                                                                                                                                                            ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'153       ', NULL, -1, 0, 14544, -14544, 2714, N'tr1', NULL, N'', N'Công cụ, dụng cụ                                                                                                                                                                                                                 ')
INSERT [dbo].[RptPhatsinhcdkt200] ([matk], [loainganhan], [machitiet], [tPSNo], [tPSCo], [tPsNotruPSco], [id], [username], [useRpt], [tenchitiet], [tentk]) VALUES (N'158       ', NULL, -1, 0, 2544, -2544, 2715, N'tr1', NULL, N'', N'Hàng hoá kho bảo thuế                                                                                                                                                                                                            ')
SET IDENTITY_INSERT [dbo].[RptPhatsinhcdkt200] OFF
SET IDENTITY_INSERT [dbo].[Rptphieuxuatkhodetail01] ON 

INSERT [dbo].[Rptphieuxuatkhodetail01] ([stt], [username], [tensanpham], [masanpham], [donvi], [sophieu], [soluongyeucau], [soluongthucte], [dongia], [thanhtien], [id]) VALUES (1, N'tr1', N'phấn', N'ádfasdf31123', N'cây', N'234', NULL, 12, 132123, 1585476, 36)
SET IDENTITY_INSERT [dbo].[Rptphieuxuatkhodetail01] OFF
SET IDENTITY_INSERT [dbo].[Rptphieuxuatkhohead] ON 

INSERT [dbo].[Rptphieuxuatkhohead] ([tencongty], [diachicongty], [masothue], [tengiamdoc], [tenketoantruong], [ngaychungtu], [nguoinhan], [nguoilapphieu], [xuattaikho], [diachibophan], [sotienbangchu], [sochungtugoc], [username], [id], [tkno], [tkco], [lydoxuat], [phieuso], [sotien]) VALUES (N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'Duyên Thái,Thường Tín,Hà nội', N'012122848', N'Mai Văn Trường', N'Trần Thị Phương Thu', CAST(N'2018-06-20 00:00:00.000' AS DateTime), N'ádfsdaf', N'Mai Văn Trường', N'Kho sH', N'ádfasdf', N'Một triệu năm trăm tám mươi lăm ngàn bốn trăm bảy mươi sáu đồng.', N'2', N'tr1', 23, N'1212      ', N'152       ', N'ádfdasf', N'234', NULL)
SET IDENTITY_INSERT [dbo].[Rptphieuxuatkhohead] OFF
SET IDENTITY_INSERT [dbo].[RPtsoQuy] ON 

INSERT [dbo].[RPtsoQuy] ([loaiquy], [tungay], [denngay], [nodauky], [codauky], [psno], [psco], [cocuoiky], [nocuoiky], [tencongty], [masothue], [diachicongty], [id], [username], [taikhoan]) VALUES (N'', CAST(N'2019-01-01 00:00:00.000' AS DateTime), CAST(N'2019-01-11 00:00:00.000' AS DateTime), 123123, 0, 0, 0, 0, 123123, N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'0106881171', N'Duyên Thái,Thường Tín,Hà nội', 1108, N'tr1', N'111       :Tiền mặt')
SET IDENTITY_INSERT [dbo].[RPtsoQuy] OFF
SET IDENTITY_INSERT [dbo].[tbl_congty] ON 

INSERT [dbo].[tbl_congty] ([id], [tengiamdoc], [diachicoty], [tencongty], [Masothue], [chedoketoanapdung], [tenketoantruong]) VALUES (1, N'Mai Văn Trường', N'Duyên Thái,Thường Tín,Hà nội', N'Công ty CP Đầu tư và dịch vụ vận tải Nam Phong', N'0106881171', NULL, N'Nguyễn Thị Hồng Nguyên')
INSERT [dbo].[tbl_congty] ([id], [tengiamdoc], [diachicoty], [tencongty], [Masothue], [chedoketoanapdung], [tenketoantruong]) VALUES (2, NULL, N'23', N'2016', N'1434', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_congty] OFF
SET IDENTITY_INSERT [dbo].[tbl_danhsachnhacungcap] ON 

INSERT [dbo].[tbl_danhsachnhacungcap] ([maNcc], [tenNcc], [sonha], [duongpho], [huyenquan], [thanhpho], [dienthoai], [id], [masothue], [sotaikhoannganhang], [tennganhang], [ghichunganhnghe], [nguoidaidien], [quocgia], [usertao], [ngaytao]) VALUES (N'1212', N'Công ty cổ phần AB', N'34', N'ádfasfd', N'ádf', N'ádf', N'431234', 1, N'2342354235', N'242352354', N'àdadsfasdf', N'ádfasdfsdaf', N'ádfasdfsadf', N'à', N'tr1', CAST(N'2017-10-06 00:00:00.000' AS DateTime))
INSERT [dbo].[tbl_danhsachnhacungcap] ([maNcc], [tenNcc], [sonha], [duongpho], [huyenquan], [thanhpho], [dienthoai], [id], [masothue], [sotaikhoannganhang], [tennganhang], [ghichunganhnghe], [nguoidaidien], [quocgia], [usertao], [ngaytao]) VALUES (N'1413', N'124sdÁDád', N'ÁDád', N'ÁDAs', N'aSDá', N'sAD', N'ádÁD', 2, N'3`14134', N'134314134', N'ádÁDAsd', N'ádÁD', N'ádÁD', N'dÁD', N'tr1', CAST(N'2017-12-01 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_danhsachnhacungcap] OFF
SET IDENTITY_INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ON 

INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751888', NULL, NULL, N'0EGDPDCK300191-0EGRPDOK500123', N'DIEU HOA', N'Vương thị tuy', N'1696636731', N'HA NOI', NULL, NULL, N'Huyện Ứng Hòa', N'8 Quảng tái Xã Trung Tú Xóm 8 thôn QuảngHuyện Ứng HòaThành phố Hà Nội', 1, 2135, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751890', NULL, NULL, N'0EGDPDCK200407-0EGRPDOK500115', N'DIEU HOA', N'Hoàng Hưởng', N'888092453', N'HA NOI', NULL, NULL, N'Quận Tây Hồ', N'7B Ngõ 146 an dương vương Phường Phú ThưQuận Tây HồThành phố Hà Nội', 1, 2136, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 82800, 0, NULL, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751892', NULL, NULL, N'08RN4NAK602501', N'TU LANH', N'Đỗ Văn Tiệp', N'1693024849', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'trong ngõ 74 Dịch Vọng Phường Dịch VọngQuận Cầu GiấyThành phố Hà Nội', 1, 2137, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751893', NULL, NULL, N'05VC3NAK601864', N'TI VI', N'Trần Văn Hoa', N'903200300', N'HA NOI', NULL, NULL, N'Quận Ba Đình', N'số 9 ngõ 612 Đê La Thành Phường Giảng VõQuận Ba ĐìnhThành phố Hà Nội', 1, 2138, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751896', NULL, NULL, N'0F754DAK600516', N'TU LANH', N'Bùi Văn Tỵ', N'985599402', N'HA NOI', NULL, NULL, N'Huyện Ba Vì', N'Số 11 UBND Xã Thụy An Xã Thụy An Thôn ÁnHuyện Ba VìThành phố Hà Nội', 1, 2139, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751897', NULL, NULL, N'05VC3NAK601870', N'TI VI', N'Nguyễn Văn Cường', N'973182301', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'Số 138 Phố Kẻ Vẽ Phường Đông Ngạc ThànhQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2140, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751898', NULL, NULL, N'05HL3NNK600748', N'TI VI', N'Hoàng Đức Bình', N'985018294', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'3 Đội 1, Ngọc Hồi Xã Ngọc Hồi Lạc Thị ThHuyện Thanh TrìThành phố Hà Nội', 1, 2141, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751899', NULL, NULL, N'0CJM14KK600625', N'LOA', N'Hoàng Đức Bình', N'985018294', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'3 Đội 1, Ngọc Hồi Xã Ngọc Hồi Lạc Thị ThHuyện Thanh TrìThành phố Hà Nội', 1, 2142, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751900', NULL, NULL, N'08LT5NAK500063', N'MAY GIAT', N'Đỗ Thị Sáu', N'919891003', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'Số không nhà Canh Nậu Xã Canh Nậu Thôn 9Huyện Thạch ThấtThành phố Hà Nội', 1, 2143, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 144000, 0, 0, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751902', NULL, NULL, N'0SUJ4ABK600047', N'TU LANH', N'Nguyễn Ngọc Hà', N'984214999', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'Số nhà 199 Tựu Liệt Xã Tam Hiệp Tựu liệtHuyện Thanh TrìThành phố Hà Nội', 1, 2144, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751903', NULL, NULL, N'0D5U4DAK100293', N'TU LANH', N'Nguyễn Mỹ Dũng/Samsung Display Viet', N'967555591', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'Số 93 Hoàng Quốc Việt Phường Nghĩa Đô ThQuận Cầu GiấyThành phố Hà Nội', 1, 2145, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751904', NULL, NULL, N'0EZ45DBK600823', N'MAY GIAT', N'Cấn Hà Khánh', N'987666428', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'605 CT2 Mỹ Đình Plaza 2 số 2 Nguyễn HoànQuận Nam Từ LiêmThành phố Hà Nội', 1, 2146, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751906', NULL, NULL, N'0P8NHTPK600004', N'MAN HINH', N'Ngô Đăng Nam', N'1683311240', N'HA NOI', NULL, NULL, N'Huyện Đông Anh', N'45 Tổ 4 Thị trấn Đông Anh Thành phố Hà NHuyện Đông AnhThành phố Hà Nội', 1, 2147, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751908', NULL, NULL, N'05HK3NDK600504', N'TI VI', N'Vũ xuân thắng', N'948385691', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'Số nhà 196 Đường Hồ Tùng Mậu Phường MaiQuận Cầu GiấyThành phố Hà Nội', 1, 2148, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751909', NULL, NULL, N'0EYZ5DBK500306', N'MAY GIAT', N'Nguyễn văn An', N'985792507', N'HA NOI', NULL, NULL, N'Huyện Ứng Hòa', N'0 Đống vũ Xã Trường Thịnh Đống vũ ThànhHuyện Ứng HòaThành phố Hà Nội', 1, 2149, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 144000, 0, 0, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00751910', NULL, NULL, N'00305NAK600009', N'MAY GIAT', N'Nguyễn Ngọc Dũng', N'971795694', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'00 Xóm Nhòn Xã Tiến Xuân Xóm Nhòn ThànhHuyện Thạch ThấtThành phố Hà Nội', 1, 2150, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 144000, 0, 0, CAST(N'2018-07-12 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755296', NULL, NULL, N'0EGUPDCK600073-0EGVPDOK600070', N'DIEU HOA', N'Anh Toán', N'1698899970', N'HA NOI', NULL, NULL, N'Huyện Mỹ Đức', N'. Xóm 12 Xã Hương Sơn xóm 12, Đục Khê Th-Huyện Mỹ Đức-Thành phố Hà Nội', 1, 2151, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755297', NULL, NULL, N'0FM4PDCK600088-0FMQPDOK600102', N'DIEU HOA', N'Ngô Thị Chuyển', N'965902883', N'HA NOI', NULL, NULL, N'Huyện Thường Tín', N'37 Tía Dấp Xã Tô Hiệu An Duyên Thành phố-Huyện Thường Tín-Thành phố Hà Nội', 1, 2152, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 82800, 1, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755298', NULL, NULL, N'0FKWPDBK600084-0FKDPDPK600065', N'DIEU HOA', N'Hoang xuan giang', N'1638263063', N'HA NOI', NULL, NULL, N'Huyện Đan Phượng', N'1 Tam đạc 2 Xã Thọ An Cụm 7 Thành phố Hà-Huyện Đan Phượng-Thành phố Hà Nội', 1, 2153, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755299', NULL, NULL, N'0FJ6PDCK600123-0FJ7PDOK600112', N'DIEU HOA', N'Lê thị luyến', N'975450685', N'HA NOI', NULL, NULL, N'Huyện Quốc Oai', N'1 Đồng lư Xã Đồng Quang Đồng lư Thành ph-Huyện Quốc Oai-Thành phố Hà Nội', 1, 2154, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755300', NULL, NULL, N'0FJ6PDCK600119-0FJ7PDOK600109 - 0FJ6PDCK600114 - 0FJ7PDOK600117', N'2 BỘ ĐH', N'Le dung sy', N'983989734', N'HA NOI', NULL, NULL, N'Huyện Đông Anh', N'Xom 3 Co dien Xã Hải Bối Xom 3 Thành phố-Huyện Đông Anh-Thành phố Hà Nội', 2, 2155, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 82800, 1, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755301', NULL, NULL, N'0FJ6PDCK600121-0FJ7PDOK600093', N'DIEU HOA', N'Đỗ Văn Trường', N'917271092', N'HA NOI', NULL, NULL, N'Huyện Chương Mỹ', N'1 Xóm Cả Xã Trung Hòa Thôn Chi Nê Thành-Huyện Chương Mỹ-Thành phố Hà Nội', 1, 2156, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755302', NULL, NULL, N'0FM4PDCK600136-0FMQPDOK600099', N'DIEU HOA', N'Nguyễn Bá Thưởng', N'976665486', N'HA NOI', NULL, NULL, N'Huyện Chương Mỹ', N'1 Xóm Và Xã Tốt Động Xóm và Thành phố Hà-Huyện Chương Mỹ-Thành phố Hà Nội', 1, 2157, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755303', NULL, NULL, N'0FJ6PDCK600120-0FJ7PDOK600091', N'DIEU HOA', N'Hoàng văn hiền', N'886353568', N'HA NOI', NULL, NULL, N'Huyện Đông Anh', N'26 đường 16 Xã Xuân Nộn Thôn đường nhạn-Huyện Đông Anh-Thành phố Hà Nội', 1, 2158, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 82800, 1, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755306', NULL, NULL, N'0FM4PDCK600090-0FMQPDOK600087', N'DIEU HOA', N'Đôn Văn Tiệp', N'978801694', N'HA NOI', NULL, NULL, N'Huyện Quốc Oai', N'24 Đồng Hương Thị trấn Quốc Oai Số 24, Đ-Huyện Quốc Oai-Thành phố Hà Nội', 1, 2159, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755309', NULL, NULL, N'07Z68NDK600315', N'MAY HUT BUI', N'Đoàn Thị Thu', N'984303626', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'C2A- Ecohome 2 Tân Xuân Phường Đông Ngạc-Quận Bắc Từ Liêm-Thành phố Hà Nội', 1, 2160, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755311', NULL, NULL, N'0DT94DAK600081', N'TU LANH', N'Nguyen Quang Tien', N'972309245', N'HA NOI', NULL, NULL, N'Huyện Đông Anh', N'17 Đường Vạn Lộc Xã Xuân Canh Thôn Vạn L-Huyện Đông Anh-Thành phố Hà Nội', 1, 2161, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755313', NULL, NULL, N'0D5U4DAK100314', N'TU LANH', N'Mai Đức Hải', N'976229910', N'HA NOI', NULL, NULL, N'Huyện Thanh Oai', N'1720, tòa HH03.C Chung cư Thanh Hà Cienc-Huyện Thanh Oai-Thành phố Hà Nội', 1, 2162, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755314', NULL, NULL, N'05C03NNK600411', N'TI VI', N'Luong Thi Hieu', N'903494383', N'HA NOI', NULL, NULL, N'Huyện Thường Tín', N'4 Liễu Nội Xã Khánh Hà thôn Liễu Nội Thà-Huyện Thường Tín-Thành phố Hà Nội', 1, 2163, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755315', NULL, NULL, N'0ARY7WEK600217', N'LO VI SONG', N'Nguyễn Thị Mai Anh', N'969252636', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'19 Trần Quang Diệu Phường Ô Chợ Dừa Thàn-Quận Đống Đa-Thành phố Hà Nội', 1, 2164, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755316', NULL, NULL, N'ZZMRH4ZK501615', N'MAN HINH', N'Nguyễn Anh Tuấn', N'1666592058', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'Số 18 Ngách 151a/21 ngõ 165 Thái Hà Phườ-Quận Đống Đa-Thành phố Hà Nội', 1, 2165, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755317', NULL, NULL, N'00124NAK600208', N'TU LANH', N'La Văn Hải', N'977058747', N'HA NOI', NULL, NULL, N'Huyện Sóc Sơn', N'1 Đội 3- Thôn Cẩm Hà-Xã Tân Hưng Xã Tân-Huyện Sóc Sơn-Thành phố Hà Nội', 1, 2166, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755318', NULL, NULL, N'0FUM4DAK601637', N'TU LANH', N'Chu Thị Minh Phương', N'973975394', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'4 Xóm 4, Vĩnh Lộc Xã Phùng Xá Vĩnh Lộc T-Huyện Thạch Thất-Thành phố Hà Nội', 1, 2167, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755320', NULL, NULL, N'000R4NAK600176', N'TU LANH', N'phi thi hanh', N'974149897', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'thon 2 huong ngai Xã Hương Ngải Thành ph-Huyện Thạch Thất-Thành phố Hà Nội', 1, 2168, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755321', NULL, NULL, N'05HL3NNK600486', N'TI VI', N'Vũ Tuyên Hoàng', N'1677743599', N'HA NOI', NULL, NULL, N'Huyện Mê Linh', N'1 Cổng làng thôn Tiên Đài Xã Vạn Yên Cổn-Huyện Mê Linh-Thành phố Hà Nội', 1, 2169, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755322', NULL, NULL, N'0CJM14KK601002', N'LOA', N'Vũ Tuyên Hoàng', N'1677743599', N'HA NOI', NULL, NULL, N'Huyện Mê Linh', N'1 Cổng làng thôn Tiên Đài Xã Vạn Yên Cổn-Huyện Mê Linh-Thành phố Hà Nội', 1, 2170, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 40000, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00755325', NULL, NULL, N'J7G57WFK600222', N'LO VI SONG', N'Vũ Mạnh Cường', N'967296996', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'24 ngách 114 Ngõ Thổ Quan, Khâm Thiên Ph-Quận Đống Đa-Thành phố Hà Nội', 1, 2171, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756005', NULL, NULL, N'0FKWPDBK600087-0FKDPDPK600064', N'DIEU HOA', N'Ngùng Văn Trãi', N'1649711988', N'HA NOI', NULL, NULL, N'Huyện Ứng Hòa', N'0 0 Xã Lưu Hoàng thôn Nội Lưu Thành phố-Huyện Ứng Hòa-Thành phố Hà Nội', 1, 2172, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756009', NULL, NULL, N'0EGDPDCK600546-0EGRPDOK300202', N'DIEU HOA', N'Phung Thi Le', N'982013501', N'HA NOI', NULL, NULL, N'BA VI', N'XÓM TRẠI ĐỒNG BẢNG , ĐỒNG THÁI-BA VÌ , HÀ NỘI', 1, 2173, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756081', NULL, NULL, N'0DT94DAK600086', N'TU LANH', N'Hoàng thị thúy', N'913852459', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'Số 7 Ngõ 225 quan hoa Phường Quan Hoa Th-Quận Cầu Giấy-Thành phố Hà Nội', 1, 2174, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756082', NULL, NULL, N'0F754DAK600603', N'TU LANH', N'Nguyễn Thị Thương', N'936036316', N'HA NOI', NULL, NULL, N'Huyện Ứng Hòa', N'6 Đội 4 Xã Phù Lưu Xóm 6 -Đội 4 - Thôn P-Huyện Ứng Hòa-Thành phố Hà Nội', 1, 2175, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756085', NULL, NULL, N'0F764DAK600281', N'TU LANH', N'Đỗ Xuân Quang', N'986086699', N'HA NOI', NULL, NULL, N'Quận Hai Bà Trưng', N'1112b 458 Minh khai Phường Minh Khai Tim-Quận Hai Bà Trưng-Thành phố Hà Nội', 1, 2176, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756087', NULL, NULL, N'0D5U4DAJC00082', N'TU LANH', N'nguyễn thành long', N'911515791', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'phòng 415 Nguyễn trãi Phường Thanh Xuân-Quận Thanh Xuân-Thành phố Hà Nội', 1, 2177, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756088', NULL, NULL, N'0FUM4DAK601692', N'TU LANH', N'Nguyễn ngọc thành', N'983357162', N'HA NOI', NULL, NULL, N'Huyện Mê Linh', N'0 Kim hoa Xã Kim Hoa Xóm đông,phù trì-Huyện Mê Linh-Thành phố Hà Nội', 1, 2178, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756089', NULL, NULL, N'0FUK4DBK600281', N'TU LANH', N'Dương Đức Hải', N'1674521080', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'07 Yên viên Xã Yên Viên Yên viên Thành p-Huyện Gia Lâm-Thành phố Hà Nội', 1, 2179, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756090', NULL, NULL, N'0FUK4DBK600315', N'TU LANH', N'Nguyễn Thị Hoa', N'981228392', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'39C Đại Từ Phường Đại Kim Phố Đại Từ, ng-Quận Hoàng Mai-Thành phố Hà Nội', 1, 2180, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 1, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756091', NULL, NULL, N'0EZ45DBK600825', N'MAY GIAT', N'Luu Thi Hue', N'1664709487', N'HA NOI', NULL, NULL, N'SOC SON', N'THON LUONG DINH. XA BAC SON-SOC SON. HA NOI', 1, 2181, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 144000, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756093', NULL, NULL, N'0FUK4DBK600303', N'TU LANH', N'Nguyen Van Thuc', N'949688115', N'HA NOI', NULL, NULL, N'SOC SON', N'ĐỘI 2,LƯƠNG PHÚC,VIỆT LONG,-SÓC SƠN,HÀ NỘI', 1, 2182, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00756094', NULL, NULL, N'04MP3NAK700097', N'TI VI', N'Tran Thi Hong', N'975088299', N'HA NOI', NULL, NULL, N'THANH XUAN', N'SN 15 - NGO 342/41 KHUONG DINH-HA DINH - THANH XUAN - HA NOI', 1, 2183, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-13 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758151', NULL, NULL, N'0FM4PDCK600130-0FMQPDOK600091', N'DIEU HOA', N'Nguyễn Văn Hưng', N'988673913', N'HA NOI', NULL, NULL, N'Huyện Quốc Oai', N'9 Đường phụ nữ tự quản Xã Phượng Cách XóHuyện Quốc OaiThành phố Hà Nội', 1, 2184, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758152', NULL, NULL, N'0FK7PDCK600142-0FKPPDOK600109', N'DIEU HOA', N'Nguyễn Công Tùng', N'965603796', N'HA NOI', NULL, NULL, N'Huyện Mỹ Đức', N'001 Thôn 8, Phù Lưu Tế, Mỹ Đức, Hà nội XHuyện Mỹ ĐứcThành phố Hà Nội', 1, 2185, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758154', NULL, NULL, N'0FJ6PDCK600098-0FJ7PDOK600121', N'DIEU HOA', N'Đào Văn Thanh/Samsung Electronics', N'943295975', N'HA NOI', NULL, NULL, N'Huyện Đông Anh', N'00 Nhà ông Đào Xuân Loát - ngõ Đình - thHuyện Đông AnhThành phố Hà Nội', 1, 2186, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 82800, 1, NULL, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758156', NULL, NULL, N'0EGDPDCK600537-0EGRPDOK600489', N'DIEU HOA', N'Trần Văn Triển', N'961771615', N'HA NOI', NULL, NULL, N'Huyện Đông Anh', N'Xom tro bac chanh Thon dai do Xã Võng LaHuyện Đông AnhThành phố Hà Nội', 1, 2187, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 82800, 1, NULL, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758158', NULL, NULL, N'0EGDPDCK600511-0EGRPDOK300174', N'DIEU HOA', N'Ngô Đức Dũng', N'1639967077', N'HA NOI', NULL, NULL, N'Huyện Đan Phượng', N'52 Đường Đoàn Kết Xã Đan Phượng Làng ĐoàHuyện Đan PhượngThành phố Hà Nội', 1, 2188, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758159', NULL, NULL, N'0FK7PDCK600035-0FKPPDOK600079', N'DIEU HOA', N'Dương Quốc Thành', N'983832495', N'HA NOI', NULL, NULL, N'Thị xã Sơn Tây', N'5/238 Phố Lê Lợi Phường Lê Lợi Thành phốThị xã Sơn TâyThành phố Hà Nội', 1, 2189, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758160', NULL, NULL, N'0FJ6PDCK600129-0FJ7PDOK600114', N'DIEU HOA', N'Hà Duy Nhất', N'1635404125', N'HA NOI', NULL, NULL, N'Huyện Đông Anh', N'968 Sáp mai Xã Võng La Thôn sáp mai ThànHuyện Đông AnhThành phố Hà Nội', 1, 2190, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 82800, 1, NULL, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758161', NULL, NULL, N'0FK7PDCK600123-0FKPPDOK600137 - 0FK7PDCK600040 - 0FKPPDOK600061', N'2 BỘ DH', N'Nguyễn Dương Dũng', N'979144200', N'HA NOI', NULL, NULL, N'Huyện Mê Linh', N'Nhà ông Võ Ngọc Vẻ, bà Lương Thị HHuyện Mê LinhThành phố Hà Nội', 2, 2191, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758163', NULL, NULL, N'0EGDPDCK600514-0EGRPDOK300170', N'DIEU HOA', N'Nông Thị Huyền', N'975237763', N'HA NOI', NULL, NULL, N'Huyện Ứng Hòa', N'1 Ngõ 12 Xã Đông Lỗ Đào Xá Thành phố HàHuyện Ứng HòaThành phố Hà Nội', 1, 2192, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758164', NULL, NULL, N'0FK7PDCK600054-0FKPPDOK600009 - 0FK7PDCK600071 - 0FKPPDOK600136', N'2 BỘ DH', N'nguyễn thị huyền', N'1696066808', N'HA NOI', NULL, NULL, N'Huyện Ba Vì', N'12 xóm mỹ lộc Xã Tản Lĩnh Thành phố Hà NHuyện Ba VìThành phố Hà Nội', 2, 2193, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758165', NULL, NULL, N'0F754DAK600697', N'TU LANH', N'Trịnh Phương', N'1663061897', N'HA NOI', NULL, NULL, N'Huyện Đông Anh', N'0000 0000 Xã Võng La Đại Độ Thành phố HàHuyện Đông AnhThành phố Hà Nội', 1, 2194, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758166', NULL, NULL, N'0F754DAK600719', N'TU LANH', N'Nguyễn Văn Huấn', N'913966438', N'HA NOI', NULL, NULL, N'Huyện Thường Tín', N'26 Vạn Lợi Xã Vạn Điểm Thành phố Hà NộiHuyện Thường TínThành phố Hà Nội', 1, 2195, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758167', NULL, NULL, N'ZZMRH4ZK501186', N'MAN HINH', N'Nguyễn Trí Thực', N'988456309', N'HA NOI', NULL, NULL, N'Huyện Hoài Đức', N'101 Yên Sở Xã Yên Sở Yên sở Thành phố HàHuyện Hoài ĐứcThành phố Hà Nội', 1, 2196, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758170', NULL, NULL, N'0CCL5DBK500024', N'MAY GIAT', N'Chị Vân', N'983932537', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'Phòng B22-06 Chung cư Anland - khu đô thQuận Hà ĐôngThành phố Hà Nội', 1, 2197, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758171', NULL, NULL, N'0FUM4DAK601443', N'TU LANH', N'Chị Vân', N'983932537', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'Phòng B22-06 Chung cư Anland - khu đô thQuận Hà ĐôngThành phố Hà Nội', 1, 2198, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758172', NULL, NULL, N'H7WTK100129J60', N'LO VI SONG', N'Nguyễn Văn Thắng', N'912832403', N'HA NOI', NULL, NULL, N'Thị xã Sơn Tây', N'18B/1 Tổ 4 Phường Xuân Khanh Phường XuânThị xã Sơn TâyThành phố Hà Nội', 1, 2199, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 40000, 0, 0, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758174', NULL, NULL, N'0DTF4DBK600072', N'TU LANH', N'Bùi khải định', N'979338216', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'60 Ngõ 226  Hà Huy Tập Thị trấn Yên ViênHuyện Gia LâmThành phố Hà Nội', 1, 2200, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00758175', NULL, NULL, N'06073NFK600545', N'TI VI', N'Chu Thị Hoa', N'982084224', N'HA NOI', NULL, NULL, N'Huyện Hoài Đức', N'1 Nhà Văn hóa Xã Kim Chung Nhà văn hóa tHuyện Hoài ĐứcThành phố Hà Nội', 1, 2201, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759105', NULL, NULL, N'0FK7PDCK600005-0FKPPDOK600076', N'DIEU HOA', N'Chị Dương', N'1666758289', N'HA NOI', NULL, NULL, N'Quận Hoàn Kiếm', N'Số 19 Hàng Thùng Phường Lý Thái Tổ HàngQuận Hoàn KiếmThành phố Hà Nội', 1, 2202, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 82800, 0, NULL, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759106', NULL, NULL, N'0FM4PDCK600107-0FMQPDOK600100', N'DIEU HOA', N'nguyen huu nam', N'979459348', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'0 khong Xã Dương Hà thon thuong Thành phHuyện Gia LâmThành phố Hà Nội', 1, 2203, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 82800, 1, NULL, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759107', NULL, NULL, N'0FJ6PDCK600090-0FJ7PDOK600113', N'DIEU HOA', N'Nguyễn Mạnh Quang', N'1636399178', N'HA NOI', NULL, NULL, N'Huyện Mê Linh', N'0 Xóm 4 Xã Tráng Việt Đông Cao Thành phốHuyện Mê LinhThành phố Hà Nội', 1, 2204, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759163', NULL, NULL, N'0FUK4DBK600295', N'TU LANH', N'Le Van Thach', N'966320638', N'HA NOI', NULL, NULL, N'Huyện Đông Anh', N'11 Nghách 10, Ngõ Đình 7 Xã Nam Hồng ThôHuyện Đông AnhThành phố Hà Nội', 1, 2205, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-07-14 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759354', NULL, NULL, N'0FK7PDCK600133-0FKPPDOK600013', N'DIEU HOA', N'Nguyễn Đức Sang', N'1674700931', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'11 Ngõ 659 Thị trấn Văn Điển Đường NgọcHuyện Thanh TrìThành phố Hà Nội', 1, 2206, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 82800, 0, NULL, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759359', NULL, NULL, N'0FK7PDCK600011-0FKPPDOK600005', N'DIEU HOA', N'Chu Minh Thinh', N'981378097', N'HA NOI', NULL, NULL, N'Thị xã Sơn Tây', N'123 Đền Và Phường Trung Hưng Tổ 8-Vân GiThị xã Sơn TâyThành phố Hà Nội', 1, 2207, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759364', NULL, NULL, N'08LX5NAK500307', N'MAY GIAT', N'Hoàng Văn Niên', N'973863798', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'0 Trường sỹ quan chính trị Xã Thạch HoàHuyện Thạch ThấtThành phố Hà Nội', 1, 2208, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 144000, 0, 0, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759365', NULL, NULL, N'J7G57WFK600257', N'LO VI SONG', N'Hoàng Văn Niên', N'973863798', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'0 Trường sỹ quan chính trị Xã Thạch HoàHuyện Thạch ThấtThành phố Hà Nội', 1, 2209, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 40000, 0, 0, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759366', NULL, NULL, N'00124NAK600255', N'TU LANH', N'Hoàng Văn Niên', N'973863798', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'0 Trường sỹ quan chính trị Xã Thạch HoàHuyện Thạch ThấtThành phố Hà Nội', 1, 2210, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759368', NULL, NULL, N'05VC3NHK700062', N'TI VI', N'Phùng Đức Toàn', N'1666313066', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'09 Xuân Nhang2 Xuân Đỉnh Bắc Từ Liêm HNQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2211, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759369', NULL, NULL, N'000R4NAK600173', N'TU LANH', N'Nguyễn Ngọc Anh', N'977312446', N'HA NOI', NULL, NULL, N'Huyện Hoài Đức', N'5 Xóm 2 Xã Đông La Đông Lao Thành phố HàHuyện Hoài ĐứcThành phố Hà Nội', 1, 2212, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759370', NULL, NULL, N'0DTF4DBK600083', N'TU LANH', N'Tạ Văn Nhỏ', N'1644089840', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'324 Nguyễn Trãi Phường Trung Văn Khu tậpQuận Nam Từ LiêmThành phố Hà Nội', 1, 2213, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759372', NULL, NULL, N'0BPR5DBK500644', N'MAY GIAT', N'Nguyễn Văn Thịnh', N'965318451', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'lô 36 liền kề 9. Khu tổng cục 5 Bộ côngHuyện Thanh TrìThành phố Hà Nội', 1, 2214, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759373', NULL, NULL, N'0B4L7WAJB00575', N'LO VI SONG', N'Nguyễn Bích Vân', N'936543883', N'HA NOI', NULL, NULL, N'Quận Hai Bà Trưng', N'Cầu thang 2 nhà H4 tập thể Nguyễn Công TQuận Hai Bà TrưngThành phố Hà Nội', 1, 2215, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759374', NULL, NULL, N'00184NAK300993', N'TU LANH', N'Nguyễn Khắc Trường', N'978795982', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'1 Thôn Thái Hòa Xã Bình Phú Sau ngân hànHuyện Thạch ThấtThành phố Hà Nội', 1, 2216, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759376', NULL, NULL, N'0DTF4DBK600082', N'TU LANH', N'Phạm Thanh Chương', N'919836949', N'HA NOI', NULL, NULL, N'Huyện Thanh Oai', N'1 Văn khê Xã Tam Hưng Văn khê Thành phốHuyện Thanh OaiThành phố Hà Nội', 1, 2217, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759378', NULL, NULL, N'00124NAK600132', N'TU LANH', N'Đặng Thị Nguyệt', N'988697917', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'Số 4 Ngõ 1 Hà Trì Phường Hà Cầu Số 4 NgõQuận Hà ĐôngThành phố Hà Nội', 1, 2218, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759379', NULL, NULL, N'08RN4NAK602824', N'TU LANH', N'Nguyễn Bảo Châu', N'1633055392', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'29 Ngách 351/85 Tổ dân phố Đại Đồng PhườQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2219, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759542', NULL, NULL, N'0A047WFK300127', N'LO VI SONG', N'Phạm Đức Hóa', N'989339627', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'CT1A - 1502 Chung cư 789 Xuân Đỉnh PhườnQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2220, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759545', NULL, NULL, N'0EZ05DBK600472', N'MAY GIAT', N'Đặng Văn Chủ', N'1649801583', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'14 Ngõ 230/55/3/2 Phường Mễ Trì Xóm 3, TQuận Nam Từ LiêmThành phố Hà Nội', 1, 2221, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759546', NULL, NULL, N'05SF3NAK609683', N'TI VI', N'Nguyên Thị My', N'989038020', N'HA NOI', NULL, NULL, N'Huyện Chương Mỹ', N'Thôn Tiên Phối Thôn Tiên Phối Xã Thanh BHuyện Chương MỹThành phố Hà Nội', 1, 2222, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759952', NULL, NULL, N'0EGDPDCK300122-0EGRPDOK600483', N'DIEU HOA', N'Nguyễn Đình Thắng', N'983536996', N'HA NOI', NULL, NULL, N'Huyện Quốc Oai', N'Xóm Chân Sông Thôn Phúc Đức Xã Sài Sơn XHuyện Quốc OaiThành phố Hà Nội', 1, 2223, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759959', NULL, NULL, N'0FUK4DBK600241', N'TU LANH', N'Nguyễn Văn Long', N'982249655', N'HA NOI', NULL, NULL, N'Huyện Chương Mỹ', N'Đội 2 Đội 2 thôn sơn đồng- xã tiên phươnHuyện Chương MỹThành phố Hà Nội', 1, 2224, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759963', NULL, NULL, N'05HK3NDK502508', N'TI VI', N'Nguyễn Xuân Xuyên', N'977944481', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'7 Ngõ 237 Thị trấn Trâu Quỳ Ngô Xuân QuảHuyện Gia LâmThành phố Hà Nội', 1, 2225, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759964', NULL, NULL, N'00124NAK600021', N'TU LANH', N'Vũ đức trọng', N'961399169', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'Căn hộ 1414 Ngọc thụy Phường Ngọc Thụy KQuận Long BiênThành phố Hà Nội', 1, 2226, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759968', NULL, NULL, N'0EP64ABK600003', N'TU LANH', N'Nguyễn Đức Thi', N'983404243', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'Chung cư 789 Xuân Đỉnh Phường Xuân ĐỉnhQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2227, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759969', NULL, NULL, N'04MP3NAK700098', N'TI VI', N'Nguyễn Thị Vân', N'1646317607', N'HA NOI', NULL, NULL, N'Huyện Ứng Hòa', N'Số nhà 105 Ngõ 130 Thị trấn Vân Đình PhốHuyện Ứng HòaThành phố Hà Nội', 1, 2228, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759970', NULL, NULL, N'0DY55DBK600460', N'MAY GIAT', N'Nguyễn Thế Anh', N'973729090', N'HA NOI', NULL, NULL, N'Quận Ba Đình', N'SN 83 Nguyễn Thái Học Phường Điện Biên TQuận Ba ĐìnhThành phố Hà Nội', 1, 2229, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759973', NULL, NULL, N'0FUK4DBK600318', N'TU LANH', N'Nguyễn Đức Mạnh', N'964668999', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'72 Nguyễn trãi Phường Khương Đình NguyễnQuận Thanh XuânThành phố Hà Nội', 1, 2230, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759974', NULL, NULL, N'ZZFGH4ZK600185', N'MAN HINH', N'Tran Trung Thanh', N'904043681', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'161 Yên Hòa Phường Yên Hoà Thành phố HàQuận Cầu GiấyThành phố Hà Nội', 1, 2231, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759978', NULL, NULL, N'0FUK4DBK600313', N'TU LANH', N'Cao Khánh Luân', N'904936366', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'05A Dãy T Khu B Tập Thể Đại Học Mỏ Địa CQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2232, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759980', NULL, NULL, N'067P3NDK701274', N'TI VI', N'Nguyễn Minh Thương', N'945328193', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'N/A Phố Sủi Xã Phú Thị xóm Trên, phố SủiHuyện Gia LâmThành phố Hà Nội', 1, 2233, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
GO
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759982', NULL, NULL, N'0D5U4DAJC00097', N'TU LANH', N'Phạm Thị Đức', N'1296345046', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'Số 15 ngách 56/34 Lê Văn Hiến Phường ĐứcQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2234, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00759983', NULL, NULL, N'05HL3NNK601161', N'TI VI', N'Bùi Xuân Phương', N'978257260', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'0983890988 Thôn Cam, Xã Cổ Bi, Huyện GiaHuyện Gia LâmThành phố Hà Nội', 1, 2235, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00760735', NULL, NULL, N'0F764DAK600252', N'TU LANH', N'Nguyen thi thu hien', N'987838843', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'Phòng 311 tầng 3 ngõ 14 Nguyễn khuyến Ph-Quận Đống Đa-Thành phố Hà Nội', 1, 2236, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00760738', NULL, NULL, N'05C13NEK700005', N'TI VI', N'Đỗ Văn Tứ', N'983408904', N'HA NOI', NULL, NULL, N'Huyện Ứng Hòa', N'01 Ba Thá Xã Viên An Phù Yên Thành phố H-Huyện Ứng Hòa-Thành phố Hà Nội', 1, 2237, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00760740', NULL, NULL, N'0F764DAK600288', N'TU LANH', N'Doan Thi Huynh', N'943909495', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'510,21B6 Greenstar 234 Pham Van Dong Phư-Quận Bắc Từ Liêm-Thành phố Hà Nội', 1, 2238, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-17 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761905', NULL, NULL, N'0EGDPDCK300042-0EGRPDOK600534', N'DIEU HOA', N'Nguyễn Thị Đông', N'1689057029', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'00 Thôn Hà Tân Thị trấn Liên Quan Thôn HHuyện Thạch ThấtThành phố Hà Nội', 1, 2239, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761920', NULL, NULL, N'07RP4NAK601524', N'TU LANH', N'Lê Thị Trang', N'974327562', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'4 Ngo 308 Phường Phương Liên Phố chợ KhâQuận Đống ĐaThành phố Hà Nội', 1, 2240, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761921', NULL, NULL, N'0F754DAK600659', N'TU LANH', N'Le Xuan Vui', N'987429863', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'ngách 9 ngõ 63 Phú Đô Phú Đô Phường PhúQuận Nam Từ LiêmThành phố Hà Nội', 1, 2241, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761922', NULL, NULL, N'0F754DAK600634', N'TU LANH', N'Anh dũng', N'974694626', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'6 Ngõ 31 Nguyễn Khả Trạc Phường Mai DịchQuận Cầu GiấyThành phố Hà Nội', 1, 2242, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761923', NULL, NULL, N'0F754DAK600654', N'TU LANH', N'Xuân giang', N'966365138', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'11 Phạm hùng Phường Mỹ Đình 2 Thành phốQuận Nam Từ LiêmThành phố Hà Nội', 1, 2243, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761924', NULL, NULL, N'0F754DAK600650', N'TU LANH', N'Hưng Phạm', N'988974606', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'63 Ngõ 17 Phú Đô Phường Phú Đô Thành phốQuận Nam Từ LiêmThành phố Hà Nội', 1, 2244, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761925', NULL, NULL, N'0FUM4DAK601501', N'TU LANH', N'Do Thi Lien', N'1682062695', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'6 Hữu Trung Xã Hữu Hoà Ngõ 3 Thành phố HHuyện Thanh TrìThành phố Hà Nội', 1, 2245, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761926', NULL, NULL, N'0F754DAK600657 - 0F754DAK600640', N'2 TU LANH', N'Băng Lê', N'1672344304', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'59/36 Dương khuê Phường Mai Dịch Thành pQuận Cầu GiấyThành phố Hà Nội', 2, 2246, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761927', NULL, NULL, N'08UD43BK600057', N'TU LANH', N'Lê Văn Dư', N'963302111', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'26 ngo 279/65 to 7 Phường Phúc Lợi phucQuận Long BiênThành phố Hà Nội', 1, 2247, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761929', NULL, NULL, N'0FUM4DAK601505', N'TU LANH', N'Vu Van Khuong', N'941151098', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'.Chợ Cóp Thôn Vàng Xã Cổ Bi Chợ Cóp-ThônHuyện Gia LâmThành phố Hà Nội', 1, 2248, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761930', NULL, NULL, N'05HL3NNK700184', N'TI VI', N'Lê Thị Mơ', N'975618455', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'6 Ngõ 16, Đường C Thị trấn Trâu Quỳ tổ dHuyện Gia LâmThành phố Hà Nội', 1, 2249, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761934', NULL, NULL, N'07WV8NCK600144', N'MAY HUT BUI', N'Phạm Đức Hóa', N'989339627', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'CT1A - 1502 Chung cư 789 Xuân Đỉnh PhườnQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2250, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761937', NULL, NULL, N'0EZ15DBK200735', N'MAY GIAT', N'Hồng Nhung', N'987456180', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'Nha A902 chung cu T608 Tong cuc 5 Bo ConQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2251, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00761938', NULL, NULL, N'0F754DAK600626', N'TU LANH', N'Nguyễn Quang Đăng', N'1656123168', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'50 Hà Huy Tập Thị trấn Yên Viên Ngách 62Huyện Gia LâmThành phố Hà Nội', 1, 2252, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00762509', NULL, NULL, N'0F754DAK600662', N'TU LANH', N'Nguyễn Thị Duyên', N'1636855534', N'HA NOI', NULL, NULL, N'Huyện Phú Xuyên', N'235 Vân từ Xã Vân Từ Thôn chính Thành phHuyện Phú XuyênThành phố Hà Nội', 1, 2253, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00762510', NULL, NULL, N'0FUM4DAK601498', N'TU LANH', N'Anh vinh', N'979187670', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'57 Nguyễn khánh toàn Phường Dịch Vọng ThQuận Cầu GiấyThành phố Hà Nội', 1, 2254, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00762511', NULL, NULL, N'0FUM4DAK601512', N'TU LANH', N'Văn dũng', N'971607726', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'10 Tôn thất thuyết Phường Mỹ Đình 1 ThànQuận Nam Từ LiêmThành phố Hà Nội', 1, 2255, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00762512', NULL, NULL, N'0FUM4DAK601520', N'TU LANH', N'Ngô văn hiển', N'962358049', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'68 Nguyễn cơ thạch Phường Cầu Diễn ThànhQuận Nam Từ LiêmThành phố Hà Nội', 1, 2256, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00762514', NULL, NULL, N'0F754DAK600656', N'TU LANH', N'Phan Kieu Duy Khanh', N'917764788', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'94 Phan Trọng Tuệ Xã Tân Triều NC2A - KhHuyện Thanh TrìThành phố Hà Nội', 1, 2257, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00762515', NULL, NULL, N'05HL3NNK700535', N'TI VI', N'Nguyễn Thị Hằng', N'983358356', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'Phòng 1108 nhà A1D1 Đường 5 Xã Đặng Xá KHuyện Gia LâmThành phố Hà Nội', 1, 2258, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00762516', NULL, NULL, N'00085NAK600174', N'MAY GIAT', N'Nguyễn Thị Hằng', N'983358356', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'Phòng 1108 nhà A1D1 Đường 5 Xã Đặng Xá KHuyện Gia LâmThành phố Hà Nội', 1, 2259, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00762517', NULL, NULL, N'0D4C4DAK600693', N'TU LANH', N'Nguyễn Thị Hằng', N'983358356', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'Phòng 1108 nhà A1D1 Đường 5 Xã Đặng Xá KHuyện Gia LâmThành phố Hà Nội', 1, 2260, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-18 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763547', NULL, NULL, N'0CJM14KK700734', N'LOA', N'0.134', N'Phạm Hồng Quang', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'P207 C5 Nguyễn cơ thạch Phường Cầu DiễnQuận Nam Từ LiêmHA NOI', 1, 2261, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763552', NULL, NULL, N'0F754DAK600522', N'TU LANH', N'0.785', N'Nguyen Ngoc Manh', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'17 Ngo 103, Yen Noi 3 Yen Noi 3, PhuongQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2262, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763555', NULL, NULL, N'07RP4NAK601533', N'TU LANH', N'0.645', N'Nguyễn Thế Anh', N'HA NOI', NULL, NULL, N'Quận Ba Đình', N'SN 83 Nguyễn Thái Học Phường Điện Biên TQuận Ba ĐìnhThành phố Hà Nội', 1, 2263, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763557', NULL, NULL, N'J60H7WBK200008', N'LO VI SONG', N'0.074', N'Duong dinh Trung', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'5 NGÕ 184- Phố Hoa Bằng Phường Yên Hoà TQuận Cầu GiấyThành phố Hà Nội', 1, 2264, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763559', NULL, NULL, N'0F754DAK600519', N'TU LANH', N'0.785', N'Trần Hà Phương', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'Phòng 3112-CT12C Kim Văn Kim Lũ Nguyễn XQuận Hoàng MaiThành phố Hà Nội', 1, 2265, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763560', NULL, NULL, N'04MP3NAK700023', N'TI VI', N'0.109', N'Trình Huy Cao', N'HA NOI', NULL, NULL, N'Huyện Hoài Đức', N'0 Thôn Lũng Kênh Xã Đức Giang Thôn LũngHuyện Hoài ĐứcThành phố Hà Nội', 1, 2266, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763561', NULL, NULL, N'04MP3NAK700031', N'TI VI', N'0.109', N'Phạm thanh quyết', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'Thôn 3 Thôn 3 xã Đông Mỹ huyện Thanh trìHuyện Thanh TrìThành phố Hà Nội', 1, 2267, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763563', NULL, NULL, N'00184NAK600858', N'TU LANH', N'0.608', N'Hoàng Thị Sự', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'số 8, ngách 159, ngõ 22, đường Khuyến LưQuận Hoàng MaiThành phố Hà Nội', 1, 2268, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763566', NULL, NULL, N'0F754DAK600534', N'TU LANH', N'0.785', N'Ngô Thị Hằng', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'Số 1 Xuân Lộc, Xuân Đỉnh, Bắc Từ Liêm PhQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2269, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763567', NULL, NULL, N'05HL3NNK701097', N'TI VI', N'0.176', N'Lê Thị Đào', N'HA NOI', NULL, NULL, N'Huyện Mỹ Đức', N'10 Thượng Tiết- Đại Hưng Xã Đại Hưng ĐộiHuyện Mỹ ĐứcThành phố Hà Nội', 1, 2270, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763568', NULL, NULL, N'08UD43BK600059', N'TU LANH', N'1.522', N'Cô Tuyết', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'A54/30 Ngô Thì Nhậm Phường Quang Trung SQuận Hà ĐôngThành phố Hà Nội', 1, 2271, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00763570', NULL, NULL, N'0D5U4DAJC00086', N'TU LANH', N'0.98', N'Nguyễn Khánh Hòa', N'HA NOI', NULL, NULL, N'Quận Hai Bà Trưng', N'P305-92A2 Thanh Nhàn Phường Thanh Nhàn TQuận Hai Bà TrưngThành phố Hà Nội', 1, 2272, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-19 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766226', NULL, NULL, N'0FKWPDBK600059-0FKDPDPK600100', N'DIEU HOA', N'0.122', N'VŨ HỮU BAN', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'-0. Vĩnh Thịnh - Đại Áng- Thanh Trì - HàHuyện Thanh TrìThành phố Hà Nội', 1, 2273, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 82800, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766228', NULL, NULL, N'0FK7PDCK600117-0FKPPDOK600160', N'DIEU HOA', N'0.082', N'Nguyễn văn định', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'Số 3 Bình yên Xã Bình Yên Vân Lôi ThànhHuyện Thạch ThấtThành phố Hà Nội', 1, 2274, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 82800, 0, 0, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766249', NULL, NULL, N'0F754DAK600762', N'TU LANH', N'0.785', N'Nguyễn thị nụ', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'24/32 Phan văn trường Phường Dịch Vọng HQuận Cầu GiấyThành phố Hà Nội', 1, 2275, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766250', NULL, NULL, N'0F754DAK600771', N'TU LANH', N'0.785', N'Tuấn Lê', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'4/64/105 Doãn kế thiện Phường Mai Dịch TQuận Cầu GiấyThành phố Hà Nội', 1, 2276, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766251', NULL, NULL, N'0F754DAK600777', N'TU LANH', N'0.785', N'Nguyễn thị nụ', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'24/32 Phan văn trường Phường Dịch Vọng HQuận Cầu GiấyThành phố Hà Nội', 1, 2277, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766252', NULL, NULL, N'0F754DAK600736', N'TU LANH', N'0.785', N'Nguyễn thị sen', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'12 Ngách 16/33 Đỗ xuân hợp Phường Mỹ ĐìnQuận Nam Từ LiêmThành phố Hà Nội', 1, 2278, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766254', NULL, NULL, N'0F754DAK600774', N'TU LANH', N'0.785', N'Đổng thị tịnh', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'68 Phố Nguyễn Phường Cầu Diễn Thành phốQuận Nam Từ LiêmThành phố Hà Nội', 1, 2279, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766255', NULL, NULL, N'05HL3NNK701575', N'TI VI', N'0.176', N'Trần Tiến Thành', N'HA NOI', NULL, NULL, N'Huyện Đan Phượng', N'15 Thanh Hải Xã Thọ An Thanh hải Thành pHuyện Đan PhượngThành phố Hà Nội', 1, 2280, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766256', NULL, NULL, N'05C43NFK700251', N'TI VI', N'0.149', N'Nguyễn Văn Lập', N'HA NOI', NULL, NULL, N'Huyện Phúc Thọ', N'01 Hà Nội Xã Hiệp Thuận Quế Lâm Thành phHuyện Phúc ThọThành phố Hà Nội', 1, 2281, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766257', NULL, NULL, N'04MP3NAK700166', N'TI VI', N'0.109', N'Dương Văn Toàn', N'HA NOI', NULL, NULL, N'Huyện Mỹ Đức', N'00 đội 7, thôn thượng Xã Phùng Xá đội 7,Huyện Mỹ ĐứcThành phố Hà Nội', 1, 2282, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766258', NULL, NULL, N'00124NAK600017', N'TU LANH', N'0.645', N'Nguyễn văn định', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'Số 3 Bình yên Xã Bình Yên Vân Lôi ThànhHuyện Thạch ThấtThành phố Hà Nội', 1, 2283, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766259', NULL, NULL, N'0BPR5DBK500691', N'MAY GIAT', N'0.312', N'Nguyễn Văn Hưng', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'Lk32 OCT2 Lk32 - OCT2 - Khu đô thị récoQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2284, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766266', NULL, NULL, N'00124NAK600070', N'TU LANH', N'0.645', N'Nguyễn văn Châu', N'HA NOI', NULL, NULL, N'Huyện Ứng Hòa', N'O Thôn Giới Đức Xã Minh Đức Thôn giới đứHuyện Ứng HòaThành phố Hà Nội', 1, 2285, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766268', NULL, NULL, N'0EZ45DBK600946', N'MAY GIAT', N'0.513', N'Nguyễn Ngọc Tuấn', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'phòng 2002 Ct1b2 Nguyễn Khuyến Phường VăQuận Hà ĐôngThành phố Hà Nội', 1, 2286, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766271', NULL, NULL, N'J7G57WFK600202', N'LO VI SONG', N'0.074', N'Trần Thị Kim Dung', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'00 Mặt đường 32, cách Đình Nguyên XaQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2287, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766273', NULL, NULL, N'00124NAK600098', N'TU LANH', N'0.645', N'Nguyen Thien Thinh', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'So nha 20 TDP 18 Phường Phú Lương Bac LaQuận Hà ĐôngThành phố Hà Nội', 1, 2288, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766275', NULL, NULL, N'04MP3NAK700144', N'TI VI', N'0.109', N'Đinh Hà Nam', N'HA NOI', NULL, NULL, N'Huyện Thạch Thất', N'403 Trường Sĩ Quan Chính Trị Xã Thạch HoHuyện Thạch ThấtThành phố Hà Nội', 1, 2289, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766276', NULL, NULL, N'00124NAK600204', N'TU LANH', N'0.645', N'Hà Mạnh Chính', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'P.1409 C2 Xuân Đỉnh Đỗ Nhuận Phường XuânQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2290, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766277', NULL, NULL, N'0FU74DAK601232', N'TU LANH', N'0.749', N'Nguyễn Đắc Quý', N'HA NOI', NULL, NULL, N'Huyện Ba Vì', N'0 0 Xã Thuần Mỹ Thôn 1 Thành phố Hà NộiHuyện Ba VìThành phố Hà Nội', 1, 2291, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766278', NULL, NULL, N'0DT94DAK101133', N'TU LANH', N'0.785', N'Nguyen Thi Hang', N'HA NOI', NULL, NULL, N'THACH THAT', N'XÓM CẦU, THÔN 3, XÃ HẠ BẰNG-THẠCH THẤT, HÀ NỘI', 1, 2292, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766467', NULL, NULL, N'0FLJ4ABK600026', N'TU LANH', N'1.48', N'PHẠM THỊ HOA', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'31 Lĩnh Nam Phường Lĩnh Nam Tổ 17 ngáchQuận Hoàng MaiThành phố Hà Nội', 1, 2293, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766469', NULL, NULL, N'0DTF4DBK500078', N'TU LANH', N'1.221', N'Nguyen dang manh', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'Ngõ 1 thôn Đổng Xuyên xã Đặng Xá huyện GHuyện Gia LâmThành phố Hà Nội', 1, 2294, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766470', NULL, NULL, N'0F764DAK600349', N'TU LANH', N'0.87', N'nguyen ha', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'5 250/39/94 Đường Kim Giang Phường Đại KQuận Hoàng MaiThành phố Hà Nội', 1, 2295, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766471', NULL, NULL, N'07RN4NAK700710', N'TU LANH', N'0.608', N'Pham Tiến lộc', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'1920 tòa HH3C Khu  đô thi linh Đàm, ĐườnQuận Hoàng MaiThành phố Hà Nội', 1, 2296, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766472', NULL, NULL, N'0DTF4DBK500081', N'TU LANH', N'1.221', N'Nguyễn Ngọc Tuấn', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'phòng 2002 Ct1b2 Nguyễn Khuyến Phường VăQuận Hà ĐôngThành phố Hà Nội', 1, 2297, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764131', NULL, NULL, N'0FU74DAK601220', N'TU LANH', N'Nguyễn Ngọc Đức', N'982901710', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'Phòng 205 B6 Ngõ 8A Nguyễn Ngọc Phách PhQuận Đống ĐaThành phố Hà Nội', 1, 2298, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764132', NULL, NULL, N'0D5U4DAJC00130 - 0D5U4DAK100489', N'2 TU LANH', N'nguyễn văn bằng', N'979949653', N'HA NOI', NULL, NULL, N'Huyện Quốc Oai', N'169 thôn khánh tân Xã Sài Sơn Thành phốHuyện Quốc OaiThành phố Hà Nội', 2, 2299, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764134', NULL, NULL, N'0EYZ5DBK600326', N'MAY GIAT', N'Lê Xuân Trường', N'1636476116', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'Số nhà 21 Tổ 14 ngách 95/106 Phường PhúcQuận Long BiênThành phố Hà Nội', 1, 2300, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764140', NULL, NULL, N'05HL3NNK700266', N'TI VI', N'Nguyễn Văn Kiên', N'904767756', N'HA NOI', NULL, NULL, N'Huyện Thường Tín', N'1 Đội 1 Xã Tự Nhiên Đội 1 Thành phố Hà NHuyện Thường TínThành phố Hà Nội', 1, 2301, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764141', NULL, NULL, N'0EYZ5DBK600344', N'MAY GIAT', N'Nguyễn thanh bình', N'1626673801', N'HA NOI', NULL, NULL, N'Quận Hai Bà Trưng', N'Số nhà 34 ngách 2/164 Hồng mai Phường QuQuận Hai Bà TrưngThành phố Hà Nội', 1, 2302, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764142', NULL, NULL, N'0EZ45DBK600947', N'MAY GIAT', N'Vu Thi Thao', N'1639619912', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'540 ngọc lâm Gia thụy Phường Gia Thụy 54Quận Long BiênThành phố Hà Nội', 1, 2303, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764144', NULL, NULL, N'05HR3NEK501233', N'TI VI', N'Ngô Văn', N'977022091', N'HA NOI', NULL, NULL, N'Huyện Thường Tín', N'2 Quốc lộ 1A cũ Xã Duyên Thái Thôn DuyênHuyện Thường TínThành phố Hà Nội', 1, 2304, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764676', NULL, NULL, N'0FU74DAK600541', N'TU LANH', N'Nguyen thi thanh tam', N'1629323690', N'HA NOI', NULL, NULL, N'Huyện Chương Mỹ', N'số 17 khu tiên sơn Thị trấn Chúc Sơn gầnHuyện Chương MỹThành phố Hà Nội', 1, 2305, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764677', NULL, NULL, N'0BPR5DBK500769', N'MAY GIAT', N'Lê Công Tuấn Anh', N'964226650', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'55 Ngõ 02 Đại Lộ Thăng Long (Gần cầu vượQuận Nam Từ LiêmThành phố Hà Nội', 1, 2306, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764678', NULL, NULL, N'0DY55DBK700035', N'MAY GIAT', N'Nguyễn Phương Thảo', N'1675695053', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'60, ngách 77 ngõ 207 Bùi Xương Trạch PhưQuận Thanh XuânThành phố Hà Nội', 1, 2307, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764681', NULL, NULL, N'00124NAK600006', N'TU LANH', N'Nguyễn Ngọc Thùy', N'961365510', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'0 thôn Chi Nam Xã Lệ Chi thôn Chi Nam ThHuyện Gia LâmThành phố Hà Nội', 1, 2308, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764685', NULL, NULL, N'05HK3NDK501241', N'TI VI', N'Do Thi Xuan', N'961244097', N'HA NOI', NULL, NULL, N'BA VI', N'LIEU CHAU. PHU CHAU. BA VI-HA NOI', 1, 2309, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764686', NULL, NULL, N'00184NAK600885', N'TU LANH', N'Dang Thi Thu', N'971446810', N'HA NOI', NULL, NULL, N'CHUONG MY', N'YEN LAC, DONG LAC, CHUONG MY,-HA NOI', 1, 2310, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00764689', NULL, NULL, N'0FU94DAK600943', N'TU LANH', N'Nguyen Van Sy', N'978848630', N'HA NOI', NULL, NULL, N'HOANG MAI', N'B17.02. TOA B TRUNG CU HATECO HOANG-MAI. HA NOI', 1, 2311, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-22 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766597', NULL, NULL, N'0F754DAK600807', N'TU LANH', N'0.785', N'Pham Van Tien', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'1 Làng sen hồ Xã Lệ Chi Sen Hồ Thành phốHuyện Gia LâmThành phố Hà Nội', 1, 2312, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766602', NULL, NULL, N'0FUK4DBK600325', N'TU LANH', N'1.085', N'Hoàng xuân Giang', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'2711A Đồng Phát Park View Phường Vĩnh HưQuận Hoàng MaiThành phố Hà Nội', 1, 2313, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766603', NULL, NULL, N'05VC3NHK700071', N'TI VI', N'0.056', N'Nguyễn Thị Loan', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'14 Số nhà 14, ngách 108/32, Đông Thiên,Quận Hoàng MaiThành phố Hà Nội', 1, 2314, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766605', NULL, NULL, N'0FUM4DAK601793', N'TU LANH', N'0.87', N'Nguyễn Đức Long', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'1 Liên Đàm Xã Yên Thường Thôn liên Đàm THuyện Gia LâmThành phố Hà Nội', 1, 2315, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766606', NULL, NULL, N'00124NAK600058', N'TU LANH', N'0.645', N'Nguyễn Thị Nguyệt', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'14 ngách 129/67 Bát Khối Phường Long BiêQuận Long BiênThành phố Hà Nội', 1, 2316, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766609', NULL, NULL, N'0ARY7WEK600346', N'LO VI SONG', N'0.076', N'Nguyễn Hoàng Minh', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'6 Hoa Lâm Phường Việt Hưng Số 6, ngách 1Quận Long BiênThành phố Hà Nội', 1, 2317, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766616', NULL, NULL, N'00124NAK600063', N'TU LANH', N'0.645', N'Nguyễn Văn Dũng', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'Số 3/Ngõ 78/Đường Mễ Trì Thượng Mễ Trì TQuận Nam Từ LiêmThành phố Hà Nội', 1, 2318, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766617', NULL, NULL, N'0ARV7WEK300188', N'LO VI SONG', N'0.076', N'Trần Chung Kiên', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'20 Nguyễn Khoái Phường Thanh Trì Thanh TQuận Hoàng MaiThành phố Hà Nội', 1, 2319, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766618', NULL, NULL, N'0FKLPDCK600019 - 0FKMPDOK600033', N'DIEU HOA', N'0.094', N'Nguyễn Văn Đoàn', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'nha doan hinh Xóm 3 Xã Kim Lan Thành phốHuyện Gia LâmThành phố Hà Nội', 1, 2320, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 82800, 1, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766620', NULL, NULL, N'08UD43BK700008', N'TU LANH', N'1.522', N'Nguyễn Tất Thắng', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'Toà nhà Anland- khu đô thị Dương nội - LQuận Hà ĐôngThành phố Hà Nội', 1, 2321, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766624', NULL, NULL, N'00124NAK600056', N'TU LANH', N'0.645', N'Đỗ Thị Thu Thảo', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'190 thượng đình 190 thượng đình Phường TQuận Thanh XuânThành phố Hà Nội', 1, 2322, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766627', NULL, NULL, N'04MP3NAK700162', N'TI VI', N'0.109', N'Trần Thị Toan', N'HA NOI', NULL, NULL, N'Huyện Phú Xuyên', N'T1 Mới Xã Tân Dân Thường liễu Thành phốHuyện Phú XuyênThành phố Hà Nội', 1, 2323, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766630', NULL, NULL, N'0F754DAK600804', N'TU LANH', N'0.785', N'tran van hoa', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'Phòng B16-06 Trung cư Anland- khu đô thịQuận Hà ĐôngThành phố Hà Nội', 1, 2324, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766631', NULL, NULL, N'05HL3NNK700968', N'TI VI', N'0.176', N'nguyen thi ngan', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'00 xóm 3 Xã Phù Đổng Thành phố Hà NộiHuyện Gia LâmThành phố Hà Nội', 1, 2325, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766835', NULL, NULL, N'05HK3NDK603545', N'TI VI', N'0.132', N'Lê Văn Thắng', N'HA NOI', NULL, NULL, N'Huyện Thanh Oai', N'N/A Thôn Tây Sơn Xã Phương Trung ChuôngHuyện Thanh OaiThành phố Hà Nội', 1, 2326, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766836', NULL, NULL, N'08RN4NAK602209', N'TU LANH', N'0.57', N'Bác Hạ', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'902 Khu chung cư TB1, chung cư Vĩnh HoànQuận Hoàng MaiThành phố Hà Nội', 1, 2327, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766837', NULL, NULL, N'0FUK4DBK600167', N'TU LANH', N'1.085', N'Nguyễn Ngọc Minh', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'39A Ngõ 337, ngách 245/120 (gần hồ ĐịnhQuận Hoàng MaiThành phố Hà Nội', 1, 2328, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766838', NULL, NULL, N'0DY55DBK700015', N'MAY GIAT', N'0.546', N'Vũ Văn San', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'So 16 ngo 73 Phung khoang Phường Trung VQuận Nam Từ LiêmThành phố Hà Nội', 1, 2329, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766839', NULL, NULL, N'J6UB7WBK300172', N'LO VI SONG', N'0.074', N'mai thuy ngan', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'26 ngách 670/32, hà huy tập Thị trấn YênHuyện Gia LâmThành phố Hà Nội', 1, 2330, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766843', NULL, NULL, N'0FUK4DBK600236', N'TU LANH', N'1.085', N'Lê hà my', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'6 Đặng thuỳ trâm Phường Nghĩa Tân ThànhQuận Cầu GiấyThành phố Hà Nội', 1, 2331, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766846', NULL, NULL, N'0FUK4DBK600297', N'TU LANH', N'1.085', N'Đinh hoài thu', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'124 Tổ 5 Đồng me Phường Mễ Trì Thành phốQuận Nam Từ LiêmThành phố Hà Nội', 1, 2332, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00766850', NULL, NULL, N'00124NAK600283', N'TU LANH', N'0.645', N'Nong Thi Mai', N'HA NOI', NULL, NULL, N'LONG BIEN', N'SỐ NHÀ 108,TỔ 2,PHỐ THẠCH BÀN,-LONG BIÊN.HÀ NỘI', 1, 2333, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-07-23 00:00:00.000' AS DateTime), N'04', NULL)
GO
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767545', NULL, NULL, N'05C03NEK700113', N'TI VI', N'0.188', N'Nguyễn Thanh Đồng', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'309 V2 khu đô thị đặng xá Xã Đặng Xá khuHuyện Gia LâmThành phố Hà Nội', 1, 2334, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767546', NULL, NULL, N'0CJM14KK700495', N'LOA', N'0.134', N'Nguyễn Thanh Đồng', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'309 V2 khu đô thị đặng xá Xã Đặng Xá khuHuyện Gia LâmThành phố Hà Nội', 1, 2335, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767547', NULL, NULL, N'07U88NBK400059', N'MAY HUT BUI', N'0.063', N'Lee Jung Hyun', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'P306 L2 Ciputra Phường Xuân Đỉnh P306 L2Quận Bắc Từ LiêmThành phố Hà Nội', 1, 2336, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767548', NULL, NULL, N'05HM3NEK700474', N'TI VI', N'0.205', N'ĐỖ VĂN THẮNG', N'HA NOI', NULL, NULL, N'Huyện Quốc Oai', N'0 Đội 2 Xã Cấn Hữu Thượng Khê Thành phốHuyện Quốc OaiThành phố Hà Nội', 1, 2337, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767551', NULL, NULL, N'00184NAK200341', N'TU LANH', N'0.608', N'Trần văn hoà', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'Số nhà 12 , ngách 33 , ngõ 73 Đường ĐứcQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2338, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767553', NULL, NULL, N'0D4C4DAK500096', N'TU LANH', N'0.899', N'Lê Thị Lan', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'A4 2105 232 Phạm Văn Đồng Phường Cổ NhuếQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2339, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767554', NULL, NULL, N'000R4NAK700039', N'TU LANH', N'0.57', N'Trần Thành Công', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'Số 5 ngõ 108 Bùi Xương Trạch Phường KhươQuận Thanh XuânThành phố Hà Nội', 1, 2340, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767556', NULL, NULL, N'0F764DAK600462', N'TU LANH', N'0.87', N'Hoàng Lâm Tuân', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'606 Hàm Nghi Phường Mỹ Đình 2 Toà CT1A cQuận Nam Từ LiêmThành phố Hà Nội', 1, 2341, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767557', NULL, NULL, N'07U88NBK400074', N'MAY HUT BUI', N'0.063', N'Nguyễn Thị Dinh', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'1 Phạm Văn Bạch Phường Yên Hoà Thành phốQuận Cầu GiấyThành phố Hà Nội', 1, 2342, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767561', NULL, NULL, N'0F764DAK600458', N'TU LANH', N'0.87', N'Mai văn diệu', N'HA NOI', NULL, NULL, N'Quận Ba Đình', N'18 Kim mã thượng Phường Cống Vị Thành phQuận Ba ĐìnhThành phố Hà Nội', 1, 2343, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767562', NULL, NULL, N'J7G57WFK600187', N'LO VI SONG', N'0.074', N'Hà Ngọc Linh', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'2105 tòa CT 7G Khu đô thị Dương nội, HàQuận Hà ĐôngThành phố Hà Nội', 1, 2344, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767563', NULL, NULL, N'0FLJ4ABK600010', N'TU LANH', N'1.48', N'Nguyễn Khắc Tung', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'902A Khu Đô Thị Đại Kim Phường Đại Kim KQuận Hoàng MaiThành phố Hà Nội', 1, 2345, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767564', NULL, NULL, N'0F764DAK600454', N'TU LANH', N'0.87', N'Anh hoàng', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'80 Trần vỹ Phường Mai Dịch Thành phố HàQuận Cầu GiấyThành phố Hà Nội', 1, 2346, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767565', NULL, NULL, N'0F764DAK600450', N'TU LANH', N'0.87', N'Mai Ngô', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'2 Ngõ 7 Phùng Khoang Phường Trung Văn ThQuận Nam Từ LiêmThành phố Hà Nội', 1, 2347, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767566', NULL, NULL, N'0F764DAK600465', N'TU LANH', N'0.87', N'Đỗ tú', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'50 Ngõ 260 Cầu giấy Phường Quan Hoa ThànQuận Cầu GiấyThành phố Hà Nội', 1, 2348, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767567', NULL, NULL, N'0F764DAK600456', N'TU LANH', N'0.87', N'Luyện văn dũng', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'120 Lê quang đạo Phường Phú Đô Thành phốQuận Nam Từ LiêmThành phố Hà Nội', 1, 2349, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767569', NULL, NULL, N'0F764DAK600459', N'TU LANH', N'0.87', N'Nguỵ thành phượng', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'136 Trung hoà Phường Yên Hoà Thành phố HQuận Cầu GiấyThành phố Hà Nội', 1, 2350, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767571', NULL, NULL, N'0F764DAK600419', N'TU LANH', N'0.87', N'Nguyễn văn chuyển', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'11A Ngõ 213 Giáp Nhát Phường Nhân ChínhQuận Thanh XuânThành phố Hà Nội', 1, 2351, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767574', NULL, NULL, N'04MP3NAK700010', N'TI VI', N'0.109', N'Đỗ Thành Vĩnh', N'HA NOI', NULL, NULL, N'Quận Tây Hồ', N'25 tổ 29, cụm 4, ngõ 163/18 Phường Phú TQuận Tây HồThành phố Hà Nội', 1, 2352, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767576', NULL, NULL, N'05C33NEK700541', N'TI VI', N'0.219', N'Nguyễn Đức Giáp', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'6 Giao Tất Xã Kim Sơn Giao Tất Thành phốHuyện Gia LâmThành phố Hà Nội', 1, 2353, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 1, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767577', NULL, NULL, N'0B4L7WAJB00246', N'LO VI SONG', N'0.073', N'Trần Như Trung', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'ngõ 1150 đường Láng Phường Láng Thượng TQuận Đống ĐaThành phố Hà Nội', 1, 2354, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767578', NULL, NULL, N'0ARY7WEK600308', N'LO VI SONG', N'0.076', N'Biện Đức Trường', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'15 Ngõ 599/4 Phạm Văn Đồng, Cổ Nhuế PhườQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2355, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767581', NULL, NULL, N'0CCL5DBK501283', N'MAY GIAT', N'0.555', N'Hoàng Minh Luận', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'1838 hh3b khu đô thị linh đàm Phường HoàQuận Hoàng MaiThành phố Hà Nội', 1, 2356, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00767583', NULL, NULL, N'08LL5NAK600005', N'MAY GIAT', N'0.416', N'Le Manh Hung', N'HA NOI', NULL, NULL, N'DAN PHUONG', N'ĐỘI 3 - THỌ AN-ĐAN PHƯỢNG - HÀ NỘI', 1, 2357, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 144000, 0, 0, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00768006', NULL, NULL, N'0DT94DAK600138', N'TU LANH', N'0.785', N'Nguyễn Viết Thuỳ Linh', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'Phòng 1603 - CT1A- chung cư 789 Xuân ĐỉnQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2358, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00768007', NULL, NULL, N'0FUK4DBK600183', N'TU LANH', N'1.085', N'vương minh tuấn', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'Tòa nhà A5 hoàng liệt Phường Hoàng LQuận Hoàng MaiThành phố Hà Nội', 1, 2359, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00768010', NULL, NULL, N'0FU74DAK601209', N'TU LANH', N'0.749', N'Nguyễn Văn Toàn', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'P1016 Khu đô Thị Thanh Hà Phường Kiến HưQuận Hà ĐôngThành phố Hà Nội', 1, 2360, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00768013', NULL, NULL, N'0SY44ADK500194', N'TU LANH', N'1.48', N'Nguyen Thi Nhung', N'HA NOI', NULL, NULL, N'GIA LAM', N'ĐỘI 15 - CHỬ XÁ - VĂN ĐỨC-GIA LÂM - HÀ NỘI', 1, 2361, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-24 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770095', NULL, NULL, N'08RN4NAK602777', N'TU LANH', N'0.57', N'Lê Huy Tuấn', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'3/12/116 Nhân Hoà Phường Nhân Chính ThànQuận Thanh XuânThành phố Hà Nội', 1, 2362, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770096', NULL, NULL, N'0FU74DAK601246', N'TU LANH', N'0.749', N'Hoàng Công Nhật', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'47a Ngách 667/2 Nguyễn Văn Cừ Phường ĐứcQuận Long BiênThành phố Hà Nội', 1, 2363, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770098', NULL, NULL, N'0EYZ5DBK700141', N'MAY GIAT', N'0.513', N'Đỗ Thị Mai Phương', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'Số 6A5 Ngõ 201 Đường Trần Quốc Hoàn PhườQuận Cầu GiấyThành phố Hà Nội', 1, 2364, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770100', NULL, NULL, N'067P3NDK701434', N'TI VI', N'0.056', N'Nguyễn Thị Kim Lộc', N'HA NOI', NULL, NULL, N'Quận Ba Đình', N'Số 26, ngõ 4 Phố quần ngựa Phường Ngọc HQuận Ba ĐìnhThành phố Hà Nội', 1, 2365, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770101', NULL, NULL, N'0EYZ5DBK700144', N'MAY GIAT', N'0.513', N'Đỗ Thế Huy', N'HA NOI', NULL, NULL, N'Quận Hai Bà Trưng', N'54 Ngách 27, ngõ Chùa Liên Phái Phường CQuận Hai Bà TrưngThành phố Hà Nội', 1, 2366, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770103', NULL, NULL, N'05HM3NEK700470', N'TI VI', N'0.205', N'Chú Chinh', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'N/A Kiêu kỵ Xã Kiêu Kỵ Đội 2 thôn kiêu kHuyện Gia LâmThành phố Hà Nội', 1, 2367, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770106', NULL, NULL, N'0F754DAK600275', N'TU LANH', N'0.785', N'Lê thị hoan', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'8 Ngách 102/20 Đường Láng Phường Láng ThQuận Đống ĐaThành phố Hà Nội', 1, 2368, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770107', NULL, NULL, N'0F754DAK600276', N'TU LANH', N'0.785', N'Đỗ thị hoa', N'HA NOI', NULL, NULL, N'Quận Ba Đình', N'5 Thanh bảo Phường Kim Mã Thành phố Hà NQuận Ba ĐìnhThành phố Hà Nội', 1, 2369, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770108', NULL, NULL, N'0EYZ5DBK700127', N'MAY GIAT', N'0.513', N'Pham Duc Hai', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'24T2 Hoàng Đạo Thúy Phường Trung Hoà ThàQuận Cầu GiấyThành phố Hà Nội', 1, 2370, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770109', NULL, NULL, N'0FLH4ABK200034', N'TU LANH', N'1.48', N'Đinh Mạnh Đạt', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'P405 Tòa nhà NO1, ngõ 295 Yên Hòa PhườngQuận Cầu GiấyThành phố Hà Nội', 1, 2371, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770115', NULL, NULL, N'0F754DAK600289', N'TU LANH', N'0.785', N'Nguyễn Khánh Ngọc', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'A4-1209 Tòa A4, Khu đô thị An Bình city,Quận Bắc Từ LiêmThành phố Hà Nội', 1, 2372, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770116', NULL, NULL, N'0F764DAK600512', N'TU LANH', N'0.87', N'Nguyễn đức thức', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'Số nhà 226 tổ dân phố 11 Mậu Lương Mậu lQuận Hà ĐôngThành phố Hà Nội', 1, 2373, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770119', NULL, NULL, N'00184NAK700930', N'TU LANH', N'0.608', N'Hoang Trung Thanh', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'401 Khu đô thị The Spark Dương Nội PhườnQuận Hà ĐôngThành phố Hà Nội', 1, 2374, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770121', NULL, NULL, N'00124NAK600080', N'TU LANH', N'0.645', N'hoang minh luan', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'18-38 -hh3b KĐT Linh Đàm Phường Hoàng LiQuận Hoàng MaiThành phố Hà Nội', 1, 2375, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770122', NULL, NULL, N'0ARV7WEK300152', N'LO VI SONG', N'0.076', N'Hoàng Minh Luận', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'1838HH3B khu đô thị Linh Đàm Phường HoànQuận Hoàng MaiThành phố Hà Nội', 1, 2376, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770125', NULL, NULL, N'08RN4NAK602770', N'TU LANH', N'0.57', N'Đàm Duy Tiến', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'1c7 Hoàng Ngọc Phách Phường Láng Hạ HoànQuận Đống ĐaThành phố Hà Nội', 1, 2377, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-25 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770626', NULL, NULL, N'07U88NBK400023', N'MAY HUT BUI', N'0.063', N'Lê Tùng Bách', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'Phòng 519 Nhà K1 Giảng Võ Phường Cát LinQuận Đống ĐaThành phố Hà Nội', 1, 2378, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-26 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770627', NULL, NULL, N'ZZFGH4ZK600099', N'MAN HINH', N'0.034', N'Lương Văn Tấn', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'nhà 10 ngõ 116 kim hoa, phường phương liQuận Đống ĐaThành phố Hà Nội', 1, 2379, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-26 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770636', NULL, NULL, N'07UB8NBK600443', N'MAY HUT BUI', N'0.063', N'Nguyễn Hữu Hưng', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'31 Ngõ 88/61 Giáp Nhị Phường Thịnh LiệtQuận Hoàng MaiThành phố Hà Nội', 1, 2380, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-26 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770637', NULL, NULL, N'0FLH4ABK200025', N'TU LANH', N'1.48', N'Nguyễn Thu Hằng', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'Tang 12a B12A04 Golden Palm, Lô đất 4-5Quận Thanh XuânThành phố Hà Nội', 1, 2381, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-26 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770649', NULL, NULL, N'0EYZ5DBK700123', N'MAY GIAT', N'0.513', N'Le Thi Tinh', N'HA NOI', NULL, NULL, N'NAM THANG LONG', N'ngách 355/83, THÔN LỘC, XUÂN ĐỈNH,-NAM THĂNG LONG, HÀ NỘI', 1, 2382, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-26 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770650', NULL, NULL, N'067P3NDK702197', N'TI VI', N'0.056', N'Le Thi Tinh', N'HA NOI', NULL, NULL, N'NAM THANG LONG', N'ngách 355/83, THÔN LỘC, XUÂN ĐỈNH,-NAM THĂNG LONG, HÀ NỘI', 1, 2383, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-26 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI00770652', NULL, NULL, N'0EYZ5DBK600346', N'MAY GIAT', N'0.513', N'Nguyen Thi Thuy', N'HA NOI', NULL, NULL, N'NAM TU LIEM', N'SO 63, DUONG K2, CAU DIEN-NAM TU LIEM, HA NOI', 1, 2384, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-26 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821812', NULL, NULL, N'0FKBPDCK600193-0FKUPDOK600215', N'DIEU HOA', N'0.082', N'Anh Sơn', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'1 Xóm 3 Xã Phù Đổng Xóm 3 Thành phố Hà NHuyện Gia LâmThành phố Hà Nội', 1, 2385, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 82800, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821866', NULL, NULL, N'0ARY7WEK600300', N'LO VI SONG', N'0.076', N'Bùi Thế Anh', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'68 Keo Xã Kim Sơn Giao tự Thành phố Hà NHuyện Gia LâmThành phố Hà Nội', 1, 2386, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821871', NULL, NULL, N'05HK3NDK501658', N'TI VI', N'0.132', N'Nguyễn Văn Thao', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'00 Thôn Yên Thường Xã Yên Thường Thôn YêHuyện Gia LâmThành phố Hà Nội', 1, 2387, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821877', NULL, NULL, N'0EZ05DBK700292', N'MAY GIAT', N'0.513', N'LÊ VĂN TIẾN', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'89G, ngõ 5 hoàng quốc việt HOÀNG QUỐC VIQuận Cầu GiấyThành phố Hà Nội', 1, 2388, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821884', NULL, NULL, N'0P8NHTNK600429', N'MAN HINH', N'0.061', N'NGUYEN HOANG VIET', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'Phòng 304 - Chung cư T8A - Ngõ 1B Tạp ChQuận Thanh XuânThành phố Hà Nội', 1, 2389, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821885', NULL, NULL, N'0EZ05DBK700281', N'MAY GIAT', N'0.513', N'Nguyễn Hồng Quỳnh', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'167 Trương Định Phường Tân Mai Số nhà 16Quận Hoàng MaiThành phố Hà Nội', 1, 2390, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821886', NULL, NULL, N'05VC3NAK700574 - 05VC3NAK700619', N'2 TI VI', N'0.112', N'HÀ THANH TÚ', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'4 PHẠM NGỌC THẠCH Phường Trung Tự NGÕ 80Quận Đống ĐaThành phố Hà Nội', 2, 2391, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821887', NULL, NULL, N'05VC3NAK700496 - 05VC3NAK700517', N'2 TI VI', N'0.112', N'Nguyễn Thị Tâm', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'4 Phạm Ngọc Thạch Phường Trung Tự Ngõ 80Quận Đống ĐaThành phố Hà Nội', 2, 2392, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821888', NULL, NULL, N'05C03NNK600660', N'TI VI', N'0.188', N'Vũ Tiến Tùng', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'N/A Ngũ Hiệp Xã Ngũ Hiệp Tương Chúc ThànHuyện Thanh TrìThành phố Hà Nội', 1, 2393, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821890', NULL, NULL, N'07U88NBK400049', N'MAY HUT BUI', N'0.063', N'Lê Quang Thắng', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'Số 2 ngách 29/18 Chu Huy Mân Phường PhúcQuận Long BiênThành phố Hà Nội', 1, 2394, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821891', NULL, NULL, N'J7G57WFK600121', N'LO VI SONG', N'0.074', N'Nguyễn Thị Tuyết Trinh', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'9 Ngõ 161, yên xá Xã Tân Triều Yên Xá ThHuyện Thanh TrìThành phố Hà Nội', 1, 2395, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821892', NULL, NULL, N'0FU74DAK601158', N'TU LANH', N'0.749', N'Lê Quang Thắng', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'Số 2 ngách 29/18 Chu Huy Mân Phường PhúcQuận Long BiênThành phố Hà Nội', 1, 2396, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821894', NULL, NULL, N'07U88NBK400058', N'MAY HUT BUI', N'0.063', N'Nguyễn Quý Cường', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'369 ngõ Văn Chương Phường Khâm Thiên ThàQuận Đống ĐaThành phố Hà Nội', 1, 2397, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821896', NULL, NULL, N'J7G57WFK600133', N'LO VI SONG', N'0.074', N'Nguyễn Thị Loan', N'HA NOI', NULL, NULL, N'Quận Ba Đình', N'410-Đ8 Nguyên Hồng, tập thể bắc thành côQuận Ba ĐìnhThành phố Hà Nội', 1, 2398, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-28 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822201', NULL, NULL, N'0FU74DAK601012', N'TU LANH', N'0.749', N'Nguyễn Hoàng Anh', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'P502, Dream Center Home Ngõ 282, NguyễnQuận Thanh XuânThành phố Hà Nội', 1, 2399, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822202', NULL, NULL, N'000R4NAK700021', N'TU LANH', N'0.57', N'Vũ Trung Nam', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'Số 33 ngõ 362/2 Giải Phóng Phường ThịnhQuận Hoàng MaiThành phố Hà Nội', 1, 2400, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822204', NULL, NULL, N'05AB3NGK500068', N'TI VI', N'0.287', N'ĐÀO PHƯƠNG GIANG', N'HA NOI', NULL, NULL, N'Quận Hai Bà Trưng', N'8 Võ Thị Sáu Phường Thanh Nhàn 8 Võ ThịQuận Hai Bà TrưngThành phố Hà Nội', 1, 2401, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822206', NULL, NULL, N'05HL3NNK702354', N'TI VI', N'0.176', N'Phạm Văn Hiệp', N'HA NOI', NULL, NULL, N'Huyện Thường Tín', N'01678337145 Thôn Yên Lãng Xã Văn Tự ThônHuyện Thường TínThành phố Hà Nội', 1, 2402, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822207', NULL, NULL, N'0CJM14KK700485', N'LOA', N'0.134', N'Phạm Văn Hiệp', N'HA NOI', NULL, NULL, N'Huyện Thường Tín', N'01678337145 Thôn Yên Lãng Xã Văn Tự ThônHuyện Thường TínThành phố Hà Nội', 1, 2403, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822208', NULL, NULL, N'000R4NAK700016', N'TU LANH', N'0.57', N'Nguyễn Thị Hồng Nhung', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'19 Ngõ 1 Hà Huy Tập Thị trấn Yên Viên NgHuyện Gia LâmThành phố Hà Nội', 1, 2404, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822211', NULL, NULL, N'07SG8NAK400034', N'MAY HUT BUI', N'0.056', N'Mẫn Văn Vinh', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'349 Vũ Tông Phan Phường Khương Đình CănQuận Thanh XuânThành phố Hà Nội', 1, 2405, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822214', NULL, NULL, N'07RP4NAK700669', N'TU LANH', N'0.645', N'Phạm Đắc Thành', N'HA NOI', NULL, NULL, N'Huyện Thanh Oai', N'xóm 2 úc lý Xã Thanh Văn Thôn Úc Lý ThànHuyện Thanh OaiThành phố Hà Nội', 1, 2406, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 176400, 0, 0, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822216', NULL, NULL, N'0EZ05DBK700277', N'MAY GIAT', N'0.513', N'Nguyễn Tấn Anh', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'422 Ngõ 110 Hoàng Quốc Việt, Phường NghĩQuận Cầu GiấyThành phố Hà Nội', 1, 2407, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 144000, 1, NULL, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822224', NULL, NULL, N'0EZ05DBK700322', N'MAY GIAT', N'0.513', N'Trần Thị Tuyết', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'10 ngõ 21 Yên Xá Xã Tân Triều số nhà 10,Huyện Thanh TrìThành phố Hà Nội', 1, 2408, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822225', NULL, NULL, N'05HK3NDK502371', N'TI VI', N'0.132', N'TRAN THI MINH NGOC', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'6 NGO 12 Thị trấn Trâu Quỳ Đường C, An ĐHuyện Gia LâmThành phố Hà Nội', 1, 2409, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822229', NULL, NULL, N'067P3NBK704266', N'TI VI', N'0.056', N'Doan Thi Huynh', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'510,21B6 Greenstar 234 Pham Van Dong PhưQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2410, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-30 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822802', NULL, NULL, N'0EZ05DBK600406', N'MAY GIAT', N'0.513', N'Lưu thị minh Ánh', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'Số 4 ngõ 308 Chợ khâm thiên Phường PhươnQuận Đống ĐaThành phố Hà Nội', 1, 2411, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 144000, 1, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822805', NULL, NULL, N'0D614DAK700025', N'TU LANH', N'1.085', N'Lê thị duyên', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'19 Ngõ 2 Hoang Sâm Phường Nghĩa Tân ThànQuận Cầu GiấyThành phố Hà Nội', 1, 2412, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822806', NULL, NULL, N'0D614DAK700002', N'TU LANH', N'1.085', N'Nguyễn thành luân', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'9 Đồng bát Phường Mỹ Đình 2 Thành phố HàQuận Nam Từ LiêmThành phố Hà Nội', 1, 2413, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822807', NULL, NULL, N'07XT8NDK600066', N'MAY HUT BUI', N'0.056', N'Trần Thị Xoa', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'Căn A112 A04 Tòa A1 Vinhomes Gardenia HàQuận Nam Từ LiêmThành phố Hà Nội', 1, 2414, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822814', NULL, NULL, N'05HM3NEK700302', N'TI VI', N'0.205', N'Phạm Ngọc Huy', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'xóm 2, thôn Quỳnh Đô xã Vĩnh Quỳnh, huyệHuyện Thanh TrìThành phố Hà Nội', 1, 2415, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822818', NULL, NULL, N'0F764DAK700204', N'TU LANH', N'0.87', N'Đỗ thị thương', N'HA NOI', NULL, NULL, N'Quận Ba Đình', N'135 Đốc ngữ Phường Liễu Giai Thành phố HQuận Ba ĐìnhThành phố Hà Nội', 1, 2416, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822819', NULL, NULL, N'0F764DAK700211', N'TU LANH', N'0.87', N'Hoàng phúc', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'10 Ngách 12/12 nguyễn phúc lai Phường ÔQuận Đống ĐaThành phố Hà Nội', 1, 2417, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822820', NULL, NULL, N'0F764DAK700210', N'TU LANH', N'0.87', N'Nguyễn minh vũ', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'19 Phạm thận duật Phường Mai Dịch ThànhQuận Cầu GiấyThành phố Hà Nội', 1, 2418, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822821', NULL, NULL, N'0F764DAK700212', N'TU LANH', N'0.87', N'Phạm thuỳ Linh', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'5 Ngõ 56 cự lộc Phường Thượng Đình ThànhQuận Thanh XuânThành phố Hà Nội', 1, 2419, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822822', NULL, NULL, N'0F764DAK700241', N'TU LANH', N'0.87', N'Phạm tiến đạt', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'2 Ngõ 7 Phùng Khoang Phường Trung Văn ThQuận Nam Từ LiêmThành phố Hà Nội', 1, 2420, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822823', NULL, NULL, N'J7G57WFK600247', N'LO VI SONG', N'0.074', N'Sam sung', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'Số 7 ngõ 27 kiều mai Số 7 ngõ 27 kiều maQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2421, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01822827', NULL, NULL, N'07U88NBK400014', N'MAY HUT BUI', N'0.063', N'Lê Ngọc Tuân', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'E1-2016 Phúc Lợi Phường Phúc Lợi Chung cQuận Long BiênThành phố Hà Nội', 1, 2422, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01823085', NULL, NULL, N'0FK7PDCK600098 - 0FKPPDOK600197', N'DIEU HOA', N'0.082', N'Nguyễn Văn Thành', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'00 Thôn Bình Trù Xã Dương Quang Thành phHuyện Gia LâmThành phố Hà Nội', 1, 2423, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 82800, 1, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01823087', NULL, NULL, N'0FU74DAK601036', N'TU LANH', N'0.749', N'Vũ Văn Vương', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'20 ngõ 63 Trần Quốc Vượng Phường Dịch VọQuận Cầu GiấyThành phố Hà Nội', 1, 2424, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01823088', NULL, NULL, N'05C23NDK703046', N'TI VI', N'0.112', N'Phạm Thị Thanh Huyền', N'HA NOI', NULL, NULL, N'Quận Hoàn Kiếm', N'18 Hàng Chiếu Phường Đồng Xuân Nhà 201,Quận Hoàn KiếmThành phố Hà Nội', 1, 2425, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-31 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01820991', NULL, NULL, N'0FLL4ABJC00036', N'TU LANH', N'1.48', N'Nguyễn Tuấn Anh', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'01 Phố Miêu Nha Phường Tây Mỗ Tổ dân phốQuận Nam Từ LiêmThành phố Hà Nội', 1, 2426, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01820997', NULL, NULL, N'05HK3NDK502445', N'TI VI', N'0.132', N'Phạm hữu Tường', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'20 Tựu Liệt Thị trấn Văn Điển Nghách 19Huyện Thanh TrìThành phố Hà Nội', 1, 2427, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01820998', NULL, NULL, N'0FU94DAK600985', N'TU LANH', N'0.899', N'Nguyen Quang Huy', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'4 ngõ 195 Trần Cung, ngách 57 Phường CổQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2428, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01820999', NULL, NULL, N'00184NAK700971', N'TU LANH', N'0.608', N'Bùi Tiến Dũng', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'1640, tòa HH2B, chung cư Linh Đàm Linh ĐQuận Hoàng MaiThành phố Hà Nội', 1, 2429, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821000', NULL, NULL, N'ZZMRH4ZK600765', N'MAN HINH', N'0.037', N'Bùi Đình Thơn', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'17 Ngõ 196/8/9 đường Cầu Giấy Phường QuaQuận Cầu GiấyThành phố Hà Nội', 1, 2430, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821005', NULL, NULL, N'05HK3NDK502439', N'TI VI', N'0.132', N'Phạm thế thanh sơn', N'HA NOI', NULL, NULL, N'Quận Hoàn Kiếm', N'52 Hàng bè Phường Hàng Bạc Thành phố HàQuận Hoàn KiếmThành phố Hà Nội', 1, 2431, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821006', NULL, NULL, N'0PBSHTHK600018', N'MAN HINH', N'0.075', N'nguyễn văn mạnh', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'12 ngõ 103 chợ cổ nhuế Phường Cổ Nhuế 2Quận Bắc Từ LiêmThành phố Hà Nội', 1, 2432, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821012', NULL, NULL, N'05C13NEK700065', N'TI VI', N'0.174', N'Nguyễn Văn Tảo', N'HA NOI', NULL, NULL, N'Huyện Phúc Thọ', N'A Cụm 2 Thị trấn Phúc Thọ Thành phố Hà NHuyện Phúc ThọThành phố Hà Nội', 1, 2433, N'tr1', N'Np', N'Hủy đơn', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'Hủy đơn', N'Hủy đơn', NULL, N'', 97200, 0, 0, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
GO
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821014', NULL, NULL, N'0ARY7WEK600223', N'LO VI SONG', N'0.076', N'Nguyễn Thị Kim Hoài', N'HA NOI', NULL, NULL, N'Quận Tây Hồ', N'So 7A ngách 76 ngõ 124 Âu Cơ Phường Tứ LQuận Tây HồThành phố Hà Nội', 1, 2434, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821015', NULL, NULL, N'0FU74DAK601266', N'TU LANH', N'0.749', N'Phạm Hữu Đô', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'138 Phú Viên Phường Bồ Đề Phú Viên ThànhQuận Long BiênThành phố Hà Nội', 1, 2435, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821017', NULL, NULL, N'0P8NHTNK600304', N'MAN HINH', N'0.061', N'Bùi Trung Thái', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'Số 115 Ngõ 160 Phường Tây Tựu Tổ dân phốQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2436, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01821019', NULL, NULL, N'04MP3NAK600058', N'TI VI', N'0.109', N'Lê Thị Ngọc Bích', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'309 CT6 - khu đô thị Tứ Hiệp Xã Tứ HiệpHuyện Thanh TrìThành phố Hà Nội', 1, 2437, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-07-27 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829717', NULL, NULL, N'06FN3NDK601512', N'TI VI', N'0.132', N'Hoang Duc Binh', N'HA NOI', NULL, NULL, N'Huyện Thanh Trì', N'3 Đội 1 Xã Ngọc Hồi Lạc Thị Thành phố HàHuyện Thanh TrìThành phố Hà Nội', 1, 2438, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-08-06 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829718', NULL, NULL, N'0DT94DAK700023', N'TU LANH', N'0.785', N'Đỗ Trường Sơn', N'HA NOI', NULL, NULL, N'Quận Ba Đình', N'Số 9 ngõ 228 ( đối diện candle hotel ) ĐQuận Ba ĐìnhThành phố Hà Nội', 1, 2439, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-06 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829719', NULL, NULL, N'0ARY7WEK600314', N'LO VI SONG', N'0.076', N'Bùi Quang Lâm', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'522 349 Vũ Tông Phan Phường Khương TrungQuận Thanh XuânThành phố Hà Nội', 1, 2440, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-08-06 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829727', NULL, NULL, N'0E2D4DAK602032', N'TU LANH', N'0.749', N'Trần Xuân Thanh', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'113/43 Trung Kinh, Trung Hòa, Cầu Giấy,Quận Cầu GiấyHA NOI', 1, 2441, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-06 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829737', NULL, NULL, N'07RN4NAK701294', N'TU LANH', N'0.608', N'Hoàng Thanh Quang', N'HA NOI', NULL, NULL, N'Huyện Gia Lâm', N'Khu tái định cư  Cầu Chùa Thôn Chu Xá XãHuyện Gia LâmHA NOI', 1, 2442, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-06 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829738', NULL, NULL, N'0E2D4DAK602039', N'TU LANH', N'0.749', N'Hoàng Trung Đức', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'Số nhà 38 hẹn số 3 ngách 191 ngõ sQuận Nam Từ LiêmHA NOI', 1, 2443, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-06 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829740', NULL, NULL, N'0DTA4DAK500237', N'TU LANH', N'0.87', N'Nguyễn Mạnh Hùng', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'0908 Đường Tố Hữu Phường La Khê Phòng 09Quận Hà ĐôngHA NOI', 1, 2444, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-06 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829742', NULL, NULL, N'07RN4NAK701317', N'TU LANH', N'0.608', N'Nguyễn Văn Dự', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'3A08 - tòa 21B4 - Chung cư GreenStar KhuQuận Bắc Từ LiêmHA NOI', 1, 2445, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-06 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829746', NULL, NULL, N'0E2D4DAK602048', N'TU LANH', N'0.749', N'phạm thị ngọc/samsung display', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'55 Ngõ 467 phạm văn đồng Phường Cổ NhuếQuận Bắc Từ LiêmHA NOI', 1, 2446, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-06 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829803', NULL, NULL, N'0D4C4DAK600847', N'TU LANH', N'0.899', N'Mai Như Thảo', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'Phòng 1203, Chung cu Ecolife Capitol 58-Quận Nam Từ Liêm-Thành phố Hà Nội', 1, 2447, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-06 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829394', NULL, NULL, N'0DT94DAK700017', N'TU LANH', N'0.785', N'ANH HUNG', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'CT11 CC KIM VAN KIM LU Phường Đại Kim ThQuận Hoàng MaiThành phố Hà Nội', 1, 2448, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-04 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829402', NULL, NULL, N'0DT94DAK700013', N'TU LANH', N'0.785', N'Phạm Thanh Sơn', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'12 Đại Linh Phường Trung Văn Ngõ 119 ThàQuận Nam Từ LiêmThành phố Hà Nội', 1, 2449, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-04 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829468', NULL, NULL, N'07RN4NAK701305', N'TU LANH', N'0.608', N'Đỗ Bá Khoa', N'HA NOI', NULL, NULL, N'Huyện Thường Tín', N'12 Đông Cứu Xã Dũng Tiến Đông Cứu ThànhHuyện Thường TínThành phố Hà Nội', 1, 2450, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-04 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829471', NULL, NULL, N'0FUC4DAK600206', N'TU LANH', N'0.899', N'Vũ Đình Thi', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'Số 98 Ngọc Thụy Phường Ngọc Thụy Ngách 6Quận Long BiênThành phố Hà Nội', 1, 2451, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 176400, 0, NULL, CAST(N'2018-08-04 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829472', NULL, NULL, N'0CCQ5DBK600345', N'MAY GIAT', N'0.546', N'Hoàng Thị Oanh', N'HA NOI', NULL, NULL, N'Quận Đống Đa', N'207 Phòng 207 E5 khu Tập thể Trung Tự PhQuận Đống ĐaThành phố Hà Nội', 1, 2452, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 144000, 0, NULL, CAST(N'2018-08-04 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01829474', NULL, NULL, N'000R4NAK700194', N'TU LANH', N'0.57', N'Lê thị hoa', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'31 Ngõ 14/30 mễ trì Phường Mễ Trì Mê trìQuận Nam Từ LiêmThành phố Hà Nội', 1, 2453, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-04 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827692', NULL, NULL, N'0CCL5DBK500191', N'MAY GIAT', N'0.555', N'Nguyễn Văn Tuấn', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'153 19/5 Phường Văn Quán Thành phố Hà NộQuận Hà ĐôngThành phố Hà Nội', 1, 2454, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827693', NULL, NULL, N'07Z68NDK600383', N'MAY HUT BUI', N'0.056', N'Hà quốc Đạt', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'F303 Trần hữu dực Phường Xuân Phương ChuQuận Nam Từ LiêmThành phố Hà Nội', 1, 2455, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827694', NULL, NULL, N'07RN4NAK701313', N'TU LANH', N'0.608', N'Đinh thị trinh', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'Ngách 16 ngõ 20 Hồ tùng mậu Phường Mai DQuận Cầu GiấyThành phố Hà Nội', 1, 2456, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827695', NULL, NULL, N'07SM8NEK400021', N'MAY HUT BUI', N'0.056', N'Hoàng Thanh Hằng', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'E2-1405 Chung cư ecohome phúc lợi PhườngQuận Long BiênThành phố Hà Nội', 1, 2457, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827696', NULL, NULL, N'J6UA7WRK700001', N'LO VI SONG', N'0.073', N'Nguyễn hồng phúc', N'HA NOI', NULL, NULL, N'Quận Hà Đông', N'K0405 Yên lộ Phường Yên Nghĩa Xuân mai cQuận Hà ĐôngThành phố Hà Nội', 1, 2458, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827697', NULL, NULL, N'000R4NAK700098', N'TU LANH', N'0.57', N'Trần Thị Thơm', N'HA NOI', NULL, NULL, N'Quận Tây Hồ', N'8 Ngõ 78 Đường Võ Chí Công Phường Xuân LQuận Tây HồThành phố Hà Nội', 1, 2459, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827698', NULL, NULL, N'0D4C4DAK600854', N'TU LANH', N'0.899', N'Phạm Hoàng Long', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'Phòng 2701 Số 349, đường Vũ Tông Phan PhQuận Thanh XuânThành phố Hà Nội', 1, 2460, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827702', NULL, NULL, N'0F764DAK700065', N'TU LANH', N'0.87', N'Phạm Công Tiến', N'HA NOI', NULL, NULL, N'Quận Long Biên', N'1703A Chung cu CT1A thach ban Phường ThạQuận Long BiênThành phố Hà Nội', 1, 2461, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827703', NULL, NULL, N'0ARV7WEK300158', N'LO VI SONG', N'0.076', N'Nguyễn Nam Anh', N'HA NOI', NULL, NULL, N'Quận Thanh Xuân', N'16 Ngõ 273 Phố Vũ Hữu Phường Thanh XuânQuận Thanh XuânThành phố Hà Nội', 1, 2462, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 40000, 0, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827704', NULL, NULL, N'0F764DAK700002', N'TU LANH', N'0.87', N'Tran van hanh', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'Phòng 4010 Đại kim Phường Đại Kim TrungQuận Hoàng MaiThành phố Hà Nội', 1, 2463, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827706', NULL, NULL, N'0EYZ5DBK700136', N'MAY GIAT', N'0.513', N'Mai văn long', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'159 ngõ 63 Lê Đức thọ Phường Mỹ Đình 1 TQuận Nam Từ LiêmThành phố Hà Nội', 1, 2464, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01827707', NULL, NULL, N'0EZ45DBK501258', N'MAY GIAT', N'0.513', N'Mai văn long', N'HA NOI', NULL, NULL, N'Quận Bắc Từ Liêm', N'Ngõ 205 đường phú diễn quận Bắc từ niêmQuận Bắc Từ LiêmThành phố Hà Nội', 1, 2465, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 144000, 0, NULL, CAST(N'2018-08-03 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01826124', NULL, NULL, N'0D4C4DAK600384', N'TU LANH', N'0.899', N'Mai Như Thảo', N'HA NOI', NULL, NULL, N'Quận Nam Từ Liêm', N'Phòng 1203, Chung cu Ecolife Capitol 58-Quận Nam Từ Liêm-Thành phố Hà Nội', 1, 2466, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-02 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01826127', NULL, NULL, N'0F764DAK700232', N'TU LANH', N'0.87', N'Đào Đình Cương', N'HA NOI', NULL, NULL, N'Quận Hoàng Mai', N'Phòng 3506 Chung chư HH2A Linh Đường Phư-Quận Hoàng Mai-Thành phố Hà Nội', 1, 2467, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-08-02 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01826819', NULL, NULL, N'0D4C4DAK600823', N'TU LANH', N'0.899', N'Nguyễn trường quân', N'HA NOI', NULL, NULL, N'Quận Cầu Giấy', N'7 Tôn thất thuyết Phường Dịch Vọng Hậu TQuận Cầu GiấyHA NOI', 1, 2468, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-08-02 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01826820', NULL, NULL, N'0D4C4DAK600856', N'TU LANH', N'0.899', N'Phạm minh cương', N'978365705', NULL, NULL, N'Quận Nam Từ Liêm', N'1 Ngõ 243 Hữu hưng Phường Đại Mỗ Thành pQuận Nam Từ LiêmHA NOI', 1, 2469, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-08-02 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01826821', NULL, NULL, N'0E2D4DAK602060', N'TU LANH', N'0.749', N'Lương Bá Thái', N'1256075433', NULL, NULL, N'Quận Tây Hồ', N'Căn 12A05 tòa C1 chung cư C1C2 Xuân ĐỉnhQuận Tây HồHA NOI', 1, 2470, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-08-02 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01826822', NULL, NULL, N'067P3NHK701653', N'TI VI', N'0.056', N'Mai Thị Nguyệt/Samsung displays vie', N'971478017', NULL, NULL, N'Quận Bắc Từ Liêm', N'khu đô thị greenstar 234 phạm văn đồng PQuận Bắc Từ LiêmHA NOI', 1, 2471, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-08-02 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01826823', NULL, NULL, N'0D4C4DAK600896', N'TU LANH', N'0.899', N'Phạm thị dung', N'964952316', NULL, NULL, N'Quận Thanh Xuân', N'56 Ngõ 132 Khương trung Phường Khương TrQuận Thanh XuânHA NOI', 1, 2472, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 176400, 0, NULL, CAST(N'2018-08-02 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01826831', NULL, NULL, N'067P3NHK701654', N'TI VI', N'0.056', N'anh sang', N'1687234144', NULL, NULL, N'Quận Bắc Từ Liêm', N'03 ngach 31/14 ngo 31 đường cầu diễn- ph-Quận Bắc Từ Liêm-Thành phố Hà Nội', 1, 2473, N'tr1', N'Np', N'29c 97142', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'04', N'04:Mr Kha', NULL, N'', 97200, 0, NULL, CAST(N'2018-08-02 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824526', NULL, NULL, N'0EGDPDCK600554-0EGRPDOK600571', N'DIEU HOA', N'0.094', N'Trần Thị Tâm', N'974641155', NULL, NULL, N'Quận Ba Đình', N'2 ngách 32/2 đường bưởi, Thủ lệ 2 PhườngQuận Ba ĐìnhThành phố Hà Nội', 1, 2474, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 82800, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824577', NULL, NULL, N'05C03NNK700288', N'TI VI', N'0.188', N'NGUYỄN XUÂN NHẬT', N'979288300', NULL, NULL, N'Quận Hoàng Mai', N'Phòng 812 Tòa nhà CT4C-X2 Phường Hoàng LQuận Hoàng MaiThành phố Hà Nội', 1, 2475, N'tr1', N'Np', N'29c 16797', CAST(N'2018-08-12 00:00:00.000' AS DateTime), N'01', N'01:Đỗ Công Hoan', NULL, N'', 97200, 0, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824578', NULL, NULL, N'07U88NBK400006', N'MAY HUT BUI', N'0.063', N'Ngoc Anh', N'916881616', NULL, NULL, N'Quận Đống Đa', N'6 Ngõ 2, Giảng Võ Phường Cát Linh ThànhQuận Đống ĐaThành phố Hà Nội', 1, 2476, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824580', NULL, NULL, N'05C23NDK503126', N'TI VI', N'0.112', N'Vũ Thị Mơ', N'969041184', NULL, NULL, N'Quận Đống Đa', N'16 hẻm 1/33/20 Khâm Thiên Phường Khâm ThQuận Đống ĐaThành phố Hà Nội', 1, 2477, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824581', NULL, NULL, N'0ARV7WEK300162', N'LO VI SONG', N'0.076', N'Ngô Hoàng Phong', N'933556833', NULL, NULL, N'Quận Ba Đình', N'34 Lieu Giai Liễu Giai Phường Liễu GiaiQuận Ba ĐìnhThành phố Hà Nội', 1, 2478, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824584', NULL, NULL, N'0FUK4DAK700010', N'TU LANH', N'1.085', N'Bùi Bích Phương', N'989226490', NULL, NULL, N'Huyện Gia Lâm', N'1 thôn Phù Dực 1, xã Phù Đổng Xã Phù ĐổnHuyện Gia LâmThành phố Hà Nội', 1, 2479, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824585', NULL, NULL, N'0D614DAK700020', N'TU LANH', N'1.085', N'Mai Ngọc Dung', N'975566712', NULL, NULL, N'Huyện Thanh Trì', N'Phòng 1010 nhà CT4 Khu đô thị Hồng Hà EcHuyện Thanh TrìThành phố Hà Nội', 1, 2480, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824586', NULL, NULL, N'07WV8NCK600166', N'MAY HUT BUI', N'0.048', N'ngoc tuan', N'962682883', NULL, NULL, N'Quận Nam Từ Liêm', N'21 NGõ 93- tổ 3 Phường Phú Đô Phú Đô ThàQuận Nam Từ LiêmThành phố Hà Nội', 1, 2481, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824588', NULL, NULL, N'06FN3NDK601505', N'TI VI', N'0.132', N'Trần Thị Tú', N'966012876', NULL, NULL, N'Quận Tây Hồ', N'375 Thủy Khuê Phường Thụy Khuê 375 ThủyQuận Tây HồThành phố Hà Nội', 1, 2482, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 97200, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824590', NULL, NULL, N'07SG8NAK400065', N'MAY HUT BUI', N'0.056', N'Nguyễn Đăng Tùng', N'979599538', NULL, NULL, N'Quận Nam Từ Liêm', N'68 Nguyễn Cơ Thạch Phường Cầu Diễn PhòngQuận Nam Từ LiêmThành phố Hà Nội', 1, 2483, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824596', NULL, NULL, N'0FU74DAK601048', N'TU LANH', N'0.749', N'Mai Thanh Tú', N'1654694830', NULL, NULL, N'Quận Hoàng Mai', N'Đối diện 183 Lĩnh Nam Phường Lĩnh Nam LĩQuận Hoàng MaiThành phố Hà Nội', 1, 2484, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01824604', NULL, NULL, N'08RN4NAK602685', N'TU LANH', N'0.57', N'Dinh Thi Thu Phuong', N'986612090', NULL, NULL, N'CAU GIAY', N'102 B12- PHUONG NGHIA TAN-CAU GIAY-HA NOI', 1, 2485, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01825110', NULL, NULL, N'00124NAJB00008', N'TU LANH', N'0.645', N'Nguyễn Đức Vượng', N'974005513', NULL, NULL, N'Quận Cầu Giấy', N'36 Hồ Tùng Mậu Phường Mai Dịch Khu R4B cQuận Cầu GiấyThành phố Hà Nội', 1, 2486, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01825115', NULL, NULL, N'07UM8NBJB00079', N'MAY HUT BUI', N'0.068', N'Nguyễn Hoàng Thao', N'1668871338', NULL, NULL, N'Huyện Gia Lâm', N'000 Bình Trù Xã Dương Quang Thành phố HàHuyện Gia LâmThành phố Hà Nội', 1, 2487, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 40000, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
INSERT [dbo].[tbl_DonhangtheoSPvaMKH] ([So_van_don], [A/R_Amount], [Material], [Seri], [TEN_HANG], [ShipTo_Name], [ShipTo_Tel], [City], [Deadline], [NOTE], [District], [Dia_chi], [Delivery_Qty], [id], [Username], [macty], [biensoxe], [ngayghepdon], [manhaxe], [tennhaxe], [loaidon], [loadnumber], [Gia_VChuyen], [Tempview], [Gia_Thue], [Ngayvanchuyen], [maKH], [NhomSP]) VALUES (N'HNI01825135', NULL, NULL, N'07UW4NAK600698', N'TU LANH', N'0.57', N'Hoàng Văn Anh', N'976162053', NULL, NULL, N'Quận Cầu Giấy', N'197 Phố Hoa Bằng Phường Yên Hoà Phố HoaQuận Cầu GiấyThành phố Hà Nội', 1, 2488, N'tr1', N'Np', NULL, NULL, NULL, NULL, NULL, N'', 176400, 1, NULL, CAST(N'2018-08-01 00:00:00.000' AS DateTime), N'04', NULL)
SET IDENTITY_INSERT [dbo].[tbl_DonhangtheoSPvaMKH] OFF
SET IDENTITY_INSERT [dbo].[tbl_dstaikhoan] ON 

INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'111       ', N'Tiền mặt                                                                                                                                                                                                                         ', 11, 1, N'          ', N'tien                                              ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1111      ', N'Tiền Việt Nam                                                                                                                                                                                                                    ', 12, 2, N'111       ', N'tien                                              ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1112      ', N'Ngoại tệ                                                                                                                                                                                                                         ', 13, 2, N'111       ', N'tien                                              ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1113      ', N'Vàng tiền tệ                                                                                                                                                                                                                     ', 14, 2, N'111       ', N'tien                                              ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'112       ', N'Tiền gửi Ngân hàng                                                                                                                                                                                                               ', 15, 1, N'          ', N'tien                                              ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1121      ', N'Tiền Việt Nam                                                                                                                                                                                                                    ', 16, 2, N'112       ', N'tien                                              ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1122      ', N'Ngoại tệ                                                                                                                                                                                                                         ', 17, 2, N'112       ', N'tien                                              ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1123      ', N'Vàng tiền tệ                                                                                                                                                                                                                     ', 18, 2, N'112       ', N'tien                                              ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'113       ', N'Tiền đang chuyển                                                                                                                                                                                                                 ', 19, 1, N'          ', N'tien                                              ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1131      ', N'Tiền Việt Nam                                                                                                                                                                                                                    ', 20, 2, N'113       ', N'tien                                              ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1132      ', N'Ngoại tệ                                                                                                                                                                                                                         ', 21, 2, N'113       ', N'tien                                              ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'121       ', N'Chứng khoán kinh doanh                                                                                                                                                                                                           ', 22, 1, N'          ', N'taisan                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1211      ', N'Cổ phiếu                                                                                                                                                                                                                         ', 23, 2, N'121       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1212      ', N'Trái phiếu                                                                                                                                                                                                                       ', 24, 2, N'121       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1218      ', N'Chứng khoán và công cụ tài chính khác                                                                                                                                                                                            ', 25, 2, N'121       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'128       ', N'Đầu tư nắm giữ đến ngày đáo hạn                                                                                                                                                                                                  ', 26, 1, N'          ', N'taisan                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1281      ', N'Tiền gửi có kỳ hạn                                                                                                                                                                                                               ', 27, 2, N'128       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1282      ', N'Trái phiếu                                                                                                                                                                                                                       ', 28, 2, N'128       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1283      ', N'Cho vay                                                                                                                                                                                                                          ', 29, 2, N'128       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1288      ', N'Các khoản đầu tư khác nắm giữ đến ngày đáo hạn                                                                                                                                                                                   ', 30, 2, N'128       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'131       ', N'Phải thu của khách hàng                                                                                                                                                                                                          ', 31, 1, N'          ', N'phaithu                                           ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'133       ', N'Thuế GTGT được khấu trừ                                                                                                                                                                                                          ', 32, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1331      ', N'Thuế GTGT được khấu trừ của hàng hóa, dịch vụ                                                                                                                                                                                    ', 33, 2, N'133       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1332      ', N'Thuế GTGT được khấu trừ của TSCĐ                                                                                                                                                                                                 ', 34, 2, N'133       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'136       ', N'Phải thu nội bộ                                                                                                                                                                                                                  ', 35, 1, N'          ', N'phaithu                                           ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1361      ', N'Vốn kinh doanh ở các đơn vị trực thuộc                                                                                                                                                                                           ', 36, 2, N'136       ', N'phaithu                                           ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1362      ', N'Phải thu nội bộ về chênh lệch tỷ giá                                                                                                                                                                                             ', 37, 2, N'136       ', N'phaithu                                           ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1363      ', N'Phải thu nội bộ về chi phí đi vay đủ điều kiện được vốn hoá                                                                                                                                                                      ', 38, 2, N'136       ', N'phaithu                                           ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1368      ', N'Phải thu nội bộ khác                                                                                                                                                                                                             ', 39, 2, N'136       ', N'phaithu                                           ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'138       ', N'Phải thu khác                                                                                                                                                                                                                    ', 40, 1, N'          ', N'phaithu                                           ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1381      ', N'Tài sản thiếu chờ xử lý                                                                                                                                                                                                          ', 41, 2, N'138       ', N'phaithu                                           ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1385      ', N'Phải thu về cổ phần hoá                                                                                                                                                                                                          ', 42, 2, N'138       ', N'phaithu                                           ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1388      ', N'Phải thu khác                                                                                                                                                                                                                    ', 43, 2, N'138       ', N'phaithu                                           ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'141       ', N'Tạm ứng                                                                                                                                                                                                                          ', 44, 1, N'          ', N'tamung                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'151       ', N'Hàng mua đang đi đường                                                                                                                                                                                                           ', 45, 1, N'          ', N'taisan                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'152       ', N'Nguyên liệu, vật liệu                                                                                                                                                                                                            ', 46, 1, N'          ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'153       ', N'Công cụ, dụng cụ                                                                                                                                                                                                                 ', 47, 1, N'          ', N'kho                                               ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1531      ', N'Công cụ, dụng cụ                                                                                                                                                                                                                 ', 48, 2, N'153       ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1532      ', N'Bao bì luân chuyển                                                                                                                                                                                                               ', 49, 2, N'153       ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1533      ', N'Đồ dùng cho thuê                                                                                                                                                                                                                 ', 50, 2, N'153       ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1534      ', N'Thiết bị, phụ tùng thay thế                                                                                                                                                                                                      ', 51, 2, N'153       ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'154       ', N'Chi phí sản xuất, kinh doanh dở dang                                                                                                                                                                                             ', 52, 1, N'          ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'155       ', N'Thành phẩm                                                                                                                                                                                                                       ', 53, 1, N'          ', N'kho                                               ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1551      ', N'Thành phẩm nhập kho                                                                                                                                                                                                              ', 54, 2, N'155       ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1557      ', N'Thành phẩm bất động sản                                                                                                                                                                                                          ', 55, 2, N'155       ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'156       ', N'Hàng hóa                                                                                                                                                                                                                         ', 56, 1, N'          ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1561      ', N'Giá mua hàng hóa                                                                                                                                                                                                                 ', 57, 2, N'156       ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1562      ', N'Chi phí thu mua hàng hóa                                                                                                                                                                                                         ', 58, 2, N'156       ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1567      ', N'Hàng hóa bất động sản                                                                                                                                                                                                            ', 59, 2, N'156       ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'157       ', N'Hàng gửi đi bán                                                                                                                                                                                                                  ', 60, 1, N'          ', N'kho                                               ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'158       ', N'Hàng hoá kho bảo thuế                                                                                                                                                                                                            ', 61, 1, N'          ', N'kho                                               ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'161       ', N'Chi sự nghiệp                                                                                                                                                                                                                    ', 62, 1, N'          ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'1612      ', N'Chi sự nghiệp năm nay                                                                                                                                                                                                            ', 63, 1, N'          ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'171       ', N'Giao dịch mua bán lại trái phiếu chính phủ                                                                                                                                                                                       ', 64, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'211       ', N'Tài sản cố định hữu hình                                                                                                                                                                                                         ', 65, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2111      ', N'Nhà cửa, vật kiến trúc                                                                                                                                                                                                           ', 66, 2, N'211       ', N'taisan                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2112      ', N'Máy móc, thiết bị                                                                                                                                                                                                                ', 67, 1, N'          ', N'taisan                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2113      ', N'Phương tiện vận tải, truyền dẫn                                                                                                                                                                                                  ', 68, 2, N'211       ', N'taisan                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2114      ', N'Thiết bị, dụng cụ quản lý                                                                                                                                                                                                        ', 69, 2, N'211       ', N'taisan                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2115      ', N'Cây lâu năm, súc vật làm việc và cho sản phẩm                                                                                                                                                                                    ', 70, 1, N'          ', N'taisan                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2118      ', N'TSCĐ khác                                                                                                                                                                                                                        ', 71, 1, N'          ', N'taisan                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'212       ', N'Tài sản cố định thuê tài chính                                                                                                                                                                                                   ', 72, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2121      ', N'TSCĐ hữu hình thuê tài chính.                                                                                                                                                                                                    ', 73, 2, N'212       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2122      ', N'TSCĐ vô hình thuê tài chính                                                                                                                                                                                                      ', 74, 2, N'212       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'213       ', N'Tài sản cố định vô hình                                                                                                                                                                                                          ', 75, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2131      ', N'Quyền sử dụng đất                                                                                                                                                                                                                ', 76, 2, N'213       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2132      ', N'Quyền phát hành                                                                                                                                                                                                                  ', 77, 2, N'213       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2133      ', N'Bản quyền, bằng sáng chế                                                                                                                                                                                                         ', 78, 2, N'213       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2134      ', N'Nhãn hiệu, tên thương mại                                                                                                                                                                                                        ', 79, 2, N'213       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2135      ', N'Chương trình phần mềm                                                                                                                                                                                                            ', 80, 2, N'213       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2136      ', N'Giấy phép và giấy phép nhượng quyền                                                                                                                                                                                              ', 81, 2, N'213       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2138      ', N'TSCĐ vô hình khác                                                                                                                                                                                                                ', 82, 2, N'213       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'214       ', N'Hao mòn tài sản cố định                                                                                                                                                                                                          ', 83, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2141      ', N'Hao mòn TSCĐ hữu hình                                                                                                                                                                                                            ', 84, 2, N'214       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2142      ', N'Hao mòn TSCĐ thuê tài chính                                                                                                                                                                                                      ', 85, 2, N'214       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2143      ', N'Hao mòn TSCĐ vô hình                                                                                                                                                                                                             ', 86, 2, N'214       ', N'nguonvon                                          ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2147      ', N'Hao mòn bất động sản đầu tư                                                                                                                                                                                                      ', 87, 2, N'214       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'217       ', N'Bất động sản đầu tư                                                                                                                                                                                                              ', 88, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'221       ', N'Đầu tư vào công ty con                                                                                                                                                                                                           ', 89, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'222       ', N'Đầu tư vào công ty liên doanh, liên kết                                                                                                                                                                                          ', 90, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'228       ', N'Đầu tư khác                                                                                                                                                                                                                      ', 91, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2281      ', N'Đầu tư góp vốn vào đơn vị khác                                                                                                                                                                                                   ', 92, 2, N'228       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2288      ', N'Đầu tư khác                                                                                                                                                                                                                      ', 93, 2, N'228       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'229       ', N'Dự phòng tổn thất tài sản                                                                                                                                                                                                        ', 94, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2291      ', N'Dự phòng giảm giá chứng khoán kinh doanh                                                                                                                                                                                         ', 95, 2, N'229       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2292      ', N'Dự phòng tổn thất đầu tư vào đơn vị khác                                                                                                                                                                                         ', 96, 2, N'229       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2293      ', N'Dự phòng phải thu khó đòi                                                                                                                                                                                                        ', 97, 2, N'229       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2294      ', N'Dự phòng giảm giá hàng tồn kho                                                                                                                                                                                                   ', 98, 2, N'229       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'241       ', N'Xây dựng cơ bản dở dang                                                                                                                                                                                                          ', 99, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2411      ', N'Mua sắm TSCĐ                                                                                                                                                                                                                     ', 100, 2, N'241       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2412      ', N'Xây dựng cơ bản                                                                                                                                                                                                                  ', 101, 2, N'241       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'2413      ', N'Sửa chữa lớn TSCĐ                                                                                                                                                                                                                ', 102, 2, N'241       ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'242       ', N'Chi phí trả trước                                                                                                                                                                                                                ', 103, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'243       ', N'Tài sản thuế thu nhập hoãn lại                                                                                                                                                                                                   ', 104, 1, N'          ', N'taisan                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'244       ', N'Cầm cố, thế chấp, ký quỹ, ký cược                                                                                                                                                                                                ', 105, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'331       ', N'Phải trả cho người bán                                                                                                                                                                                                           ', 106, 1, N'          ', N'phaitra                                           ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'333       ', N'Thuế và các khoản phải nộp Nhà nước                                                                                                                                                                                              ', 107, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3331      ', N'Thuế giá trị gia tăng phải nộp                                                                                                                                                                                                   ', 108, 2, N'333       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'33311     ', N'Thuế GTGT đầu ra                                                                                                                                                                                                                 ', 109, 3, N'3331      ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'33312     ', N'Thuế GTGT hàng nhập khẩu                                                                                                                                                                                                         ', 110, 3, N'3331      ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3332      ', N'Thuế tiêu thụ đặc biệt                                                                                                                                                                                                           ', 111, 2, N'333       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3333      ', N'Thuế xuất, nhập khẩu                                                                                                                                                                                                             ', 112, 2, N'333       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3334      ', N'Thuế thu nhập doanh nghiệp                                                                                                                                                                                                       ', 113, 2, N'333       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3335      ', N'Thuế thu nhập cá nhân                                                                                                                                                                                                            ', 114, 2, N'333       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3336      ', N'Thuế tài nguyên                                                                                                                                                                                                                  ', 115, 2, N'333       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3337      ', N'Thuế nhà đất, tiền thuê đất                                                                                                                                                                                                      ', 116, 2, N'333       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3338      ', N'Thuế bảo vệ môi trường và các loại thuế khác                                                                                                                                                                                     ', 117, 2, N'333       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'33381     ', N'Thuế bảo vệ môi trường                                                                                                                                                                                                           ', 118, 3, N'3338      ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'33382     ', N'Các loại thuế khác                                                                                                                                                                                                               ', 119, 3, N'3338      ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3339      ', N'Phí, lệ phí và các khoản phải nộp khác                                                                                                                                                                                           ', 120, 2, N'333       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'334       ', N'Phải trả người lao động                                                                                                                                                                                                          ', 121, 1, N'          ', N'nguonvon                                          ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3341      ', N'Phải trả công nhân viên                                                                                                                                                                                                          ', 122, 2, N'334       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3348      ', N'Phải trả người lao động khác                                                                                                                                                                                                     ', 123, 2, N'334       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'335       ', N'Chi phí phải trả                                                                                                                                                                                                                 ', 124, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'336       ', N'Phải trả nội bộ                                                                                                                                                                                                                  ', 125, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3361      ', N'Phải trả nội bộ về vốn kinh doanh                                                                                                                                                                                                ', 126, 2, N'336       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3362      ', N'Phải trả nội bộ về chênh lệch tỷ giá                                                                                                                                                                                             ', 127, 2, N'336       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3363      ', N'Phải trả nội bộ về chi phí đi vay đủ điều kiện được vốn hoá                                                                                                                                                                      ', 128, 2, N'336       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3368      ', N'Phải trả nội bộ khác                                                                                                                                                                                                             ', 129, 2, N'336       ', N'nguonvon                                          ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'337       ', N'Thanh toán theo tiến độ kế hoạch hợp đồng xây dựng                                                                                                                                                                               ', 130, 1, N'          ', N'nguonvon                                          ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'338       ', N'Phải trả, phải nộp khác                                                                                                                                                                                                          ', 131, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3381      ', N'Tài sản thừa chờ giải quyết                                                                                                                                                                                                      ', 132, 2, N'338       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3382      ', N'Kinh phí công đoàn                                                                                                                                                                                                               ', 133, 2, N'338       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3383      ', N'Bảo hiểm xã hội                                                                                                                                                                                                                  ', 134, 2, N'338       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3384      ', N'Bảo hiểm y tế                                                                                                                                                                                                                    ', 135, 2, N'338       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3385      ', N'Phải trả về cổ phần hoá                                                                                                                                                                                                          ', 136, 2, N'338       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3386      ', N'Bảo hiểm thất nghiệp                                                                                                                                                                                                             ', 137, 2, N'338       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3387      ', N'Doanh thu chưa thực hiện                                                                                                                                                                                                         ', 138, 2, N'338       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3388      ', N'Phải trả, phải nộp khác                                                                                                                                                                                                          ', 139, 2, N'338       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'341       ', N'Vay và nợ thuê tài chính                                                                                                                                                                                                         ', 140, 1, N'          ', N'nguonvon                                          ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3411      ', N'Các khoản đi vay                                                                                                                                                                                                                 ', 141, 2, N'341       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3412      ', N'Nợ thuê tài chính                                                                                                                                                                                                                ', 142, 2, N'341       ', N'nguonvon                                          ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'343       ', N'Trái phiếu phát hành                                                                                                                                                                                                             ', 143, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3431      ', N'Trái phiếu thường                                                                                                                                                                                                                ', 144, 2, N'343       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'34311     ', N'Mệnh giá trái phiếu                                                                                                                                                                                                              ', 145, 3, N'3431      ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'34312     ', N'Chiết khấu trái phiếu                                                                                                                                                                                                            ', 146, 3, N'3431      ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'34313     ', N'Phụ trội trái phiếu                                                                                                                                                                                                              ', 147, 3, N'3431      ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'344       ', N'Nhận ký quỹ, ký cược                                                                                                                                                                                                             ', 148, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'347       ', N'Thuế thu nhập hoãn lại phải trả                                                                                                                                                                                                  ', 149, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'352       ', N'Dự phòng phải trả                                                                                                                                                                                                                ', 150, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3521      ', N'Dự phòng bảo hành sản phẩm hàng hóa                                                                                                                                                                                              ', 151, 2, N'352       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3522      ', N'Dự phòng bảo hành công trình xây dựng                                                                                                                                                                                            ', 152, 2, N'352       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3523      ', N'Dự phòng tái cơ cấu doanh nghiệp                                                                                                                                                                                                 ', 153, 2, N'352       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3524      ', N'Dự phòng phải trả khác                                                                                                                                                                                                           ', 154, 2, N'352       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'353       ', N'Quỹ khen thưởng phúc lợi                                                                                                                                                                                                         ', 155, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3531      ', N'Quỹ khen thưởng                                                                                                                                                                                                                  ', 156, 2, N'353       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3532      ', N'Quỹ phúc lợi                                                                                                                                                                                                                     ', 157, 2, N'353       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3533      ', N'Quỹ phúc lợi đã hình thành TSCĐ                                                                                                                                                                                                  ', 158, 2, N'353       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3534      ', N'Quỹ thưởng ban quản lý điều hành công ty                                                                                                                                                                                         ', 159, 2, N'353       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'356       ', N'Quỹ phát triển khoa học và công nghệ                                                                                                                                                                                             ', 160, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3561      ', N'Quỹ phát triển khoa học và công nghệ                                                                                                                                                                                             ', 161, 2, N'356       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'3562      ', N'Quỹ phát triển khoa học và công nghệ đã hình thành TSCĐ                                                                                                                                                                          ', 162, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'357       ', N'Quỹ bình ổn giá                                                                                                                                                                                                                  ', 163, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'411       ', N'Vốn đầu tư của chủ sở hữu                                                                                                                                                                                                        ', 164, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'4111      ', N'Vốn góp của chủ sở hữu                                                                                                                                                                                                           ', 165, 2, N'411       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'41111     ', N'Cổ phiếu phổ thông có quyền biểu quyết                                                                                                                                                                                           ', 166, 3, N'4111      ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'41112     ', N'Cổ phiếu ưu đãi                                                                                                                                                                                                                  ', 167, 3, N'4111      ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'4112      ', N'Thặng dư vốn cổ phần                                                                                                                                                                                                             ', 168, 2, N'411       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'4113      ', N'Quyền chọn chuyển đổi trái phiếu                                                                                                                                                                                                 ', 169, 2, N'411       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'4118      ', N'Vốn khác                                                                                                                                                                                                                         ', 170, 2, N'411       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'412       ', N'Chênh lệch đánh giá lại tài sản                                                                                                                                                                                                  ', 171, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'413       ', N'Chênh lệch tỷ giá hối đoái                                                                                                                                                                                                       ', 172, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'4131      ', N'Chênh lệch tỷ giá do đánh giá lại các khoản mục tiền tệ có gốc ngoại tệ                                                                                                                                                          ', 173, 2, N'413       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'4132      ', N'Chênh lệch tỷ giá hối đoái trong giai đoạn trước hoạt động                                                                                                                                                                       ', 174, 2, N'413       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'414       ', N'Quỹ đầu tư phát triển                                                                                                                                                                                                            ', 175, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'417       ', N'Quỹ hỗ trợ sắp xếp doanh nghiệp                                                                                                                                                                                                  ', 176, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'418       ', N'Các quỹ khác thuộc vốn chủ sở hữu                                                                                                                                                                                                ', 177, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'419       ', N'Cổ phiếu quỹ                                                                                                                                                                                                                     ', 178, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'421       ', N'Lợi nhuận sau thuế chưa phân phối                                                                                                                                                                                                ', 179, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'4211      ', N'Lợi nhuận sau thuế chưa phân phối năm trước                                                                                                                                                                                      ', 180, 2, N'421       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'4212      ', N'Lợi nhuận sau thuế chưa phân phối năm nay                                                                                                                                                                                        ', 181, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'441       ', N'Nguồn vốn đầu tư xây dựng cơ bản                                                                                                                                                                                                 ', 182, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'461       ', N'Nguồn kinh phí sự nghiệp                                                                                                                                                                                                         ', 183, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'4611      ', N'Nguồn kinh phí sự nghiệp năm trước                                                                                                                                                                                               ', 184, 2, N'461       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'4612      ', N'Nguồn kinh phí sự nghiệp năm nay                                                                                                                                                                                                 ', 185, 2, N'461       ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'466       ', N'Nguồn kinh phí đã hình thành TSCĐ                                                                                                                                                                                                ', 186, 1, N'          ', N'nguonvon                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'511       ', N'Doanh thu bán hàng và cung cấp dịch vụ                                                                                                                                                                                           ', 187, 1, N'          ', N'doanhthu                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'5111      ', N'Doanh thu bán hàng hóa                                                                                                                                                                                                           ', 188, 2, N'511       ', N'doanhthu                                          ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'5112      ', N'Doanh thu bán các thành phẩm                                                                                                                                                                                                     ', 189, 2, N'511       ', N'doanhthu                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'5113      ', N'Doanh thu cung cấp dịch vụ                                                                                                                                                                                                       ', 190, 2, N'511       ', N'doanhthu                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'5114      ', N'Doanh thu trợ cấp, trợ giá                                                                                                                                                                                                       ', 191, 2, N'511       ', N'doanhthu                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'5117      ', N'Doanh thu kinh doanh bất động sản đầu tư                                                                                                                                                                                         ', 192, 2, N'511       ', N'doanhthu                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'5118      ', N'Doanh thu khác                                                                                                                                                                                                                   ', 193, 2, N'511       ', N'doanhthu                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'515       ', N'Doanh thu hoạt động tài chính                                                                                                                                                                                                    ', 194, 1, N'          ', N'doanhthu                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'521       ', N'Các khoản giảm trừ doanh thu                                                                                                                                                                                                     ', 195, 1, N'          ', N'doanhthu                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'5211      ', N'Chiết khấu thương mại                                                                                                                                                                                                            ', 196, 2, N'521       ', N'doanhthu                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'5212      ', N'Giảm giá hàng bán                                                                                                                                                                                                                ', 197, 2, N'521       ', N'doanhthu                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'5213      ', N'Hàng bán bị trả lại                                                                                                                                                                                                              ', 198, 2, N'521       ', N'doanhthu                                          ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'611       ', N'Mua hàng                                                                                                                                                                                                                         ', 199, 1, N'          ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6111      ', N'Mua nguyên liệu, vật liệu                                                                                                                                                                                                        ', 200, 2, N'611       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6112      ', N'Mua hàng hóa                                                                                                                                                                                                                     ', 201, 2, N'611       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'622       ', N'Chi phí nhân công trực tiếp                                                                                                                                                                                                      ', 202, 1, N'          ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'623       ', N'Chi phí sử dụng máy thi công                                                                                                                                                                                                     ', 203, 1, N'          ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6231      ', N'Chi phí nhân công                                                                                                                                                                                                                ', 204, 2, N'623       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6232      ', N'Chi phí nguyên, vật liệu                                                                                                                                                                                                         ', 205, 2, N'623       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6233      ', N'Chi phí dụng cụ sản xuất                                                                                                                                                                                                         ', 206, 2, N'623       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6234      ', N'Chi phí khấu hao máy thi công                                                                                                                                                                                                    ', 207, 2, N'623       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6237      ', N'Chi phí dịch vụ mua ngoài                                                                                                                                                                                                        ', 208, 2, N'623       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6238      ', N'Chi phí bằng tiền khác                                                                                                                                                                                                           ', 209, 2, N'623       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'627       ', N'Chi phí sản xuất chung                                                                                                                                                                                                           ', 210, 1, N'          ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6271      ', N'Chi phí nhân viên phân xưởng                                                                                                                                                                                                     ', 211, 2, N'627       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6272      ', N'Chi phí nguyên, vật liệu                                                                                                                                                                                                         ', 212, 2, N'627       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6273      ', N'Chi phí dụng cụ sản xuất                                                                                                                                                                                                         ', 213, 2, N'627       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6274      ', N'Chi phí khấu hao TSCĐ                                                                                                                                                                                                            ', 214, 2, N'627       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6277      ', N'Chi phí dịch vụ mua ngoài                                                                                                                                                                                                        ', 215, 2, N'627       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6278      ', N'Chi phí bằng tiền khác                                                                                                                                                                                                           ', 216, 2, N'627       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'631       ', N'Giá thành sản xuất                                                                                                                                                                                                               ', 217, 1, N'          ', N'chiphi                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'632       ', N'Giá vốn hàng bán                                                                                                                                                                                                                 ', 218, 1, N'          ', N'chiphi                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'635       ', N'Chi phí tài chính                                                                                                                                                                                                                ', 219, 1, N'          ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'641       ', N'Chi phí bán hàng                                                                                                                                                                                                                 ', 220, 1, N'          ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6411      ', N'Chi phí nhân viên                                                                                                                                                                                                                ', 221, 2, N'641       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6412      ', N'Chi phí nguyên vật liệu, bao bì                                                                                                                                                                                                  ', 222, 2, N'641       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6413      ', N'Chi phí dụng cụ, đồ dùng                                                                                                                                                                                                         ', 223, 2, N'641       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6414      ', N'Chi phí khấu hao TSCĐ                                                                                                                                                                                                            ', 224, 2, N'641       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6415      ', N'Chi phí bảo hành                                                                                                                                                                                                                 ', 225, 2, N'641       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6417      ', N'Chi phí dịch vụ mua ngoài                                                                                                                                                                                                        ', 226, 2, N'641       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6418      ', N'Chi phí bằng tiền khác                                                                                                                                                                                                           ', 227, 2, N'641       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'642       ', N'Chi phí quản lý doanh nghiệp                                                                                                                                                                                                     ', 228, 1, N'          ', N'chiphi                                            ', 1, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6421      ', N'Chi phí nhân viên quản lý                                                                                                                                                                                                        ', 229, 2, N'642       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6422      ', N'Chi phí vật liệu quản lý                                                                                                                                                                                                         ', 230, 2, N'642       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6423      ', N'Chi phí đồ dùng văn phòng                                                                                                                                                                                                        ', 231, 2, N'642       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6424      ', N'Chi phí khấu hao TSCĐ                                                                                                                                                                                                            ', 232, 2, N'642       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6425      ', N'Thuế, phí và lệ phí                                                                                                                                                                                                              ', 233, 2, N'642       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6426      ', N'Chi phí dự phòng                                                                                                                                                                                                                 ', 234, 2, N'642       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6427      ', N'Chi phí dịch vụ mua ngoài                                                                                                                                                                                                        ', 235, 2, N'642       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'6428      ', N'Chi phí bằng tiền khác                                                                                                                                                                                                           ', 236, 2, N'642       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'811       ', N'Chi phí khác                                                                                                                                                                                                                     ', 237, 1, N'          ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'821       ', N'Chi phí thuế thu nhập doanh nghiệp                                                                                                                                                                                               ', 238, 1, N'          ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'8211      ', N'Chi phí thuế TNDN hiện hành                                                                                                                                                                                                      ', 239, 2, N'821       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'8212      ', N'Chi phí thuế TNDN hoãn lại                                                                                                                                                                                                       ', 240, 2, N'821       ', N'chiphi                                            ', 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_dstaikhoan] ([matk], [tentk], [id], [captk], [matktren], [loaitkid], [loaichitiet], [nodk], [codk], [maKQKD], [maCDKT], [maLCTT]) VALUES (N'911       ', N'Xác định kết quả kinh doanh                                                                                                                                                                                                      ', 241, 1, N'          ', N'xacdinhkqkd                                       ', 1, 0, 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_dstaikhoan] OFF
SET IDENTITY_INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ON 

INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Huyện Thanh Trì', N'DIEU HOA', 82800, CAST(N'2018-06-27 00:00:00.000' AS DateTime), CAST(N'2118-06-27 00:00:00.000' AS DateTime), NULL, N'Np', 21, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Quận Long Biên', N'LO VI SONG', 40000, CAST(N'2018-06-27 00:00:00.000' AS DateTime), CAST(N'2118-06-27 00:00:00.000' AS DateTime), NULL, N'Np', 22, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Quận Ba Đình', N'MAY GIAT', 144000, CAST(N'2018-06-27 00:00:00.000' AS DateTime), CAST(N'2118-06-27 00:00:00.000' AS DateTime), NULL, N'Np', 23, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Huyện Đan Phượng', N'TI VI', 97200, CAST(N'2018-06-27 00:00:00.000' AS DateTime), CAST(N'2118-06-27 00:00:00.000' AS DateTime), NULL, N'Np', 24, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Quận Nam Từ Liêm', N'TU LANH', 176400, CAST(N'2018-06-27 00:00:00.000' AS DateTime), CAST(N'2118-06-27 00:00:00.000' AS DateTime), NULL, N'Np', 25, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Quận Đống Đa', N'2 BO CHAN GA COTTON EVERON', 97200, CAST(N'2018-06-27 00:00:00.000' AS DateTime), CAST(N'2118-06-27 00:00:00.000' AS DateTime), NULL, N'Np', 26, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Huyện Đan Phượng', N'BO CHAN GA COTTON EVERON', 97200, CAST(N'2018-06-27 00:00:00.000' AS DateTime), CAST(N'2118-06-27 00:00:00.000' AS DateTime), NULL, N'Np', 27, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Quận Hoàng Mai', N'MAY HUT BUI', 40000, CAST(N'2018-06-28 00:00:00.000' AS DateTime), CAST(N'2118-06-28 00:00:00.000' AS DateTime), NULL, N'Np', 30, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Huyện Thanh Trì', N'LOA', 40000, CAST(N'2018-07-12 00:00:00.000' AS DateTime), CAST(N'2118-07-12 00:00:00.000' AS DateTime), NULL, N'Np', 32, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Huyện Đông Anh', N'MAN HINH', 97200, CAST(N'2018-07-12 00:00:00.000' AS DateTime), CAST(N'2118-07-12 00:00:00.000' AS DateTime), NULL, N'Np', 33, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Huyện Mê Linh', N'2 BỘ DH', 82800, CAST(N'2018-07-16 00:00:00.000' AS DateTime), CAST(N'2118-07-16 00:00:00.000' AS DateTime), NULL, N'Np', 34, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Huyện Đông Anh', N'2 BỘ ĐH', 82800, CAST(N'2018-07-30 00:00:00.000' AS DateTime), CAST(N'2118-07-30 00:00:00.000' AS DateTime), NULL, N'Np', 35, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Quận Đống Đa', N'2 TI VI', 97200, CAST(N'2018-08-12 00:00:00.000' AS DateTime), CAST(N'2118-08-12 00:00:00.000' AS DateTime), NULL, N'Np', 36, NULL, NULL, NULL)
INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] ([City], [District], [TENHANG], [Gia], [Fromdate], [Todate], [Username], [macty], [id], [maKH], [NhomSP], [maSP]) VALUES (N'HA NOI', N'Quận Cầu Giấy', N'2 TU LANH', 176400, CAST(N'2018-08-12 00:00:00.000' AS DateTime), CAST(N'2118-08-12 00:00:00.000' AS DateTime), NULL, N'Np', 37, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_GiaHDtheoMCTvaSP] OFF
SET IDENTITY_INSERT [dbo].[tbl_kho_nhomsanpham] ON 

INSERT [dbo].[tbl_kho_nhomsanpham] ([manhomsanpham], [tennhomsanpham], [id]) VALUES (N'1         ', N'sON', 1)
INSERT [dbo].[tbl_kho_nhomsanpham] ([manhomsanpham], [tennhomsanpham], [id]) VALUES (N'2         ', N'pHẤN', 2)
SET IDENTITY_INSERT [dbo].[tbl_kho_nhomsanpham] OFF
SET IDENTITY_INSERT [dbo].[tbl_kho_phieunhap_detail] ON 

INSERT [dbo].[tbl_kho_phieunhap_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongnhap], [subid], [makho], [ngayphieunhap], [macty]) VALUES (N'123123213', N'Son ', N'Cây', 12, 144, 1, N'1', NULL, 12, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_kho_phieunhap_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongnhap], [subid], [makho], [ngayphieunhap], [macty]) VALUES (N'ádfasdf31123', N'phấn', N'cây', 12, 144, 2, N'2', NULL, 12, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_kho_phieunhap_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongnhap], [subid], [makho], [ngayphieunhap], [macty]) VALUES (N'123123213', N'Son ', N'Cây', 24, 288, 4, N'34', NULL, 12, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_kho_phieunhap_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongnhap], [subid], [makho], [ngayphieunhap], [macty]) VALUES (N'ádfasdf31123', N'phấn', N'cây', 12, 144, 7, N'341', NULL, 12, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_kho_phieunhap_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongnhap], [subid], [makho], [ngayphieunhap], [macty]) VALUES (N'ádfasdf31123', N'phấn', N'cây', 12, 144, 8, N'341', NULL, 12, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_kho_phieunhap_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongnhap], [subid], [makho], [ngayphieunhap], [macty]) VALUES (N'ádfasdf31123', N'phấn', N'cây', 12, 144, 9, N'341', NULL, 12, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_kho_phieunhap_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongnhap], [subid], [makho], [ngayphieunhap], [macty]) VALUES (N'ádfasdf31123', N'phấn', N'cây', 12, 144, 10, N'341', NULL, 12, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_kho_phieunhap_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongnhap], [subid], [makho], [ngayphieunhap], [macty]) VALUES (N'ádfasdf31123', N'phấn', N'cây', 12, 144, 11, N'341', NULL, 12, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_kho_phieunhap_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongnhap], [subid], [makho], [ngayphieunhap], [macty]) VALUES (N'ádfasdf31123', N'phấn', N'cây', 1212, 14544, 89, N'14', NULL, 12, NULL, N'SH', CAST(N'2018-04-23 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbl_kho_phieunhap_detail] OFF
SET IDENTITY_INSERT [dbo].[tbl_kho_phieunhap_head] ON 

INSERT [dbo].[tbl_kho_phieunhap_head] ([ngayphieunhap], [nguoigiao], [theodonhang], [makho], [hoadondikhem], [notk], [cotk], [createby], [createdate], [id], [phieuso], [MaCTietTKCo], [MaCTietTKNo], [diengiai], [sotien], [TenCTietTKCo], [TenCTietTKNo], [tenkho], [macty]) VALUES (CAST(N'2018-04-23 00:00:00.000' AS DateTime), N'qưer', N'ửeqwe', N'SH', N'1', N'152       ', N'1283      ', N'tr1', CAST(N'2018-04-23 00:00:00.000' AS DateTime), 33, N'14', NULL, NULL, N'qewrqewr', 14544, N'', N'', N'Kho sH', NULL)
SET IDENTITY_INSERT [dbo].[tbl_kho_phieunhap_head] OFF
SET IDENTITY_INSERT [dbo].[tbl_kho_phieuxuat_detail] ON 

INSERT [dbo].[tbl_kho_phieuxuat_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongxuat], [subid], [makho], [ngayphieuxuat], [macty]) VALUES (N'34eadÁ', N'ZCZXC', N'cÁI', 212, 2544, 40, N'12', NULL, 12, NULL, N'SH', CAST(N'2018-04-23 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tbl_kho_phieuxuat_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongxuat], [subid], [makho], [ngayphieuxuat], [macty]) VALUES (N'ádfasdf31123', N'phấn', N'cây', 1212, 14544, 41, N'13', NULL, 12, NULL, N'SH', CAST(N'2018-04-23 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tbl_kho_phieuxuat_detail] ([mahang], [tenhang], [donvi], [dongia], [thanhtien], [id], [phieuso], [soluongyeucau], [soluongxuat], [subid], [makho], [ngayphieuxuat], [macty]) VALUES (N'ádfasdf31123', N'phấn', N'cây', 132123, 1585476, 42, N'234', NULL, 12, NULL, N'SH', CAST(N'2018-06-20 00:00:00.000' AS DateTime), N'Np')
SET IDENTITY_INSERT [dbo].[tbl_kho_phieuxuat_detail] OFF
SET IDENTITY_INSERT [dbo].[tbl_kho_phieuxuat_head] ON 

INSERT [dbo].[tbl_kho_phieuxuat_head] ([ngayphieuxuat], [nguoinhanhang], [diachibophan], [makho], [hoadondikhem], [notk], [cotk], [createby], [createdate], [id], [phieuso], [MaCTietTKCo], [MaCTietTKNo], [diengiai], [sotien], [TenCTietTKCo], [TenCTietTKNo], [tenkho], [macty]) VALUES (CAST(N'2018-04-23 00:00:00.000' AS DateTime), N'adADS', N'adssDA', N'SH', N'2', N'131       ', N'158       ', N'tr1', CAST(N'2018-04-23 00:00:00.000' AS DateTime), 28, N'12', NULL, 3, N'ads', 2544, N'', N'Aba', N'Kho sH', NULL)
INSERT [dbo].[tbl_kho_phieuxuat_head] ([ngayphieuxuat], [nguoinhanhang], [diachibophan], [makho], [hoadondikhem], [notk], [cotk], [createby], [createdate], [id], [phieuso], [MaCTietTKCo], [MaCTietTKNo], [diengiai], [sotien], [TenCTietTKCo], [TenCTietTKNo], [tenkho], [macty]) VALUES (CAST(N'2018-04-23 00:00:00.000' AS DateTime), N'ádfasdf', N'ádfasdf', N'SH', N'adsfsdaf', N'1212      ', N'153       ', N'tr1', CAST(N'2018-04-23 00:00:00.000' AS DateTime), 29, N'13', NULL, NULL, N'ádfasdf', 14544, N'', N'', N'Kho sH', NULL)
INSERT [dbo].[tbl_kho_phieuxuat_head] ([ngayphieuxuat], [nguoinhanhang], [diachibophan], [makho], [hoadondikhem], [notk], [cotk], [createby], [createdate], [id], [phieuso], [MaCTietTKCo], [MaCTietTKNo], [diengiai], [sotien], [TenCTietTKCo], [TenCTietTKNo], [tenkho], [macty]) VALUES (CAST(N'2018-06-20 00:00:00.000' AS DateTime), N'ádfsdaf', N'ádfasdf', N'SH', N'2', N'1212      ', N'152       ', N'tr1', CAST(N'2018-06-20 00:00:00.000' AS DateTime), 30, N'234', NULL, NULL, N'ádfdasf', 1585476, N'', N'', N'Kho sH', N'Np')
SET IDENTITY_INSERT [dbo].[tbl_kho_phieuxuat_head] OFF
SET IDENTITY_INSERT [dbo].[tbl_kho_sanpham] ON 

INSERT [dbo].[tbl_kho_sanpham] ([masp], [tensp], [mavach], [donvi], [id], [trongluong], [khoiluong], [idmanhomsp], [ghichu], [tondksoluong], [tondkthanhtien], [makho], [tenkho], [macty]) VALUES (N'123123213', N'Son ', N'123123213', N'Cây', 1, 34, 32, N'1         ', N'sadfsadf', 34, 34, N'Cty', N'Kho Công ty', NULL)
INSERT [dbo].[tbl_kho_sanpham] ([masp], [tensp], [mavach], [donvi], [id], [trongluong], [khoiluong], [idmanhomsp], [ghichu], [tondksoluong], [tondkthanhtien], [makho], [tenkho], [macty]) VALUES (N'ádfasdf31123', N'phấn', N'ádfasdf31123', N'cây', 2, 1, 4, N'2         ', N'phấn ', 12, 34, N'SH', N'Kho sH', NULL)
INSERT [dbo].[tbl_kho_sanpham] ([masp], [tensp], [mavach], [donvi], [id], [trongluong], [khoiluong], [idmanhomsp], [ghichu], [tondksoluong], [tondkthanhtien], [makho], [tenkho], [macty]) VALUES (N'34eadÁ', N'ZCZXC', N'34eadÁ', N'cÁI', 3, 1, 45, N'1         ', N'ÁDASDF', 0, 0, N'SH', N'Kho sH', NULL)
SET IDENTITY_INSERT [dbo].[tbl_kho_sanpham] OFF
SET IDENTITY_INSERT [dbo].[tbl_khohang] ON 

INSERT [dbo].[tbl_khohang] ([tenkho], [makho], [id], [diachikho], [ghichu], [macty]) VALUES (N'Kho sH', N'SH', 1, N'Thường tín', N'HÀ nội', NULL)
INSERT [dbo].[tbl_khohang] ([tenkho], [makho], [id], [diachikho], [ghichu], [macty]) VALUES (N'Kho Công ty', N'Cty', 2, N'Duyen Thái', N'adf', NULL)
INSERT [dbo].[tbl_khohang] ([tenkho], [makho], [id], [diachikho], [ghichu], [macty]) VALUES (N'Khu THanh Trì', N'KTT', 3, N'Thanh trì , hà nội', N'', NULL)
SET IDENTITY_INSERT [dbo].[tbl_khohang] OFF
SET IDENTITY_INSERT [dbo].[tbl_loaitk] ON 

INSERT [dbo].[tbl_loaitk] ([id], [name], [idloaitk]) VALUES (9, N'Tiền mặt                                        ', N'tien                                              ')
INSERT [dbo].[tbl_loaitk] ([id], [name], [idloaitk]) VALUES (10, N'Kho hàng                                         ', N'kho                                               ')
INSERT [dbo].[tbl_loaitk] ([id], [name], [idloaitk]) VALUES (11, N'Tạm ứng                                         ', N'tamung                                            ')
INSERT [dbo].[tbl_loaitk] ([id], [name], [idloaitk]) VALUES (12, N'Xác định kết quả kinh doanh                   ', N'xacdinhkqkd                                       ')
INSERT [dbo].[tbl_loaitk] ([id], [name], [idloaitk]) VALUES (13, N'Tài sản                                         ', N'taisan                                            ')
INSERT [dbo].[tbl_loaitk] ([id], [name], [idloaitk]) VALUES (14, N'Nguồn vốn                                       ', N'nguonvon                                          ')
INSERT [dbo].[tbl_loaitk] ([id], [name], [idloaitk]) VALUES (15, N'Doanh thu                                         ', N'doanhthu                                          ')
INSERT [dbo].[tbl_loaitk] ([id], [name], [idloaitk]) VALUES (16, N'Chi phí                                          ', N'chiphi                                            ')
INSERT [dbo].[tbl_loaitk] ([id], [name], [idloaitk]) VALUES (17, N'Lợi nhuận                                       ', N'loinhuan                                          ')
INSERT [dbo].[tbl_loaitk] ([id], [name], [idloaitk]) VALUES (18, N'Phải thu                                         ', N'phaithu                                           ')
INSERT [dbo].[tbl_loaitk] ([id], [name], [idloaitk]) VALUES (19, N'Phải trả                                        ', N'phaitra                                           ')
SET IDENTITY_INSERT [dbo].[tbl_loaitk] OFF
SET IDENTITY_INSERT [dbo].[tbl_machitiettk] ON 

INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (8, N'Đỗ Công Hoan', N'141', 1, N'A loe', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (9, N'Mai Văn Trường', N'111', 1, N'', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (10, N'Tăng Văn Thạch', N'111', 2, N'', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (11, N'Nguyễn Mai Khanh', N'331', 1, N'', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (12, N'Phan Đình Đức', N'331', 2, N'', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (13, N'Mai Văn Trường', N'141', 2, N'A Trường', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (14, N'Nguyễn Thị Hồng Nguyên ', N'141', 3, N'Nguyên Kế toán', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (15, N'Sunhouse', N'5111', 1, N'', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (16, N'Mistu Hưng Yên', N'5111', 2, N'Kho Mitsu Hưng Yên', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (17, N'Mitsu Hà bình Phương - Sữa', N'5111', 3, N'Sữa ở kho Hà Bình Phương', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (18, N'Mitsu Hà Bình Phương Bánh kẹo', N'5111', 4, N'Bánh kẹo Mistu hà bình phương', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (19, N'Aba', N'5111', 5, N'Bột giặt Aba', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (20, N'Mitsu MLc', N'131', 1, N'MLC logictic', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (21, N'Sunhouse', N'131', 2, N'sunhouse', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (22, N'Aba', N'131', 3, N'Bột giặt aba', 0, 0)
INSERT [dbo].[tbl_machitiettk] ([id], [tenchitiet], [matk], [machitiet], [ghichu], [nodk], [codk]) VALUES (23, N'Netco', N'131', 4, N'Netco Duyên Thái', 0, 0)
SET IDENTITY_INSERT [dbo].[tbl_machitiettk] OFF
SET IDENTITY_INSERT [dbo].[tbl_NP_danhsachxe] ON 

INSERT [dbo].[tbl_NP_danhsachxe] ([maNVT], [id], [bienso], [tenlaixe], [cmtlaixe], [dienthoailaixe], [sotantai], [sokhoithungxe], [tenNVT]) VALUES (N'04', 6, N'29c 97142', N'Nguyễn Xuân Hà', N'030083004434', N'01676701378', 1.3999999761581421, 6.5, NULL)
INSERT [dbo].[tbl_NP_danhsachxe] ([maNVT], [id], [bienso], [tenlaixe], [cmtlaixe], [dienthoailaixe], [sotantai], [sokhoithungxe], [tenNVT]) VALUES (N'04', 7, N'29c 96341', N'Nguyễn Minh Kha', N'001084010032', N'0965535566', 1.3999999761581421, 6.5, NULL)
INSERT [dbo].[tbl_NP_danhsachxe] ([maNVT], [id], [bienso], [tenlaixe], [cmtlaixe], [dienthoailaixe], [sotantai], [sokhoithungxe], [tenNVT]) VALUES (N'01', 8, N'29c 16797', N'Đỗ Công Hoan', N'001079017492', N'0918288344', 1.3999999761581421, 7, NULL)
INSERT [dbo].[tbl_NP_danhsachxe] ([maNVT], [id], [bienso], [tenlaixe], [cmtlaixe], [dienthoailaixe], [sotantai], [sokhoithungxe], [tenNVT]) VALUES (N'02', 9, N'29c 48314', N'Mai Văn Trường', N'012122848', N'0904470396', 1.3999999761581421, 7, NULL)
INSERT [dbo].[tbl_NP_danhsachxe] ([maNVT], [id], [bienso], [tenlaixe], [cmtlaixe], [dienthoailaixe], [sotantai], [sokhoithungxe], [tenNVT]) VALUES (N'02', 10, N'29c 51586', N'Bùi Văn Mạnh', N'0121276799', N'01566969785', 5, 27, NULL)
SET IDENTITY_INSERT [dbo].[tbl_NP_danhsachxe] OFF
SET IDENTITY_INSERT [dbo].[tbl_NP_giavantaitheotuyen] ON 

INSERT [dbo].[tbl_NP_giavantaitheotuyen] ([maKH], [id], [matuyen], [tentuyen], [loaidonxe], [km], [trichcongty], [giathue], [giahoadon], [trichdoitac], [dtkhac], [bocxep], [giadau], [dinhmucdau], [cfxang], [cflaixe], [cfcongan], [cfcauduong], [cfkhauhao], [tongcfuoctinh], [ghichucf], [lntuyen], [ngayapdung], [ngayhethan]) VALUES (N'01', 1, N'ádf44', N'ádfasdf44', 33, 123, 0, 123213, 1334, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, CAST(N'2018-01-11 13:11:47.897' AS DateTime), CAST(N'2118-01-11 13:11:47.897' AS DateTime))
INSERT [dbo].[tbl_NP_giavantaitheotuyen] ([maKH], [id], [matuyen], [tentuyen], [loaidonxe], [km], [trichcongty], [giathue], [giahoadon], [trichdoitac], [dtkhac], [bocxep], [giadau], [dinhmucdau], [cfxang], [cflaixe], [cfcongan], [cfcauduong], [cfkhauhao], [tongcfuoctinh], [ghichucf], [lntuyen], [ngayapdung], [ngayhethan]) VALUES (N'01', 3, N'12341', N'1341', 12, 124234, 0, 123432, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, CAST(N'2018-01-11 13:11:51.330' AS DateTime), CAST(N'2118-01-11 13:11:51.330' AS DateTime))
INSERT [dbo].[tbl_NP_giavantaitheotuyen] ([maKH], [id], [matuyen], [tentuyen], [loaidonxe], [km], [trichcongty], [giathue], [giahoadon], [trichdoitac], [dtkhac], [bocxep], [giadau], [dinhmucdau], [cfxang], [cflaixe], [cfcongan], [cfcauduong], [cfkhauhao], [tongcfuoctinh], [ghichucf], [lntuyen], [ngayapdung], [ngayhethan]) VALUES (N'01', 4, N'hn-hp', N'ha noi hai hia phong', 5, 110, 0, 87612, 8712498176, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, CAST(N'2018-01-11 13:11:53.590' AS DateTime), CAST(N'2118-01-11 13:11:53.590' AS DateTime))
INSERT [dbo].[tbl_NP_giavantaitheotuyen] ([maKH], [id], [matuyen], [tentuyen], [loaidonxe], [km], [trichcongty], [giathue], [giahoadon], [trichdoitac], [dtkhac], [bocxep], [giadau], [dinhmucdau], [cfxang], [cflaixe], [cfcongan], [cfcauduong], [cfkhauhao], [tongcfuoctinh], [ghichucf], [lntuyen], [ngayapdung], [ngayhethan]) VALUES (N'01', 5, N'hn29', N'adsfasdf', 5, 34, 0, 234324, 35345344, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, CAST(N'2018-03-19 17:10:17.657' AS DateTime), CAST(N'2118-03-19 17:10:17.657' AS DateTime))
INSERT [dbo].[tbl_NP_giavantaitheotuyen] ([maKH], [id], [matuyen], [tentuyen], [loaidonxe], [km], [trichcongty], [giathue], [giahoadon], [trichdoitac], [dtkhac], [bocxep], [giadau], [dinhmucdau], [cfxang], [cflaixe], [cfcongan], [cfcauduong], [cfkhauhao], [tongcfuoctinh], [ghichucf], [lntuyen], [ngayapdung], [ngayhethan]) VALUES (N'02', 6, N'23', N'423', 32423, 23423, 0, 23432424, 32423424, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, NULL, NULL)
INSERT [dbo].[tbl_NP_giavantaitheotuyen] ([maKH], [id], [matuyen], [tentuyen], [loaidonxe], [km], [trichcongty], [giathue], [giahoadon], [trichdoitac], [dtkhac], [bocxep], [giadau], [dinhmucdau], [cfxang], [cflaixe], [cfcongan], [cfcauduong], [cfkhauhao], [tongcfuoctinh], [ghichucf], [lntuyen], [ngayapdung], [ngayhethan]) VALUES (N'01', 7, N'34', N'adsfadsf', 234, 2213, 0, 123, 13213213, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, CAST(N'2018-01-27 13:12:14.000' AS DateTime), CAST(N'2118-01-27 13:12:14.000' AS DateTime))
INSERT [dbo].[tbl_NP_giavantaitheotuyen] ([maKH], [id], [matuyen], [tentuyen], [loaidonxe], [km], [trichcongty], [giathue], [giahoadon], [trichdoitac], [dtkhac], [bocxep], [giadau], [dinhmucdau], [cfxang], [cflaixe], [cfcongan], [cfcauduong], [cfkhauhao], [tongcfuoctinh], [ghichucf], [lntuyen], [ngayapdung], [ngayhethan]) VALUES (N'01', 8, N'qưerqewr', N'qưerqwer', 234, 23434, 0, 234234, 234324328448, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, CAST(N'2018-03-19 17:10:27.107' AS DateTime), CAST(N'2118-03-19 17:10:27.107' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_NP_giavantaitheotuyen] OFF
SET IDENTITY_INSERT [dbo].[tbl_NP_khachhangvanchuyen] ON 

INSERT [dbo].[tbl_NP_khachhangvanchuyen] ([maKH], [tenKH], [id], [diachiKH], [masothueKH], [sotaikhoannganhangKH], [diachinganhangKH]) VALUES (N'02', N'Mistsu', 2, N'Hưng yên hn', N'ádfdasfdasf', N'ádfasdfsdaf', N'dầdsaf')
INSERT [dbo].[tbl_NP_khachhangvanchuyen] ([maKH], [tenKH], [id], [diachiKH], [masothueKH], [sotaikhoannganhangKH], [diachinganhangKH]) VALUES (N'01', N'Sunhouse', 3, N'adsfasdf', N'sadfdasf', N'ádfadsf', N'ádfsadfdsaf')
INSERT [dbo].[tbl_NP_khachhangvanchuyen] ([maKH], [tenKH], [id], [diachiKH], [masothueKH], [sotaikhoannganhangKH], [diachinganhangKH]) VALUES (N'03', N'HAvico ', 4, N'Thường tín hà nội', N'123eqw1413', N'1234123eq', N'134edwqe143d')
INSERT [dbo].[tbl_NP_khachhangvanchuyen] ([maKH], [tenKH], [id], [diachiKH], [masothueKH], [sotaikhoannganhangKH], [diachinganhangKH]) VALUES (N'04', N'NetCo', 5, N'Duyen thai, Thuong tin, hà noi', N'ádf341234', N'q1341', N'dscccSDAC')
INSERT [dbo].[tbl_NP_khachhangvanchuyen] ([maKH], [tenKH], [id], [diachiKH], [masothueKH], [sotaikhoannganhangKH], [diachinganhangKH]) VALUES (N'05', N'bỘT GIẶT ABA', 6, N'ÁDFASDF', N'ÁDFASD', N'ASDFASD', N'ASDFASDF')
SET IDENTITY_INSERT [dbo].[tbl_NP_khachhangvanchuyen] OFF
SET IDENTITY_INSERT [dbo].[tbl_NP_Nhacungungvantai] ON 

INSERT [dbo].[tbl_NP_Nhacungungvantai] ([tenNVT], [maNVT], [id], [diachiNVT], [masothueNVT], [dienthoaiNVT], [sotaikhoannganhangNVT], [diachinganhangNVT]) VALUES (N'Mai Văn Trường', N'02', 2, N'Xa la - Hà Đông - Hà Nội', N'0239093284', N'0912252811', N'00708749001', N'Ngân hàng Tiên Phong Bank  - CN Hà nội')
INSERT [dbo].[tbl_NP_Nhacungungvantai] ([tenNVT], [maNVT], [id], [diachiNVT], [masothueNVT], [dienthoaiNVT], [sotaikhoannganhangNVT], [diachinganhangNVT]) VALUES (N'Đỗ Công Hoan', N'01', 3, N'Duyên Thái- Thường Tín', N'43134', N'0918288344', N'19031653413339', N'Techcombank - CN Hà Nội')
INSERT [dbo].[tbl_NP_Nhacungungvantai] ([tenNVT], [maNVT], [id], [diachiNVT], [masothueNVT], [dienthoaiNVT], [sotaikhoannganhangNVT], [diachinganhangNVT]) VALUES (N'Đinh Thị Thu Lý', N'03', 4, N'Thanh Oai- Hà Nội', N'2204205287294', N'2204205287294', N'2204205287294', N'Agribank-CN Thanh Oai - Hà Nội')
INSERT [dbo].[tbl_NP_Nhacungungvantai] ([tenNVT], [maNVT], [id], [diachiNVT], [masothueNVT], [dienthoaiNVT], [sotaikhoannganhangNVT], [diachinganhangNVT]) VALUES (N'Mr Kha', N'04', 5, N'Quang Minh', N'CMT 001084010032', N'0965535566', N'', N'')
SET IDENTITY_INSERT [dbo].[tbl_NP_Nhacungungvantai] OFF
SET IDENTITY_INSERT [dbo].[tbl_Socai] ON 

INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'chi phi mua xe                                                                                                                                                                                                                   ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'642       ', N'111       ', NULL, NULL, 278, N'', N'', 20545455, 20545455, N'3', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'thue chi phi mua xe                                                                                                                                                                                                              ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'133       ', N'111       ', NULL, NULL, 279, N'', N'', 2054546, 2054546, N'3', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'kc doanh thu chuyen khoan                                                                                                                                                                                                        ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'511', N'911', NULL, NULL, 292, N'', N'', 145578000, 145578000, N'11', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'kc luogn nhan vien                                                                                                                                                                                                               ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'911', N'642', NULL, NULL, 293, N'', N'', 27500000, 27500000, N'12', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'kc chi phi mua xe                                                                                                                                                                                                                ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'911', N'642', NULL, NULL, 294, N'', N'', 20545455, 20545455, N'13', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'thue thanh toan tien hang ngan hang                                                                                                                                                                                              ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'133       ', N'112       ', NULL, NULL, 296, N'', N'', 11863000, 11863000, N'5', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'thanh toan tien hang ngan hang                                                                                                                                                                                                   ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'156', N'112', NULL, NULL, 297, N'', N'', 118630000, 118630000, N'5', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'thuế thanh toán tien hàng                                                                                                                                                                                                        ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'133       ', N'111       ', NULL, NULL, 298, N'', N'', 2071689, 2071689, N'4', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'thanh toán tien hàng                                                                                                                                                                                                             ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'156', N'111', NULL, NULL, 299, N'', N'', 20716899, 20716899, N'4', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'kc  tien hàng                                                                                                                                                                                                                    ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'911', N'632', NULL, NULL, 300, N'', N'', 20716899, 20716899, N'14', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'kc thanh toan tien hang ngan hang                                                                                                                                                                                                ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'911', N'632', NULL, NULL, 301, N'', N'', 118630000, 118630000, N'9', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'xuat han                                                                                                                                                                                                                         ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'632', N'156', NULL, NULL, 302, N'', N'', 139346899, 139346899, N'15', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'doanh thu                                                                                                                                                                                                                        ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'111', N'511', NULL, NULL, 303, N'', N'', 23642705, 23642705, N'16', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'thue doanh thu                                                                                                                                                                                                                   ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'111', N'3331', NULL, NULL, 304, N'', N'', 2364270, 2364270, N'16', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'luogn nhan vien                                                                                                                                                                                                                  ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'642', N'334', NULL, NULL, 308, N'', N'', 27500000, 27500000, N'6', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'tra luogn nhan vien                                                                                                                                                                                                              ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'334', N'111', NULL, NULL, 309, N'', N'', 27500000, 27500000, N'25', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'gia do gop von                                                                                                                                                                                                                   ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'111', N'411', NULL, NULL, 311, N'', N'', 40000000, 40000000, N'29', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'kc doanh thu                                                                                                                                                                                                                     ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'511', N'911', NULL, NULL, 312, N'', N'', 23642705, 23642705, N'27', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'kc thue mon bai                                                                                                                                                                                                                  ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'911', N'642', NULL, NULL, 313, N'', N'', 2000000, 2000000, N'28', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'thue mon bai                                                                                                                                                                                                                     ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'642', N'112', NULL, NULL, 314, N'', N'', 2000000, 2000000, N'7', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'kc kn                                                                                                                                                                                                                            ', CAST(N'2018-03-31 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'4212      ', N'911       ', NULL, NULL, 316, N'', N'', 20171649, 20171649, N'31', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'kc thue                                                                                                                                                                                                                          ', CAST(N'2018-04-01 00:00:00.000' AS DateTime), CAST(N'2017-04-01 00:00:00.000' AS DateTime), N'TH', N'tr1', N'3331', N'133', NULL, NULL, 321, N'', N'', 15989235, 15989235, N'35', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'doanh thu chuyen khoan                                                                                                                                                                                                           ', CAST(N'2018-04-02 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'112', N'511', NULL, NULL, 322, N'', N'', 145578000, 145578000, N'2', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'rut tien ve quy                                                                                                                                                                                                                  ', CAST(N'2018-04-02 00:00:00.000' AS DateTime), CAST(N'2017-03-31 00:00:00.000' AS DateTime), N'TH', N'tr1', N'111', N'112', NULL, NULL, 326, N'', N'', 13085000, 13085000, N'30', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'ads                                                                                                                                                                                                                              ', CAST(N'2018-04-23 00:00:00.000' AS DateTime), CAST(N'2018-04-23 00:00:00.000' AS DateTime), N'PXK', N'tr1', N'131       ', N'158       ', NULL, 3, 327, N'', N'Aba', 2544, 2544, N'12', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'ádfasdf                                                                                                                                                                                                                          ', CAST(N'2018-04-23 00:00:00.000' AS DateTime), CAST(N'2018-04-23 00:00:00.000' AS DateTime), N'PXK', N'tr1', N'1212      ', N'153       ', NULL, NULL, 328, N'', N'', 14544, 14544, N'13', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'qewrqewr                                                                                                                                                                                                                         ', CAST(N'2018-04-23 00:00:00.000' AS DateTime), CAST(N'2018-04-23 00:00:00.000' AS DateTime), N'PNK', N'tr1', N'152       ', N'1283      ', NULL, NULL, 329, N'', N'', 14544, 14544, N'14', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'                                                                                                                                                                                                                                 ', CAST(N'2018-06-13 00:00:00.000' AS DateTime), CAST(N'2018-06-13 00:00:00.000' AS DateTime), N'PT', N'tr1', N'111       ', N'1112', 0, NULL, 330, NULL, NULL, 123123, 123123, N'1', NULL, NULL)
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'ádfadsf                                                                                                                                                                                                                          ', CAST(N'2018-06-19 00:00:00.000' AS DateTime), CAST(N'2018-06-19 00:00:00.000' AS DateTime), N'TH', N'tr1', N'1332      ', N'1212      ', NULL, NULL, 331, N'', N'', 232, 232, N'f', NULL, N'Np')
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'ádfdasf                                                                                                                                                                                                                          ', CAST(N'2018-06-20 00:00:00.000' AS DateTime), CAST(N'2018-06-20 00:00:00.000' AS DateTime), N'PXK', N'tr1', N'1212      ', N'152       ', NULL, NULL, 332, N'', N'', 1585476, 1585476, N'234', NULL, N'Np')
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'123412wwfsadf                                                                                                                                                                                                                    ', CAST(N'2018-11-13 00:00:00.000' AS DateTime), CAST(N'2018-11-13 00:00:00.000' AS DateTime), N'TH', N'tr1', N'136       ', N'1131      ', NULL, NULL, 333, N'', N'', 12341234, 12341234, N'qưeqwe', NULL, N'Np')
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'dấdf                                                                                                                                                                                                                             ', CAST(N'2018-11-13 00:00:00.000' AS DateTime), CAST(N'2018-11-13 00:00:00.000' AS DateTime), N'TH', N'tr1', N'111       ', N'1361      ', NULL, NULL, 334, N'', N'', 123123, 123123, N'23123', NULL, N'Np')
INSERT [dbo].[tbl_Socai] ([Diengiai], [Ngayghiso], [Ngayctu], [manghiepvu], [username], [TkNo], [TkCo], [MaCTietTKCo], [MaCTietTKNo], [id], [tenchitietCo], [tenchitietNo], [PsNo], [PsCo], [Sohieuchungtu], [nganhan], [macty]) VALUES (N'ádsasd                                                                                                                                                                                                                           ', CAST(N'2019-01-16 00:00:00.000' AS DateTime), CAST(N'2019-01-16 00:00:00.000' AS DateTime), N'TH', N'tr1', N'1113      ', N'141       ', NULL, NULL, 335, N'', N'', 1212, 1212, N'1', NULL, N'Np')
SET IDENTITY_INSERT [dbo].[tbl_Socai] OFF
SET IDENTITY_INSERT [dbo].[tbl_SoQuy] ON 

INSERT [dbo].[tbl_SoQuy] ([TKtienmat], [ChitietTM], [Ngayctu], [Machungtu], [PsNo], [PsCo], [Diengiai], [Chitietdoiung], [Nguoinopnhantien], [Diachinguoinhannop], [Chungtugockemtheo], [Ngayghiso], [Username], [id], [TKdoiung], [TenchitietTM], [Sophieu], [requestAproval], [fundcheckout], [cashavancerequest], [cashadvandapproval1], [cashadvanapproval2], [macty]) VALUES (N'111       ', 0, CAST(N'2018-06-13 00:00:00.000' AS DateTime), N'PT', 123123, 0, N'dsafasdf', 0, N'ádfdasf', N'đấ', 1, CAST(N'2018-06-13 00:00:00.000' AS DateTime), N'tr1', 31, N'1112', NULL, N'1', 0, 0, 0, 0, 0, N'Np')
SET IDENTITY_INSERT [dbo].[tbl_SoQuy] OFF
SET IDENTITY_INSERT [dbo].[tbl_Temp] ON 

INSERT [dbo].[tbl_Temp] ([id], [Version], [RegionCode], [Username], [Password], [Userright], [Note], [Inputcontract], [Name], [Phân_quyền], [Thiết_lập_tài_khoản], [Macty]) VALUES (1, 55, NULL, N'tr1                                                                                                                                                                                                                              ', N'123123                                                                                                                                                                                                                           ', 2, NULL, 0, N'Mai Văn Trường', 1, 1, N'Np')
INSERT [dbo].[tbl_Temp] ([id], [Version], [RegionCode], [Username], [Password], [Userright], [Note], [Inputcontract], [Name], [Phân_quyền], [Thiết_lập_tài_khoản], [Macty]) VALUES (2, 55, NULL, N'tuan                                                                                                                                                                                                                             ', N'123123                                                                                                                                                                                                                           ', NULL, NULL, 0, NULL, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Temp] OFF
ALTER TABLE [dbo].[tbl_Customer] ADD  CONSTRAINT [DF_tbl_KaCustomer_SapCode1]  DEFAULT ((0)) FOR [Grpcode]
GO
ALTER TABLE [dbo].[tbl_Customer] ADD  CONSTRAINT [DF_tbl_KaCustomer_SapCode2]  DEFAULT ((0)) FOR [SFAcode]
GO
ALTER TABLE [dbo].[tbl_Customer] ADD  CONSTRAINT [DF_tbl_KaCustomer_SapCode]  DEFAULT ((0)) FOR [SapCode]
GO
ALTER TABLE [dbo].[tbl_Customer] ADD  CONSTRAINT [DF_tbl_KaCustomer_SapCode1_1]  DEFAULT ((0)) FOR [indirectCode]
GO
USE [master]
GO
ALTER DATABASE [BEE] SET  READ_WRITE 
GO
