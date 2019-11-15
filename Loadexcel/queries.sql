--script to verify screen functions in both excels
select Screen_ID, ScreenFunction_CODE from [RefScreenFunctions_T1]
except
select  [SCRN] as Screen_ID,[Screen Function Code] as ScreenFunction_CODE from PACSSR

select  [SCRN] as Screen_ID,[Screen Function Code] as ScreenFunction_CODE from PACSSR
except
select Screen_ID, ScreenFunction_CODE from [RefScreenFunctions_T1]



--script to match role access_INDC from 2 excels
select r.screen_ID, r.role_ID, r.ScreenFunction_CODE, r.access_INDc as RLSAaccess_indc, d.access_INDC as excelaccess_INDC,
case when r.access_INDc=d.access_INDC then 'Y' else 'N' end as Matching_INDC
from RLSA r
inner join
(
select SCRN,[Screen Function Code], access_INDC, role_ID from PACSSR p
unpivot
(
  access_INDC
  for role_ID in ([DINW01]
,[DINS01]
,[DLOS01]
,[DICW01]
,[DICS01]
,[DCDW01]
,[DCIW01]
,[DCEW01]
,[DENW01]
,[DNHW01]
,[DTOW01]
,[DLRW01]
,[DUBW01]
,[DENS01]
,[DCOW01]
,[DCOS01]
,[DDSW01]
,[DDSS01]
,[DPOW01]
,[DGCW01]
,[DCCW01]
,[DVOV01]
,[DALS01]
,[DSAS01]
,[CINW01]
,[COEW01]
,[CPRW01]
,[CLOW01]
,[CAAS01]
,[CSUS01]
,[CWWW01]
,[CWAW01]
,[CRTW01]
,[CSOW01]
,[CMMW01]
,[CSSW01]
,[CSHW01]
,[CPPW01]
,[CARW01]
,[CPHS01]
,[CDHS01]
,[CLDS01]
,[CRAS01]
,[CVOV01]
,[CLSS01]
,[CJUV01]
,[RESW01]
,[REFW01]
,[RINW01]
,[RSUS01]
,[RADS01]
,[RVOV01]
,[ECAV01]
,[ECHV01]
,[EMDV01]
,[CRAM01]
,[CRAC01]
,[DRCE01]
,[DRPS01]
,[DRSS01]
,[CRFC01]
,[DRFC01]
,[CRHP01]
,[DRHP01]
,[RRHP01]
,[CCCW01]
,[CSDW01]
,[CSDW02]
,[DCMW01]
,[DCWS01]
,[DCWW01]
,[DESW01]
,[DLOW01]
,[RATW01]
,[RRFC01]
)
) unpiv
) d
on r.screen_ID=d.SCRN 
and r.screenfunction_code=d.[Screen Function Code] 
and r.role_ID=d.role_ID
where r.workitem not like '%DEL%';



