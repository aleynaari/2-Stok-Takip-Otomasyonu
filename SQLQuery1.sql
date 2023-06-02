**
select Cins, Fiyat from Urun where Cins='Televizyon' order by Fiyat asc

--select (GirdiAdet-CiktiAdet) from GirdiUrun g join CiktiUrun c on c.BarkodNo=g.BarkodNo 

select sum(GirdiAdet) as 'Süpürge adet' from GirdiUrun2 where Cins='Süpürge'

--select (select sum(GirdiAdet) from GirdiUrun where Cins='Süpürge')-(select sum(CiktiAdet) from CiktiUrun where Cins='Süpürge') from GirdiUrun  join CiktiUrun on GirdiUrun.BarkodNo=CiktiUrun.BarkodNo

select sum(GirdiAdet) from GirdiUrun where Cins='Süpürge'
select sum(CiktiAdet) from CiktiUrun where Cins='Süpürge'

--çalýþanlar--
select BarkodNo, sum(GirdiAdet) as 'Girdi ADEDÝ' from GirdiUrun  group by BarkodNo 
select BarkodNo, sum(CiktiAdet) as 'Çýktý ADEDÝ' from CiktiUrun  group by BarkodNo
----çalýþmayanlar**
select sum(GirdiAdet) as 'Girdi ADEDÝ' ,sum(CiktiAdet) as 'Çýktý ADEDÝ'  from GirdiUrun g1 inner join CiktiUrun ç1 on g1.BarkodNo=ç1.BarkodNo group by BarkodNo order by BarkodNo


select sum(GirdiAdet),sum(CiktiAdet) from GirdiUrun g join CiktiUrun c on g.BarkodNo=c.BarkodNo


select gir.BarkodNo,u.UrunAd, gir.Cins, SUM(gir.GirdiAdet) as 'Girdi Adedi', SUM(cik.CiktiAdet) as 'Çýktý Adedi',  SUM(gir.GirdiAdet)-SUM(cik.CiktiAdet) as 'Güncel Stok'
From  GirdiUrun gir, CiktiUrun cik, Urun u
Where cik.BarkodNo = gir.BarkodNo and gir.BarkodNo = u.BarkodNo and gir.Cins = u.Cins
group by gir.BarkodNo, cik.BarkodNo, gir.Cins, u.UrunAd

--select g.BarkodNo,u.UrunAd, g.Cins, sum(GirdiAdet) as 'Girdi Adedi', sum(CiktiAdet) as 'Çýktý Adedi', (GirdiAdet-CiktiAdet) as 'Güncel Stok' from GirdiUrun g left join CiktiUrun c on g.BarkodNo=c.BarkodNo left join Urun u on c.BarkodNo=u.BarkodNo
--group by  g.BarkodNo,g.Cins,g.GirdiAdet,c.CiktiAdet, u.UrunAd 

select g.BarkodNo,u.UrunAd, g.Cins, sum(GirdiAdet) as 'Girdi Adedi', sum(CiktiAdet) as 'Çýktý Adedi', (GirdiAdet-CiktiAdet) as 'Güncel Stok' from GirdiUrun g join CiktiUrun c on g.BarkodNo=c.BarkodNo join Urun u on c.BarkodNo=u.BarkodNo
group by  g.BarkodNo,g.Cins,g.GirdiAdet,c.CiktiAdet, u.UrunAd

select g.BarkodNo, g.Cins, g.GirdiAdet, ISNULL(c.CiktiAdet,0) as Çýktý from GirdiUrun g left join CiktiUrun c on g.BarkodNo = c.BarkodNo group by g.BarkodNo, g.Cins, g.GirdiAdet, c.CiktiAdet


--Girdi, çýktý ve ürün tablolarýný birleþtiren (join), güncel stoðu bulan ve null deðerler yerine 0 yazdýran sorgu
select u.BarkodNo,u.UrunAd, u.Cins, 
	   ISNULL (sum(g.GirdiAdet),0) as 'Girdi Adedi', 
	   ISNULL (sum(c.CiktiAdet),0) as 'Çýktý Adedi', 
	   (ISNULL(g.GirdiAdet,0)- ISNULL(c.CiktiAdet,0)) as 'Güncel Stok' 
from Urun u 
   	 left join GirdiUrun g on g.BarkodNo=u.BarkodNo	
	 left join CiktiUrun c on g.BarkodNo=c.BarkodNo 
group by u.BarkodNo,u.Cins, u.UrunAd, g.GirdiAdet, c.CiktiAdet 

