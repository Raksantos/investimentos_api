using Microsoft.AspNetCore.Mvc;
using InvestimentosApi.Models;
using InvestimentosApi.Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace InvestimentosApi.Controllers;
[ApiController]
[Route("[controller]")]
public class PopulatingController : ControllerBase
{
    private DatabaseCotext _context;
    public PopulatingController(DatabaseCotext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        //cria uma lista com os síbolos das ações
        List<string> ativos = new List<string> { "MGLU3", "HAPV3", "PETR4", "VIIA3", "BBDC4", "AMER3", "CIEL3", "B3SA3", "NTCO3", 
        "ITUB4", "CVCB3", "COGN3", "ELET3", "AMAR3", "CASH3", "LREN3", "ABEV3", "RRRP3", "BRFS3", "PETR3", "ITSA4", "VALE3", "PRIO3", "MRVE3", "RAIZ4", "MRFG3", "ASAI3", "PETZ3", "RAIL3", "AZUL4", "BEEF3", "RDOR3", "AERI3", "VBBR3", "ANIM3", "BPAC11", "CPLE6", "OIBR3", "CSAN3", "ALPA4", "USIM5", "LWSA3", "BBAS3", "GOLL4", "UGPA3", "CMIG4", "EQTL3", "BOVA11", "LIGT3", "CRFB3", "CMIN3", "HBSA3", "JBSS3", "MLAS3", "TIMS3", "FNAM11", "CCRO3", "WEGE3", "CSNA3", "SOMA3", "FNOR11", "RCSL4", "GOAU4", "GGBR4", "POMO4", "EMBR3", "RENT3", "DXCO3", "MOVI3", "ECOR3", "ENGI11", "AESB3", "BBSE3", "ENEV3", "SUZB3", "NUBR33", "TOTS3", "QUAL3", "ENBR3", "KLBN11", "VAMO3", "VIVR3", "TEND3", "CEAB3", "LJQQ3", "NEOE3", "CBAV3", "BBDC3", "STBP3", "CYRE3", "SIMH3", "INBR32", "KLBN4", "AURE3", "PSSA3", "MEGA3", "BRAP4", "SEQL3", "RADL3", "RECV3", "JHSF3", "CURY3", "GMAT3", "SBSP3", "HYPE3", "CXSE3", "IRBR3", "ALSO3", "ESPA3", "RAPT4", "CSMG3", "FLRY3", "VIVA3", "EZTC3", "DIRR3", "BRKM5", "YDUQ3", "PCAR3", "TAEE11", "GUAR3", "IGTI11", "GRND3", "MULT3", "CPFE3", "SMFT3", "RCSL3", "ELET6", "CAML3", "GGPS3", "SMTO3", "ARZZ3", "BPAN4", "GFSA3", "SMAL11", "ALUP11", "ODPV3", "INTB3", "GSFI11", "SANB11", "SAPR4", "ENAT3", "CPLE3", "ZAMP3", "MODL3", "TSLA34", "SBFG3", "SQIA3", "KEPL3", "VIVT3", "POSI3", "TRPL4", "GOLD11", "TRIS3", "BOVV11", "IFCM3", "TTEN3", "EGIE3", "ENJU3", "MDIA3", "MYPK3", "EVEN3", "MILS3", "SAPR11", "IVVB11", "PGMN3", "BMGB4", "INEP3", "TRAD3", "XINA11", "AMBP3", "PLPL3", "VGIA11", "MELK3", "SLCE3", "BBOV11", "HBOR3", "LAND3", "JALL3", "SGPS3", "ROMI3", "BRSR6", "KLBN3", "TASA4", "INEP4", "RANI3", "XPBR31", "PTBL3", "MXRF11", "WIZC3", "BLAU3", "BOAS3", "TUPY3", "BOVX11", "NGRD3", "ONCO3", "MEAL3", "TECN3", "MATD3", "TPIS3", "VVEO3", "LUPA3", "ABCB4", "VLID3", "MBLY3", "PARD3", "NASD11", "PNVL3", "MELI34", "SYNE3", "SEER3", "EURP11", "CLSA3", "AAPL34", "MTRE3", "VGIR11", "ITUB3", "ORVR3", "LEVE3", "SHUL4", "SOJA3", "JSLG3", "AGRO3", "RZAG11", "BLQD39", "AMZO34", "USAL11", "PORT3", "FRAS3", "AZEV4", "ALPK3", "CPLE11", "ESGU11", "OPCT3", "TAEE4", "USIM3", "TGMA3", "UTEC11", "CSED3", "BMOB3", "ARML3", "LOGG3", "OSXB3", "F2NV34", "AALR3", "NVDC34", "BRIT3", "LPSB3", "UNIP6", "CRPT11", "LAVV3", "ETER3", "KRSA3", "BABA34", "LFTS11", "SHOW3", "HASH11", "VITT3", "MDNE3", "VULC3", "ELMD3", "VGHF11", "SANB4", "ESGD11", "ACWI11", "XPSF11", "XPCA11", "C2OI34", "GOGL34", "DASA3", "BIYW39", "FESA4", "PDGR3", "PETR4F", "TRXF11", "SAPR3", "MSFT34", "M1TA34", "CMIG3", "KNCR11", "PINE4", "KLBN4F", "R2DF34", "GALG11", "NINJ3", "CSUD3", "MCHF11", "BTCI11", "DOTZ3", "TAEE3", "FHER3", "PMAM3", "WHGR11", "BEGU39", "BIHI39", "PFRM3", "DEXP4", "KISU11", "OIBR4", "AZEV3", "KNRE11", "HBRE3", "OIAG11", "SANB3", "BAAX39", "ALUP4", "BBAS3F", "POMO3", "ITSA3", "IRDM11", "KNIP11", "C1SU34", "LOGN3", "RRRP3F", "ITSA4F", "FIQE3", "RURA11", "GTLG11", "MGLU3F", "VSLH11", "S2HO34", "FGAA11", "RZAK11", "TCSA3", "CPTS11", "ATMP3", "RNEW3", "DEXP3", "PRNR3", "ATOM3", "TFCO4", "DESK3", "TAEE11F", "URET11", "HCTR11", "RNEW4", "AMER3F", "AAZQ11", "IGTI3", "GOAU3", "PFIN11", "VALE3F", "KDIF11", "HBCR11", "BBDC4F", "BSHV39", "NFLX34", "RECR11", "VIUR11", "TORD11", "ALLD3", "BRBI11", "FIND11", "QBTC11", "DEVA11", "PAGS34", "CPLE6F", "TGAR11", "ALUP3", "PNPR11", "AURA33", "VIIA3F", "PRIO3F", "XPLG11", "MRFG3F", "QETH11", "BLMR11", "APER3", "KNCA11", "BCFF11", "VSTE3", "HSML11", "T2TD34", "LVTC3", "EUCA4", "SAPR4F", "M1RN34", "TRPL4F", "NEWU11", "RZTR11", "XPML11", "TASA3", "STOC31", "LREN3F", "HGRU11", "BBSE3F", "ARRI11", "VCRI11", "OIBR3F", "NTCO3F", "RBRR11", "G2DI33", "AMAR3F", "BODB11", "HAPV3F", "BTLG11", "CXSE3F", "DMVF3", "GGBR3", "DISB34", "RDNI3F", "DCRA11", "ESGE11", "VISC11", "BRCR11", "TAEE4F", "VBBR3F", "BEWZ39", "MCCI11", "ITUB4F", "KLBN3F", "KLBN11F", "BRCO11", "ALUP11F", "BEEF3F", "VRTA11", "AGXY3", "RDNI3", "CVCB3F", "JSRE11", "IRBR3F", "CSAN3F", "JNJB34", "WEST3", "BIAU39", "BBDC3F", "MOVI3F", "RAIZ4F", "HGLG11", "SARE11", "CPTR11", "URPR11", "CYCR11", "PVBI11", "WEGE3F", "BERK34", "B2YN34", "HFOF11", "BRFS3F", "C1CL34", "BRAP3", "EGIE3F", "CMIN3F", "RSID3", "HGCR11", "KNSC11", "CTSA4", "RBRF11", "CVBI11", "KNRI11", "AESB3F", "ABEV3F", "BRPR3", "CIEL3F", "VIVT3F", "MATB11", "GGBR4F", "CASH3F", "BRKM5F", "A1LB34", "AGRO3F", "JURO11", "PATL11", "IFRA11", "VILG11", "JHSF3F", "AERI3F", "BIVB39", "BEWH39", "XPCI11", "ORCL34", "PETR3F", "RDPD11", "BROF11", "BEES3", "MRVE3F", "RCSL4F", "CMIG4F", "TASA4F", "JBSS3F", "CSNA3F", "AZUL4F", "GRND3F", "BIOM3", "BGOV39", "FLRY3F", "ENBR3F", "BMGB4F", "BITH11", "AURE3F", "PETZ3F", "USIM5F", "NCRA11", "ELET3F", "VINO11", "KFOF11", "ALPA4F", "UNIP6F", "GOAU4F", "KEPL3F", "PDTC3", "BDIF11", "TAEE3F", "GGRC11", "SUZB3F", "HABT11", "U2ST34", "ENAT3F", "BBPO11", "RDOR3F", "MALL11", "ECOR3F", "CPLE3F", "EALT4", "T1WL34", "OGIN11", "FSRF11", "ALPA3", "BCRI11", "VGIP11", "BBOI11", "CEBR6", "ETHE11", "SADI11", "ASAI3F", "WIZC3F", "TIMS3F", "COCA34", "CEDO4", "BIYT39", "SLED4", "UCAS3", "SANB11F", "KNHY11", "GOGL35", "IBOB11", "OXYP34", "HAGA4", "RANI3F", "BPAC11F", "VCJR11", "WRLD11", "UNIP3", "CSMG3F", "SANB3F", "SMTO3F", "MANA11", "JPMC34", "SANB4F", "BTLT39", "UNHH34", "BRAP4F", "EQTL3F", "HGRE11", "COGN3F", "MGEL4", "BPAC5", "ROMI3F", "ALUG11", "B1NT34", "QUAL3F", "DIVO11", "PSSA3F", "EZTC3F", "WALM34", "ALSO3F", "ALZR11", "BCHI39", "FCFL11", "CPFE3F", "BIBB39", "LEVE3F", "CAML3F", "ALUP4F", "MLAS3F", "USTK11", "NEOE3F", "XPIN11", "RENT3F", "ENGI4", "GMCO34", "DXCO3F", "GOLL4F", "AALL34", "COWC34", "LWSA3F", "BDIV11", "RIOT34", "RBRP11", "AGRX11", "AVGO34", "CRFB3F", "NEWL11", "ARZZ3F", "SIMH3F", "EMBR3F", "CORN11", "TOTS3F", "RAPT4F", "VXXV11", "SDIL11", "CYRE3F", "CBAV3F", "SAPR3F", "BOAC34", "MGFF11", "BPAC3", "SAPR11F", "XFIX11", "VIVA3F", "TSMC34", "BRSR6F", "T2DH34", "BLAU3F", "LIGT3F", "XPIE11", "BRZP11", "ITSA3F", "BFAV39", "BUTL39", "RECV3F", "ODPV3F", "BRKM3", "PGMN3F", "S2EA34", "TEKA4", "RZAT11", "RADL3F", "COCE5", "LVBI11", "HSLG11", "POSI3F", "MSCD34", "SBSP3F", "U1BE34", "STBP3F", "BIVE39", "SNAG11", "RBVA11", "BACW39", "VIGT11", "VISA34", "EXXO34", "RECT11", "RBRY11", "XPPR11", "PFIZ34", "BKSA39", "TRIS3F", "CCRO3F", "HGBS11", "BTAL11", "A1MD34", "VAMO3F", "SOMA3F", "BCWV39", "AIRB34", "B5P211", "GAME11", "CLSC4", "KCRE11", "RAIL3F", "HAGA3", "N1EM34", "GCFF11", "VIFI11", "DIRR3F", "WHRL4", "ABCB4F", "RCSL3F", "AMBP3F", "CARE11", "MYPK3F", "SLCE3F", "CTNM4", "BIXN39", "BBGO11", "MDIA3F", "K2CG34", "CAMB3", "BARI11", "SSFO34", "ELET6F", "HYPE3F", "TEPP11", "BIOM3F", "RCRB11", "BTAG11", "SQIA3F", "CURY3F", "ALUP3F", "ITLC34", "UGPA3F", "KNOX11", "BLMG11", "ITUB3F", "BIYE39", "BEGD39", "TTEN3F", "CEBR5", "RNEW11", "BPAN4F", "TUPY3F", "WHRL3", "RBRX11", "T1AL34", "AFHI11", "JALL3F", "BIYK39", "EQPA3", "MCDC34", "PORD11", "CEBR3", "APTO11", "VIVR3F", "GMAT3F", "ENEV3F", "SNCI11", "ANIM3F", "SCHW34", "SPXI11", "EQIR11", "BEMV39", "ELCI34", "YDUQ3F", "P1DD34", "RELG11", "PNVL3F", "PCAR3F", "HSAF11", "GCRA11", "WFCO34", "ENDD11", "CHVX34", "RBRL11", "CPTI11", "BEFV39", "BTRA11", "BCIA11", "PICE11", "CMCS34", "L1YG34", "PLCR11", "BIME11", "VERZ34", "RBFF11", "BKXI39", "BKNG34", "SHUL4F", "ABBV34", "BPFF11", "JOGO11", "MULT3F", "TEND3F", "HGFF11", "OUJP11", "PYPL34", "HOFC11", "TASA3F", "CEAB3F", "AIEC11", "POMO4F", "CTSA3", "NIKE34", "IGTI11F", "BFXI39", "BIEF39", "BEWU39", "PPEI11", "BGWH39", "BDLL4", "CPFF11", "SMAC11", "QDFI11", "LGCP11", "BEFA39", "AVLL3", "CSCO34", "M1NS34", "GTWR11", "BEES3F", "KIVO11", "MFII11", "BOVB11", "PTNT4", "JPPA11", "RIGG34", "MORE11", "RBHG11", "USIM3F", "FSRF11F", "BIJH39", "CSUD3F", "FESA4F", "AXPB34", "VCRA11", "SLED3", "CHCM34", "SEQL3F", "BIEU39", "INTB3F", "NCHB11", "MEGA3F", "INEP3F", "UNIP3F", "BEZU39", "BIDB11", "CMIG3F", "GFSA3F", "SPXB11", "DEXP4F", "SNSY5", "LIFE11", "DHER34", "WLMM4", "CGRA4", "SNFF11", "PMAM3F", "OUFF11", "GUAR3F", "PLPL3F", "SCAR3", "EUCA3", "ENGI11F", "A1MT34", "GCRI11", "SYNE3F", "MILS3F", "IFCM3F", "EVEN3F", "MORC11", "SMFT3F", "XPID11", "RPMG3F", "EGYR11", "QCOM34", "R2BL34", "ADBE34", "RYTT34", "NGRD3F", "VULC3F", "SGPS3F", "GOAU3F", "HBSA3F", "TECN3F", "QAGR11", "AMGN34", "CRPG5", "SEED11", "DGCO34", "VCRR11", "RPMG3", "ENGI3", "BBFO11", "TECK11", "ATTB34", "OURE11", "ENJU3F", "MGCR11", "ETER3F", "SPTW11", "GGBR3F", "JSAF11", "TRPL3", "GRWA11", "ATOM3F", "XMAL11", "BRBI11F", "NETE34", "ZAMP3F", "ALPA3F", "LJQQ3F", "BCSA34", "HBOR3F", "RBED11", "FCXO34", "B1TI34", "RBHY11", "VLID3F", "CEOC11", "BRAP3F", "MTRE3F", "XPCM11", "BIEI39", "CTGP34", "OULG11", "FPOR11", "OIBR4F", "TELB4", "RSUL4", "HOOT4", "HOME34", "R1JF34", "MDNE3F", "SPXS11", "LOGG3F", "S1PO34", "BEWJ39", "LUPA3F", "SBFG3F", "BLAK34", "CACR11", "IGBR3", "DOHL4", "BEES4", "TRIG11", "EGAF11", "PIBB11", "SHOT11", "SOJA3F", "LAVV3F", "POMO3F", "NFTS11", "CPLE11F", "FIQE3F", "LVTC3F", "BIYF39", "ALPK3F", "ESPA3F", "HREC11", "GPIV33", "PTBL3F", "JASC11", "MWET4", "PARD3F", "FHER3F", "BMOB3F", "LILY34", "BRKM3F", "BITI11", "BEWW39", "TPIS3F", "ORVR3F", "PDGR3F", "A1IV34", "FRAS3F", "BLCA11", "MUTC34", "I1QY34", "OSXB3F", "P1LD34", "Z1OM34", "FIVN11", "JDCO34", "TMCO34", "MODL3F", "ONCO3F", "INEP4F", "SEQR11", "EDGA11", "RVBI11", "JFEN3", "REDE3", "NEXT34", "VITT3F", "D1OC34", "DEBB11", "LOGN3F", "GGPS3F", "E1DU34", "COPH34", "IMAB11", "DEXP3F", "MRCK34", "A1UA34", "BSLV39", "SHOW3F", "S1BS34", "HGPO11", "BEES4F", "TLNC34", "TECB11", "BUSM39", "MOSC34", "BRIT3F", "Z1TS34", "OPCT3F", "MGHT11", "BPAC3F", "FIGS11", "SEER3F", "A1ZN34", "JSLG3F", "ENGI4F", "BMEB4", "RAPT3", "MEAL3F", "ELMD3F", "VVCO11", "BIDU34", "PGCO34", "EQIX34", "TRAD3F", "PATC11", "MTSA4", "BALM4", "BAZA3", "MNPR3", "BRSR3", "JFLL11", "RNGO11", "BOAS3F", "VSTE3F", "TCSA3F", "BEWG39", "DEFI11", "P2LT34", "AALR3F", "TGMA3F", "FDMO34", "B5MB11", "OFSA3", "MNDL3", "PSVM11", "CSRN3", "RNEW4F", "MELK3F", "BAER39", "IBCR11", "I1SR34", "A1KA34", "CXCO11", "CEBR3F", "IMBB11", "A1SN34", "CLSA3F", "BBRC11", "PEPB34", "GSGI34", "DASA3F", "VSHO11", "RFOF11", "B1IL34", "ARML3F", "BIXJ39", "CEBR6F", "B1PP34", "APER3F", "LPSB3F", "CXAG11", "BNFS11", "U1AL34", "ALZM11", "EALT4F", "PRNR3F", "BRSR3F", "BRPR3F", "CSED3F", "CATP34", "DEEC34", "HTMX11", "CGAS3", "TXRX4", "CVSH34", "HGAG11", "CTSA3F", "VTLT11", "IRFM11", "PLRI11", "G1FI34", "P1GR34", "MBLY3F", "CXCI11", "BQUA39", "SNID11", "TRPL3F", "TMOS34", "COLG34", "B1SA34", "ATMP3F", "BOBR4F", "JGPX11", "MATD3F", "VVEO3F", "FSLR34", "S2QU34", "R2RX34", "DOTZ3F", "A2MC34", "E2TS34", "GEOO34", "LAND3F", "BEWA39", "AZEV4F", "PORT3F", "HOSI11", "IGTI3F", "SNLG11", "PFRM3F", "LUGG11", "TFCO4F", "PINE4F", "CEEB3", "NEXP3", "NINJ3F", "BMIN4", "BRIV4", "ARMT34", "RBRD11", "PPLA11", "M2PM34", "EQPA3F", "ELAS11", "BOVS11", "BEFG39", "MSBR34", "PLOG11", "NSLU11", "DESK3F", "M2PW34", "HCHG11", "VLOL11", "CAMB3F", "WEB311", "KRSA3F", "CTKA4", "PLAS3", "CPLE5", "FIIB11", "BHYG39", "R1IN34", "MCHY11", "HLOG11", "NVHO11", "DMVF3F", "SBUB34", "SLED4F", "RRCI11", "N1VO34", "ZAVI11", "CRAA11", "G1DS34", "NAVT11", "BNDA39", "FSTU11F", "META11", "WEST3F", "RNEW3F", "MMMC34", "BAZA3F", "AGXY3F", "B1LL34", "ENGI3F", "O2NS34", "ALLD3F", "RAPT3F", "C2RW34", "BOBR4", "FRTA3", "UNIP5", "CGRA4F", "UCAS3F", "BPAC5F", "COCE5F", "CTNM4F", "FAED11", "CRPG5F", "USDB11", "EUCA4F", "WHRL4F", "HAGA4F", "A2XO34", "ESGB11", "BIWM39", "ITIT11", "PLCA11", "E2NP34", "FRTA3F", "ASMT11", "JRDM11", "ULEV34", "ITIP11", "CPLE5F", "ABCP11", "FLCR11", "AZEV3F", "FSPE11F", "CRIV3", "ELET5", "ESUT11", "P2AN34", "MFAI11", "BONY34", "R1KU34", "QAMI11", "SCPF11", "GURU11", "CGAS3F", "FDES11F", "IRIM11", "CMDB11", "DVFF11", "C1NC34", "FVPQ11", "M1LC34", "W1IX34", "T1EC34", "C2RS34", "WHRL3F", "BURA39", "BIEM39", "MAXR11", "MACY34", "FLMA11", "P1KX34", "XPHT11", "GOVE11", "FATN11", "REDE3F", "HCRI11", "W1YC34", "F1RC34", "AZOI34", "ONEF11", "IGBR3F", "KHCB34", "SHPH11", "OFSA3F", "HBRE3F", "SLED3F", "CTSA4F", "CLSC4F", "5GTK11", "RMAI11", "V1OD34", "JFEN3F", "TEXA34", "CJCT11", "BDLL3", "BRSR5", "EALT3", "EMAE4", "LIPR3", "NORD3", "CGAS5", "BMEB4F", "INTU34", "CEDO4F", "BRAX11", "IB5M11", "A2MR34", "SNSY5F", "SIMN34", "HRDF11", "EURO11", "TELB4F", "HOOT4F", "RSID3F", "B1GN34", "RBIR11", "A1MP34", "LOWC34", "T1OW34", "BDVY39", "UNIP5F", "HAGA3F", "ORLY34", "RBOP11", "PTNT4F", "EALT3F", "RBVO11", "BGRT39", "SNEC34", "H1DB34", "S2UI34", "BNDX11", "ISUS11", "BCPX39", "NEXP3F", "K1EY34", "CBOP11", "E1CO34", "GILD34", "LFTT11", "D1VN34", "BDLL4F", "RPRI11", "E1XC34", "TELB3F", "M1UF34", "XBOV11", "EVBI11", "RNDP11", "D2KN34", "CTXT11", "A1WK34", "BMMT11", "ASML34", "MILL11", "INGG34", "BREW11", "S1LG34", "WPLZ11", "BCIC11", "LMTB34", "LSAG11", "E2XA34", "J2AZ34", "L1RC34", "PEAB3", "BGIP4", "USBC34", "EKTR3", "GEPA3", "S2CH34", "BMEB3", "BGIP3", "CALI3", "BDEF11", "GEPA4", "BSLI3", "EPAR3F", "CGRA3F", "HPQB34", "MAPT4F", "YDRO11", "PQAG11", "BBSD11", "BEWT39", "ATVI34", "A2RE34", "TRNT11", "HDEL11", "CGAS5F", "IAGR11", "HOND34", "REVE11", "RNEW11F", "WLMM4F", "H1UM34", "MNPR3F", "BIRB39", "BIJR39", "B2HI34", "A1ME34", "BPML11", "CXRI11", "RBIF11", "CALI3F", "MTSA4F", "H1SB34", "HTEK11", "C1PR34", "S1GE34", "USSX34", "A1DI34", "TXSA34", "HBTS5F", "T1TW34", "BIVW39", "MDLZ34", "ELET5F", "BPOT39", "EUCA3F", "CLSC3F", "IDFI11", "K1LA34", "E1RI34", "T2ER34", "NMRH34", "R2HH34", "SMAB11", "S1MF34", "H1CA34", "N1DA34", "RSUL4F", "AFLT3F", "L1MN34", "CSRN3F", "A1DM34", "M1SC34", "L1DO34", "BEWC39", "CXTL11", "S2NA34", "IGTI4F", "CEEB5F", "VOTS11", "W1EL34", "BSHY39", "PQDP11", "CEEB3F", "AVLL3F", "ALMI11", "CNES11", "BGIP4F", "VLOE34", "JOPA3F", "DEOP34", "CTNM3F", "HAAA11", "M1DB34", "V2MW34", "CEBR5F", "U2PS34", "A1UT34", "DNAI11", "E1XR34", "BITO39", "PDTC3F", "P2LN34", "HPDP11", "SVAL11", "GSHP3F", "BMLC11", "C1GP34", "PABY11", "EKTR4F", "HUSC11", "BRKM6F", "U2PW34", "UBSG34", "S1HW34", "CBEE3F", "C1BS34", "CRIV3F", "AGRI11", "RBRS11", "BOXP34", "CRFF11", "E1WL34", "E1QN34", "FESA3F", "DOHL4F", "BMIN4F", "F1SL34", "NORD3F", "C1HT34", "VRTX34", "H1OG34", "BEEM39", "BSLI3F", "IBMB34", "BRSR5F", "WSEC11", "M2RV34", "B1AX34", "CRHP34", "A1NS34", "HUCG11", "CEDO3F", "ECOO11", "S2TA34", "BQYL39", "B1SX34", "A1NE34", "O1MC34", "TXRX4F", "B1CS34", "L1CA34", "GPAR3F", "PEMA11", "H1II34", "CCRF11", "ACNB34", "BDLL3F", "ESUT11F", "FOOD11", "TRXB11", "BLMC11", "BLBT39", "NUTR3F", "O2HI34", "CRIV4F", "CLOV34", "M1TT34", "BLPA39", "L1YV34", "F1MC34", "P1HM34", "ABUD34", "L1UL34", "E1QR34", "BEWQ39", "BSUS39", "ZIFI11", "A1VB34", "BSRE39", "BICR11", "RINV11", "E1SS34", "EAIN34", "T1MU34", "EMAE4F", "BOTZ39", "D1LR34", "A1EG34", "BSOX39", "RCFA11", "GENB11", "N1UE34", "C1CI34", "BPRP11", "BPVE39", "F1FI34", "PSVM11F", "MGEL4F", "BSNS39", "E2EF34", "J1CI34", "C1NS34", "BRIV4F", "E1VE34", "BAHI3F", "W1MG34", "BSIL39", "BHIX39", "BREV11", "BMEB3F", "BILF39", "BLPX39", "W1AB34", "HSRE11", "MOOO34", "H2UB34", "D2AS34", "Q2SC34", "RBDS11", "EQPA5F", "CSRN6F", "BSDV39", "BSOC39", "BDVD39", "R1CL34", "FIGE3F", "BMIL39", "BCAT39", "BHER39", "BGNO39", "MERC4F", "BCLO39", "BDRI39", "SOND6F", "BCTE39", "BEDC39", "BCHQ39", "FIXA11", "BBUG39", "BFNX39", "BNBR3F", "BALM3F", "BRGE5F", "N2LY34", "FLRP11", "SPGI34", "BEWL39", "BVLU39", "C2OL34", "NCRI11", "P1SA34", "BSIZ39", "LASC11", "HGIC11", "OGHY11", "BILB34", "TEKA4F", "P2CF34", "SCVB11", "GEPA4F", "WUNI34", "BFCG39", "C2AC34", "C1IC34", "T1RI34", "DBAG34", "L1EN34", "PHMO34", "P1EA34", "N1CL34", "BLUR11", "ATSA11", "TRVC34", "RPAD3F", "RECX11", "PRSV11", "A2ZT34", "SRVD11", "PLAS3F", "TGTB34", "GPRO34", "BLOK11", "TSNF34", "PEVC11", "T1SO34", "BDOM11", "PHGN34", "S2YN34", "O1KT34", "WABC34", "DOHL3F", "N2VC34", "V1NO34", "LIPR3F", "PEAB4F", "BSLI4F", "EQPA6F", "MCOR34", "BXPO11", "CRPG6F", "W1MB34", "A1TT34", "FPAB11", "WGBA34", "FMSC34", "N1WG34", "BIYG39", "A1AP34", "EBAY34", "PATI3F", "C1HR34", "S2TW34", "E1OG34", "K1EL34", "HONB34", "IDGR11", "BTEK11", "PTNT3F", "S2NW34" };

        var httpClient = new HttpClient();

        //percorre a lista de símbolos
        foreach (string ativo in ativos){
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://brapi.dev/api/quote/{ativo}");
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);

                if (data["results"]?[0]?["regularMarketPrice"]?.ToString() != null)
                {
                    string symbol = data["results"]?[0]?["symbol"]?.ToString() ?? "";
                    var acao = _context.Acoes.FirstOrDefault(acoes => acoes.Id == symbol);

                    if (acao == null)
                    {
                        Acoes acaoInserir = new Acoes(
                            data["results"]?[0]?["symbol"]?.ToString() ?? "",
                            data["results"]?[0]?["shortName"]?.ToString() ?? "",
                            data["results"]?[0]?["longName"]?.ToString() ?? "",
                            data["results"]?[0]?["currency"]?.ToString() ?? "",
                            Convert.ToDouble(data["results"]?[0]?["regularMarketPrice"]?.ToString())
                        );

                        _context.Acoes.Add(acaoInserir);
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Erro ao obter cotação da ação {ativo}: {response.StatusCode}");
            }
        }

        List<string> coins = new List<string> { "BTC", "BTT1", "BTG", "BTS", "BTM", "BTC2", "BTX" };

        foreach (string coin in coins){
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://brapi.dev/api/v2/crypto?coin={coin}");
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);

                if (data["coins"]?[0]?["regularMarketPrice"]?.ToString() != null)
                {
                    string symbol = data["coins"]?[0]?["coin"]?.ToString() ?? "";
                    var acao = _context.Acoes.FirstOrDefault(acoes => acoes.Id == symbol);

                    if (acao == null)
                    {
                        Cripto criptoInserir = new Cripto(
                            data["coins"]?[0]?["coin"]?.ToString() ?? "",
                            data["coins"]?[0]?["coinName"]?.ToString() ?? "",
                            data["coins"]?[0]?["currency"]?.ToString() ?? "",
                            Convert.ToDouble(data["coins"]?[0]?["regularMarketPrice"]?.ToString())
                        );

                        _context.Criptos.Add(criptoInserir);
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Erro ao obter cotação da criptomoeda {coin}: {response.StatusCode}");
            }
        }

        List<string> tesouro_direto = new List<string> {"brazil"};

        foreach (string tesouro in tesouro_direto){
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://brapi.dev/api/v2/prime-rate?country={tesouro}&historical=false&start=29%2F10%2F2022&end=29%2F10%2F2022&sortBy=date&sortOrder=desc");
            var response = await httpClient.SendAsync(request);
            Console.WriteLine(response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);

                if (data["prime-rate"]?[0]?["value"]?.ToString() != null)
                {
                    string symbol = data["bonds"]?[0]?["bond"]?.ToString() ?? "";
                    var tesouros_diretos = _context.TesouroDiretos.FirstOrDefault(tesouros_diretos => tesouros_diretos.Id == symbol);

                    if (tesouros_diretos == null)
                    {
                        TesouroDireto tesouroInserir = new TesouroDireto(
                            tesouro,
                            Convert.ToDouble(data["prime-rate"]?[0]?["value"])
                        );

                        _context.TesouroDiretos.Add(tesouroInserir);
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Erro ao obter cotação do tesouro direto {tesouro}: {response.StatusCode}");
            }
        }
        return Ok("Banco populado com sucesso");
    }
}
