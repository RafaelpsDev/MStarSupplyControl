CREATE OR ALTER FUNCTION FN_MES_TEXTO(@P_MES INT)
RETURNS VARCHAR(1000)
BEGIN
DECLARE @V_MESTEXTO VARCHAR(20)
	
	
	SET @V_MESTEXTO = 
		(CASE WHEN @P_MES = 1 THEN 'Janeiro'
			  WHEN @P_MES = 2 THEN 'Fevereiro'
			  WHEN @P_MES = 3 THEN 'Março'
			  WHEN @P_MES = 4 THEN 'Abril'
			  WHEN @P_MES = 5 THEN 'Maio'
			  WHEN @P_MES = 6 THEN 'Junho'
			  WHEN @P_MES = 7 THEN 'Julho'
			  WHEN @P_MES = 8 THEN 'Agosto'
			  WHEN @P_MES = 9 THEN 'Setembro'
			  WHEN @P_MES = 10 THEN 'Outubro'
			  WHEN @P_MES = 11 THEN 'Novembro'
			  WHEN @P_MES = 12 THEN 'Dezembro' END)

   RETURN(LTRIM(RTRIM(@V_MESTEXTO)))
END