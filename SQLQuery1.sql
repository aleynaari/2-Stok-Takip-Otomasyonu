**
select Cins, Fiyat from Urun where Cins='Televizyon' order by Fiyat asc

--select (GirdiAdet-CiktiAdet) from GirdiUrun g join CiktiUrun c on c.BarkodNo=g.BarkodNo 

select sum(GirdiAdet) as 'S�p�rge adet' from GirdiUrun2 where Cins='S�p�rge'

--select (select sum(GirdiAdet) from GirdiUrun where Cins='S�p�rge')-(select sum(CiktiAdet) from CiktiUrun where Cins='S�p�rge') from GirdiUrun  join CiktiUrun on GirdiUrun.BarkodNo=CiktiUrun.BarkodNo

select sum(GirdiAdet) from GirdiUrun where Cins='S�p�rge'
select sum(CiktiAdet) from CiktiUrun where Cins='S�p�rge'

--�al��anlar--
select BarkodNo, sum(GirdiAdet) as 'Girdi ADED�' from GirdiUrun  group by BarkodNo 
select BarkodNo, sum(CiktiAdet) as '��kt� ADED�' from CiktiUrun  group by BarkodNo
----�al��mayanlar**
select sum(GirdiAdet) as 'Girdi ADED�' ,sum(CiktiAdet) as '��kt� ADED�'  from GirdiUrun g1 inner join CiktiUrun �1 on g1.BarkodNo=�1.BarkodNo group by BarkodNo order by BarkodNo


select sum(GirdiAdet),sum(CiktiAdet) from GirdiUrun g join CiktiUrun c on g.BarkodNo=c.BarkodNo


select gir.BarkodNo,u.UrunAd, gir.Cins, SUM(gir.GirdiAdet) as 'Girdi Adedi', SUM(cik.CiktiAdet) as '��kt� Adedi',  SUM(gir.GirdiAdet)-SUM(cik.CiktiAdet) as 'G�ncel Stok'
From  GirdiUrun gir, CiktiUrun cik, Urun u
Where cik.BarkodNo = gir.BarkodNo and gir.BarkodNo = u.BarkodNo and gir.Cins = u.Cins
group by gir.BarkodNo, cik.BarkodNo, gir.Cins, u.UrunAd

--select g.BarkodNo,u.UrunAd, g.Cins, sum(GirdiAdet) as 'Girdi Adedi', sum(CiktiAdet) as '��kt� Adedi', (GirdiAdet-CiktiAdet) as 'G�ncel Stok' from GirdiUrun g left join CiktiUrun c on g.BarkodNo=c.BarkodNo left join Urun u on c.BarkodNo=u.BarkodNo
--group by  g.BarkodNo,g.Cins,g.GirdiAdet,c.CiktiAdet, u.UrunAd 

select g.BarkodNo,u.UrunAd, g.Cins, sum(GirdiAdet) as 'Girdi Adedi', sum(CiktiAdet) as '��kt� Adedi', (GirdiAdet-CiktiAdet) as 'G�ncel Stok' from GirdiUrun g join CiktiUrun c on g.BarkodNo=c.BarkodNo join Urun u on c.BarkodNo=u.BarkodNo
group by  g.BarkodNo,g.Cins,g.GirdiAdet,c.CiktiAdet, u.UrunAd

select g.BarkodNo, g.Cins, g.GirdiAdet, ISNULL(c.CiktiAdet,0) as ��kt� from GirdiUrun g left join CiktiUrun c on g.BarkodNo = c.BarkodNo group by g.BarkodNo, g.Cins, g.GirdiAdet, c.CiktiAdet


--Girdi, ��kt� ve �r�n tablolar�n� birle�tiren (join), g�ncel sto�u bulan ve null de�erler yerine 0 yazd�ran sorgu
select u.BarkodNo,u.UrunAd, u.Cins, 
	   ISNULL (sum(g.GirdiAdet),0) as 'Girdi Adedi', 
	   ISNULL (sum(c.CiktiAdet),0) as '��kt� Adedi', 
	   (ISNULL(g.GirdiAdet,0)- ISNULL(c.CiktiAdet,0)) as 'G�ncel Stok' 
from Urun u 
   	 left join GirdiUrun g on g.BarkodNo=u.BarkodNo	
	 left join CiktiUrun c on g.BarkodNo=c.BarkodNo 
group by u.BarkodNo,u.Cins, u.UrunAd, g.GirdiAdet, c.CiktiAdet 

