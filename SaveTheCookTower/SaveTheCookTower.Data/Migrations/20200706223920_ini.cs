using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaveTheCookTower.Data.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_categoria_pai = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_categoria_categoria_id_categoria_pai",
                        column: x => x.id_categoria_pai,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fonte_prop_intelec",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    s_autor = table.Column<string>(nullable: true),
                    s_titulo = table.Column<string>(nullable: true),
                    n_pagina_livro = table.Column<int>(nullable: true),
                    s_edicao_livro = table.Column<string>(nullable: true),
                    uri_origem = table.Column<string>(nullable: true),
                    dt_acesso = table.Column<DateTime>(nullable: false),
                    m_comentario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fonte_prop_intelec", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unidade_medida",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    n_tipo = table.Column<int>(nullable: false),
                    _nome_resumido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidade_medida", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    s_email = table.Column<string>(nullable: true),
                    s_login = table.Column<string>(nullable: true),
                    s_password = table.Column<string>(nullable: true),
                    s_token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cardapio",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_cardapio = table.Column<Guid>(nullable: false),
                    m_descricao = table.Column<string>(nullable: true),
                    m_imagens_url = table.Column<string>(nullable: true),
                    m_videos_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardapio", x => x.id);
                    table.ForeignKey(
                        name: "FK_cardapio_categoria_id_cardapio",
                        column: x => x.id_cardapio,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "receita",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_receita_pai = table.Column<Guid>(nullable: true),
                    id_categoria = table.Column<Guid>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    n_tempo_preparo_minutos = table.Column<int>(nullable: true),
                    n_redimento_porcoes = table.Column<int>(nullable: false),
                    id_fonte = table.Column<Guid>(nullable: true),
                    id_avaliacao_media = table.Column<Guid>(nullable: true),
                    m_imagens_url = table.Column<string>(nullable: true),
                    m_videos_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receita", x => x.id);
                    table.ForeignKey(
                        name: "FK_receita_categoria_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receita_fonte_prop_intelec_id_fonte",
                        column: x => x.id_fonte,
                        principalTable: "fonte_prop_intelec",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_receita_receita_id_receita_pai",
                        column: x => x.id_receita_pai,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ingrediente",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_categoria = table.Column<Guid>(nullable: false),
                    m_imagens_url = table.Column<string>(nullable: true),
                    id_unidade_medida_compras = table.Column<Guid>(nullable: false),
                    id_unidade_medida_default = table.Column<Guid>(nullable: false),
                    n_densidade = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingrediente", x => x.id);
                    table.ForeignKey(
                        name: "FK_ingrediente_categoria_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ingrediente_unidade_medida_id_unidade_medida_default",
                        column: x => x.id_unidade_medida_default,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ingrediente_unidade_medida_id_unidade_medida_compras",
                        column: x => x.id_unidade_medida_compras,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unidade_medida_equiv",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_unidade_orig = table.Column<Guid>(nullable: true),
                    id_unidade_dest = table.Column<Guid>(nullable: true),
                    nu_razao_orig_dest = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidade_medida_equiv", x => x.id);
                    table.ForeignKey(
                        name: "FK_unidade_medida_equiv_unidade_medida_id_unidade_dest",
                        column: x => x.id_unidade_dest,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_unidade_medida_equiv_unidade_medida_id_unidade_orig",
                        column: x => x.id_unidade_orig,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "item_cardapio",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    CardapioId = table.Column<Guid>(nullable: false),
                    n_semana = table.Column<int>(nullable: false),
                    n_dia_da_semana = table.Column<int>(nullable: false),
                    n_porcoes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_cardapio", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_cardapio_cardapio_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "cardapio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avaliacao_usuario",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    qtd_estrelas = table.Column<int>(nullable: true),
                    id_usuario = table.Column<Guid>(nullable: false),
                    id_receita = table.Column<Guid>(nullable: true),
                    id_receita_media = table.Column<Guid>(nullable: true),
                    b_eh_aval_media = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacao_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_avaliacao_usuario_receita_id_receita_media",
                        column: x => x.id_receita_media,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_avaliacao_usuario_receita_id_receita",
                        column: x => x.id_receita,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_avaliacao_usuario_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etapa_preparo",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_receita = table.Column<Guid>(nullable: false),
                    n_ordem = table.Column<int>(nullable: false),
                    m_descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etapa_preparo", x => x.id);
                    table.ForeignKey(
                        name: "FK_etapa_preparo_receita_id_receita",
                        column: x => x.id_receita,
                        principalTable: "receita",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "info_nutricional",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    n_quantidade = table.Column<double>(nullable: false),
                    id_unidade_medida = table.Column<Guid>(nullable: false),
                    id_ingrediente = table.Column<Guid>(nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_nutricional", x => x.id);
                    table.ForeignKey(
                        name: "FK_info_nutricional_ingrediente_id_ingrediente",
                        column: x => x.id_ingrediente,
                        principalTable: "ingrediente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_info_nutricional_receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_info_nutricional_unidade_medida_id_unidade_medida",
                        column: x => x.id_unidade_medida,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_lista_ingrediente",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    n_ordem = table.Column<int>(nullable: false),
                    n_quantidade = table.Column<double>(nullable: false),
                    id_unidade_medida = table.Column<Guid>(nullable: false),
                    id_ingrediente = table.Column<Guid>(nullable: false),
                    id_receia = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_lista_ingrediente", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_lista_ingrediente_ingrediente_id_ingrediente",
                        column: x => x.id_ingrediente,
                        principalTable: "ingrediente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_lista_ingrediente_receita_id_receia",
                        column: x => x.id_receia,
                        principalTable: "receita",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_item_lista_ingrediente_unidade_medida_id_unidade_medida",
                        column: x => x.id_unidade_medida,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_cardapio_receita",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    ItemCardapioId = table.Column<Guid>(nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_cardapio_receita", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_cardapio_receita_item_cardapio_ItemCardapioId",
                        column: x => x.ItemCardapioId,
                        principalTable: "item_cardapio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_item_cardapio_receita_receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[] { new Guid("2eb4baee-2b56-4b70-8ce2-eb2b84145ac7"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(5715), null, null, new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(5701), null, false, null, "Categorias", "Categoria Raiz" });

            migrationBuilder.InsertData(
                table: "unidade_medida",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "_nome_resumido", "m_sinonimos", "n_tipo" },
                values: new object[,]
                {
                    { new Guid("d4416508-18c0-4f99-ac43-18e522840f70"), new DateTime(2020, 7, 6, 22, 39, 18, 898, DateTimeKind.Utc).AddTicks(8815), null, new DateTime(2020, 7, 6, 22, 39, 18, 898, DateTimeKind.Utc).AddTicks(8800), null, false, null, "unidade", "un", "unidades,unidade(un)", 2 },
                    { new Guid("3358ae34-592b-43f8-be16-704563ec4990"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(3532), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(3520), null, false, null, "grama", "g", "gramas,grama(g)", 3 },
                    { new Guid("dc30ec49-547e-4f09-ac38-78ea225cb177"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(3633), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(3628), null, false, null, "kilograma", "kg", "kilo,kilos,kilo gramas,kilogramas,kilograma(kg)", 3 },
                    { new Guid("6856d677-002f-4f5b-a7d3-f673d810ab23"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(3754), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(3749), null, false, null, "litro", "l", "litros,litro(l)", 4 },
                    { new Guid("11254ba0-ce36-452a-a5b9-b00d7732dda2"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4056), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4048), null, false, null, "xícara de chá", "xíc", "xic,cicara de cha, xícara chá, xícaras de chá,xícara(chá)", 4 },
                    { new Guid("3a7946fd-cb6a-43c1-93b8-aed9e3562524"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4199), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4194), null, false, null, "pitada", "pt", "pitada,punhadinho,cadinho", 4 },
                    { new Guid("b0d66063-6c0a-40ee-a329-596f39ec938f"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4417), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4408), null, false, null, "colher de sopa", "cso", "colher media", 4 },
                    { new Guid("ee86b6c6-e0d4-43e3-b2c6-02904f9a53be"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4526), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4520), null, false, null, "fatia", "fat", "fatia", 4 },
                    { new Guid("008a0916-dd65-453c-aee8-8d578c52cc9d"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4681), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4674), null, false, null, "unidade", "un", "unidade", 2 },
                    { new Guid("d8fcdc71-ac86-40ac-9fc2-af7d9be76bf1"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4313), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4308), null, false, null, "colher de chá", "ccha", "colher pequena", 4 },
                    { new Guid("4dd24a46-7c2d-4dbe-b269-5f3e3f23214e"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4809), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4804), null, false, null, "metro", "m", "metros,metro(m)", 1 },
                    { new Guid("3e8a3770-9bbd-4d6a-ba73-2e660e0e5e48"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4919), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(4914), null, false, null, "milimetro", "mm", "milimetros,milimetro(ml)", 1 }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "s_email", "b_fora_uso", "s_uri", "s_login", "s_nome", "s_password", "m_sinonimos", "s_token" },
                values: new object[,]
                {
                    { new Guid("c4781971-d6e1-4398-8bad-c51a08ba1bd3"), new DateTime(2020, 7, 6, 22, 39, 18, 880, DateTimeKind.Utc).AddTicks(4850), null, new DateTime(2020, 7, 6, 22, 39, 18, 875, DateTimeKind.Utc).AddTicks(8140), null, "adm@adm.com", false, null, "adm", "Administrador do sistema", "202cb962ac59075b964b07152d234b70", null, null },
                    { new Guid("bac86a82-115d-44be-ae02-ee0d0f3cafcc"), new DateTime(2020, 7, 6, 22, 39, 18, 898, DateTimeKind.Utc).AddTicks(6037), null, new DateTime(2020, 7, 6, 22, 39, 18, 898, DateTimeKind.Utc).AddTicks(5986), null, "teste@teste.com", false, null, "string", "Usuário de testes com login string e senha string", "b45cffe084dd3d20d928bee85e7b0f21", null, null }
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("45315cf2-5581-4da4-a70d-e631a347cee7"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(7611), null, new Guid("2eb4baee-2b56-4b70-8ce2-eb2b84145ac7"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(7593), null, false, null, "Ingredientes", "Categoria Raiz dos Ingredientes" },
                    { new Guid("2e72a4c2-196f-42f7-a6c4-59f5a2a77c98"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(9793), null, new Guid("2eb4baee-2b56-4b70-8ce2-eb2b84145ac7"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(9787), null, false, null, "Cardápios", "Categoria Raiz dos Cardápios" },
                    { new Guid("549691fd-d94f-456f-8e01-53577588ece9"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(60), null, new Guid("2eb4baee-2b56-4b70-8ce2-eb2b84145ac7"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(52), null, false, null, "Receitas", "Categoria Raiz das Receitas" }
                });

            migrationBuilder.InsertData(
                table: "unidade_medida_equiv",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "id_unidade_dest", "b_fora_uso", "s_uri", "s_nome", "id_unidade_orig", "nu_razao_orig_dest", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("cc4c9508-52a0-48ce-8699-0a01e907446a"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(4168), null, new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(4153), null, new Guid("6856d677-002f-4f5b-a7d3-f673d810ab23"), false, null, "xícaras de chá pra litros", new Guid("11254ba0-ce36-452a-a5b9-b00d7732dda2"), 0.25, "razão xíc/l, xícara de chá apra litros,xíc para l,xic para l" },
                    { new Guid("783d767a-0a65-4e70-9094-de2ebd2fc5e6"), new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(6929), null, new DateTime(2020, 7, 6, 22, 39, 18, 899, DateTimeKind.Utc).AddTicks(6918), null, new Guid("3e8a3770-9bbd-4d6a-ba73-2e660e0e5e48"), false, null, "metro para milimetros", new Guid("4dd24a46-7c2d-4dbe-b269-5f3e3f23214e"), 0.001, "razão m/ml, metro para milimetros,m para ml" }
                });

            migrationBuilder.InsertData(
                table: "cardapio",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_cardapio", "dt_criacao", "id_usu_criacao", "m_descricao", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "m_sinonimos", "m_videos_url" },
                values: new object[] { new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 904, DateTimeKind.Utc).AddTicks(1193), null, new Guid("2e72a4c2-196f-42f7-a6c4-59f5a2a77c98"), new DateTime(2020, 7, 6, 22, 39, 18, 904, DateTimeKind.Utc).AddTicks(1182), null, "Dieta abase de pão comum", false, null, null, "Comendo pão no café da manhã todo dia (mensal)", "café", null });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("071324f2-e468-4b36-89dd-7a8b9052f8fe"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(9387), null, new Guid("45315cf2-5581-4da4-a70d-e631a347cee7"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(9376), null, false, null, "Carnes", "carnes" },
                    { new Guid("b8a9dc26-60a8-4af3-82c0-3ac9f214480a"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(9560), null, new Guid("45315cf2-5581-4da4-a70d-e631a347cee7"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(9555), null, false, null, "hortifrutigranjeiro", "hortaliças,frutas,verduras,ovos,hortifruti" },
                    { new Guid("da67a644-0893-49e4-8710-1c4cfe42fb24"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(9669), null, new Guid("45315cf2-5581-4da4-a70d-e631a347cee7"), new DateTime(2020, 7, 6, 22, 39, 18, 900, DateTimeKind.Utc).AddTicks(9664), null, false, null, "geral", "geral" },
                    { new Guid("29547222-af56-4304-8a55-6f913bbe4ed1"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(276), null, new Guid("549691fd-d94f-456f-8e01-53577588ece9"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(268), null, false, null, "Tortas", "Categoria Raiz das tortas" },
                    { new Guid("b80fb7ea-5c38-4e6f-b9ef-703b6116f135"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(300), null, new Guid("549691fd-d94f-456f-8e01-53577588ece9"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(297), null, false, null, "Café da manhã", "Cafe da manha" },
                    { new Guid("4608e318-b1a0-40e1-ab73-920fee434d04"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(488), null, new Guid("549691fd-d94f-456f-8e01-53577588ece9"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(482), null, false, null, "Jantar", "Categoria Raiz dos Jantares" }
                });

            migrationBuilder.InsertData(
                table: "ingrediente",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria", "dt_criacao", "id_usu_criacao", "n_densidade", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "m_sinonimos", "id_unidade_medida_default", "id_unidade_medida_compras" },
                values: new object[,]
                {
                    { new Guid("1264a549-6fe1-4e2f-b615-09d8f4c13a12"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(8992), null, new Guid("b8a9dc26-60a8-4af3-82c0-3ac9f214480a"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(8982), null, 1.0, false, null, null, "Ovo de galinha", "Ovo", new Guid("d4416508-18c0-4f99-ac43-18e522840f70"), new Guid("d4416508-18c0-4f99-ac43-18e522840f70") },
                    { new Guid("5e9b48af-cb77-4d2d-9c6c-81bdee79afb8"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(1908), null, new Guid("da67a644-0893-49e4-8710-1c4cfe42fb24"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(1897), null, 700.0, false, null, null, "Farinha de Trigo", "Trigo", new Guid("11254ba0-ce36-452a-a5b9-b00d7732dda2"), new Guid("dc30ec49-547e-4f09-ac38-78ea225cb177") },
                    { new Guid("557d4cc0-0796-4076-9ca2-dc520d0a91df"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(8717), null, new Guid("da67a644-0893-49e4-8710-1c4cfe42fb24"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(8697), null, 1000.0, false, null, null, "Fermento para Pão", "Fermento biológico", new Guid("11254ba0-ce36-452a-a5b9-b00d7732dda2"), new Guid("dc30ec49-547e-4f09-ac38-78ea225cb177") },
                    { new Guid("9a34cc26-c983-4b22-8d6f-2cb21f1c56ea"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(9129), null, new Guid("da67a644-0893-49e4-8710-1c4cfe42fb24"), new DateTime(2020, 7, 6, 22, 39, 18, 901, DateTimeKind.Utc).AddTicks(9122), null, 1.0, false, null, null, "Água", "Agua", new Guid("6856d677-002f-4f5b-a7d3-f673d810ab23"), new Guid("6856d677-002f-4f5b-a7d3-f673d810ab23") }
                });

            migrationBuilder.InsertData(
                table: "item_cardapio",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "CardapioId", "dt_criacao", "id_usu_criacao", "n_dia_da_semana", "b_fora_uso", "s_uri", "s_nome", "n_porcoes", "n_semana", "m_sinonimos", "Tipo" },
                values: new object[,]
                {
                    { new Guid("4b4f5cdb-4bcf-48cc-8dd4-15ca660490a4"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(6058), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(6050), null, 3, false, null, "Café da Manhã, Terça-feira da 3a semana ", 1, 3, null, 1 },
                    { new Guid("ac94df29-83cc-4430-b005-6d340996932a"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(6459), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(6452), null, 4, false, null, "Café da Manhã, Quarta-feira da 3a semana ", 1, 3, null, 1 },
                    { new Guid("b608e54c-3dee-4eda-a49f-357351d1d8f9"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(6852), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(6845), null, 5, false, null, "Café da Manhã, Quinta-feira da 3a semana ", 1, 3, null, 1 },
                    { new Guid("d8087b48-adee-4c58-aa28-14acdb4fa71a"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(7222), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(7215), null, 6, false, null, "Café da Manhã, Sexta-feira da 3a semana ", 1, 3, null, 1 },
                    { new Guid("0c57eef4-3d4c-459a-97d5-b49ba489ba0f"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(7602), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(7595), null, 7, false, null, "Café da Manhã, Sábado da 3a semana ", 1, 3, null, 1 },
                    { new Guid("d16658ea-7a5c-4553-859f-4cd4e369e553"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(8456), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(8448), null, 2, false, null, "Café da Manhã, Segunda-feira da 4a semana ", 1, 4, null, 1 },
                    { new Guid("f021271f-e90f-4edc-a97e-a8594376ec9d"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(5684), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(5677), null, 2, false, null, "Café da Manhã, Segunda-feira da 3a semana ", 1, 3, null, 1 },
                    { new Guid("c10cc0b7-2d6b-43c3-9484-20a8ffd6c45f"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(9033), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(9023), null, 3, false, null, "Café da Manhã, Terça-feira da 4a semana ", 1, 4, null, 1 },
                    { new Guid("b563d2fb-17cf-4566-b3f2-e896cace3429"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(9478), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(9471), null, 4, false, null, "Café da Manhã, Quarta-feira da 4a semana ", 1, 4, null, 1 },
                    { new Guid("b22a71f1-1050-4404-9ce7-ffcaef70985b"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(9897), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(9888), null, 5, false, null, "Café da Manhã, Quinta-feira da 4a semana ", 1, 4, null, 1 },
                    { new Guid("1deb3ace-753a-4976-8595-51c05dfee6a1"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(248), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(242), null, 6, false, null, "Café da Manhã, Sexta-feira da 4a semana ", 1, 4, null, 1 },
                    { new Guid("ad3d95d7-08e9-49f5-8f09-1a3205f7f5bf"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(8046), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(8038), null, 1, false, null, "Café da Manhã, Domingo da 4a semana ", 1, 4, null, 1 },
                    { new Guid("99285a29-197f-47b5-87df-5e0fab0cd9e1"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(5317), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(5310), null, 1, false, null, "Café da Manhã, Domingo da 3a semana ", 1, 3, null, 1 },
                    { new Guid("1ab03e0d-d8af-4729-bcf2-9aa34b1ad9b8"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(4470), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(4463), null, 6, false, null, "Café da Manhã, Sexta-feira da 2a semana ", 1, 2, null, 1 },
                    { new Guid("c00c8f3a-5ff5-4962-a107-faea8d85bd8f"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(566), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(560), null, 7, false, null, "Café da Manhã, Sábado da 4a semana ", 1, 4, null, 1 },
                    { new Guid("bdc435ab-f511-450a-bff8-b0f824c6977c"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(4102), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(4095), null, 5, false, null, "Café da Manhã, Quinta-feira da 2a semana ", 1, 2, null, 1 },
                    { new Guid("e08be16a-b32f-47d7-8fe4-775f6164f154"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(3734), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(3727), null, 4, false, null, "Café da Manhã, Quarta-feira da 2a semana ", 1, 2, null, 1 },
                    { new Guid("8cf9f417-493d-473f-9e4d-ca0c0dc6c571"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(3351), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(3343), null, 3, false, null, "Café da Manhã, Terça-feira da 2a semana ", 1, 2, null, 1 },
                    { new Guid("f418d161-6a86-413c-beb5-1d30f90f3fe7"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(2932), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(2925), null, 2, false, null, "Café da Manhã, Segunda-feira da 2a semana ", 1, 2, null, 1 },
                    { new Guid("6aa888e7-d78d-4192-937f-5d5483b44e45"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(2562), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(2555), null, 1, false, null, "Café da Manhã, Domingo da 2a semana ", 1, 2, null, 1 },
                    { new Guid("fb1ae416-358b-45ea-b2c3-d742bf762173"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(2191), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(2184), null, 7, false, null, "Café da Manhã, Sábado da 1a semana ", 1, 1, null, 1 },
                    { new Guid("df4cc799-1a69-489d-80c6-610faf4a9cac"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(1804), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(1796), null, 6, false, null, "Café da Manhã, Sexta-feira da 1a semana ", 1, 1, null, 1 },
                    { new Guid("cf5b4c40-6571-42a9-8545-bb647b8d112b"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(1177), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(1169), null, 5, false, null, "Café da Manhã, Quinta-feira da 1a semana ", 1, 1, null, 1 },
                    { new Guid("2481ef11-2d44-4c44-9572-6f0dcd680fdf"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(811), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(804), null, 4, false, null, "Café da Manhã, Quarta-feira da 1a semana ", 1, 1, null, 1 },
                    { new Guid("3a0fc70c-7693-47bc-8dd0-e2251b160637"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(425), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(417), null, 3, false, null, "Café da Manhã, Terça-feira da 1a semana ", 1, 1, null, 1 },
                    { new Guid("226d164c-42b9-4d20-83c7-201e18afd77d"), new DateTime(2020, 7, 6, 22, 39, 18, 906, DateTimeKind.Utc).AddTicks(9794), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 906, DateTimeKind.Utc).AddTicks(9778), null, 2, false, null, "Café da Manhã, Segunda-feira da 1a semana ", 1, 1, null, 1 },
                    { new Guid("2be93c00-16e6-47c0-8011-1af9ddfc6035"), new DateTime(2020, 7, 6, 22, 39, 18, 906, DateTimeKind.Utc).AddTicks(1077), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 906, DateTimeKind.Utc).AddTicks(1049), null, 1, false, null, "Café da Manhã, Domingo da 1a semana ", 1, 1, null, 1 },
                    { new Guid("a529add5-d8af-4567-873e-6125ced81f2d"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(4940), null, new Guid("a5be3559-fd58-4c28-9229-e9541b2a59e6"), new DateTime(2020, 7, 6, 22, 39, 18, 907, DateTimeKind.Utc).AddTicks(4930), null, 7, false, null, "Café da Manhã, Sábado da 2a semana ", 1, 2, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "receita",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_avaliacao_media", "id_categoria", "dt_criacao", "id_usu_criacao", "descricao", "id_fonte", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "id_receita_pai", "n_redimento_porcoes", "m_sinonimos", "n_tempo_preparo_minutos", "m_videos_url" },
                values: new object[] { new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), new DateTime(2020, 7, 6, 22, 39, 18, 902, DateTimeKind.Utc).AddTicks(2006), null, null, new Guid("b80fb7ea-5c38-4e6f-b9ef-703b6116f135"), new DateTime(2020, 7, 6, 22, 39, 18, 902, DateTimeKind.Utc).AddTicks(1994), null, null, null, false, null, null, "Pão de Forma", null, 5, "Pão assado,pao assado", 120, null });

            migrationBuilder.InsertData(
                table: "item_cardapio_receita",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "ItemCardapioId", "s_uri", "s_nome", "ReceitaId", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("94623fff-9597-4650-945a-de1bd3b9b9b2"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(3126), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(3108), null, false, new Guid("2be93c00-16e6-47c0-8011-1af9ddfc6035"), null, "Rel. Item Cardápio(Café da Manhã, Domingo da 1a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("b65fc97a-1932-42c6-a670-ff54ae1980b8"), new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(1550), null, new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(1545), null, false, new Guid("c00c8f3a-5ff5-4962-a107-faea8d85bd8f"), null, "Rel. Item Cardápio(Café da Manhã, Sábado da 4a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("e5b9002b-74eb-49ca-9862-0c879ea15c85"), new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(1442), null, new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(1435), null, false, new Guid("1deb3ace-753a-4976-8595-51c05dfee6a1"), null, "Rel. Item Cardápio(Café da Manhã, Sexta-feira da 4a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("c1cd67c3-ba43-4973-bd23-53723e7d312c"), new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(1329), null, new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(1323), null, false, new Guid("b22a71f1-1050-4404-9ce7-ffcaef70985b"), null, "Rel. Item Cardápio(Café da Manhã, Quinta-feira da 4a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("4792c028-ec00-4145-b209-ae680e8b88d4"), new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(1087), null, new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(1080), null, false, new Guid("b563d2fb-17cf-4566-b3f2-e896cace3429"), null, "Rel. Item Cardápio(Café da Manhã, Quarta-feira da 4a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("b4464d6c-71b3-43c2-a7e2-ad92462fd17e"), new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(948), null, new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(941), null, false, new Guid("c10cc0b7-2d6b-43c3-9484-20a8ffd6c45f"), null, "Rel. Item Cardápio(Café da Manhã, Terça-feira da 4a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("964fdd70-a1dd-43b5-8f02-aa126bb59631"), new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(805), null, new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(798), null, false, new Guid("d16658ea-7a5c-4553-859f-4cd4e369e553"), null, "Rel. Item Cardápio(Café da Manhã, Segunda-feira da 4a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("e3e59b58-ef13-4095-b216-2edeb7646760"), new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(663), null, new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(657), null, false, new Guid("ad3d95d7-08e9-49f5-8f09-1a3205f7f5bf"), null, "Rel. Item Cardápio(Café da Manhã, Domingo da 4a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("ded43d85-e332-47aa-a945-edd0c1f75ce1"), new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(513), null, new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(507), null, false, new Guid("0c57eef4-3d4c-459a-97d5-b49ba489ba0f"), null, "Rel. Item Cardápio(Café da Manhã, Sábado da 3a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("e26b53cc-6163-4e27-8ec0-9bb3e81a6690"), new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(380), null, new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(373), null, false, new Guid("d8087b48-adee-4c58-aa28-14acdb4fa71a"), null, "Rel. Item Cardápio(Café da Manhã, Sexta-feira da 3a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("04104fa3-d97a-4abc-acc1-d0cb465caea5"), new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(248), null, new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(240), null, false, new Guid("b608e54c-3dee-4eda-a49f-357351d1d8f9"), null, "Rel. Item Cardápio(Café da Manhã, Quinta-feira da 3a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("09759438-9cbf-450f-989c-6a8bc75f374c"), new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(102), null, new DateTime(2020, 7, 6, 22, 39, 18, 909, DateTimeKind.Utc).AddTicks(96), null, false, new Guid("ac94df29-83cc-4430-b005-6d340996932a"), null, "Rel. Item Cardápio(Café da Manhã, Quarta-feira da 3a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("36bc149c-b50b-4256-8607-410663fc3c93"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9811), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9805), null, false, new Guid("f021271f-e90f-4edc-a97e-a8594376ec9d"), null, "Rel. Item Cardápio(Café da Manhã, Segunda-feira da 3a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("375a69ec-a6f5-4559-94ee-01f3c572c733"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9672), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9665), null, false, new Guid("99285a29-197f-47b5-87df-5e0fab0cd9e1"), null, "Rel. Item Cardápio(Café da Manhã, Domingo da 3a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("d50e7c71-71f7-4c6d-a471-fdc8c959530b"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9945), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9939), null, false, new Guid("4b4f5cdb-4bcf-48cc-8dd4-15ca660490a4"), null, "Rel. Item Cardápio(Café da Manhã, Terça-feira da 3a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("5eb8f62c-242a-42a0-931a-0f2b1d4762e6"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9271), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9264), null, false, new Guid("1ab03e0d-d8af-4729-bcf2-9aa34b1ad9b8"), null, "Rel. Item Cardápio(Café da Manhã, Sexta-feira da 2a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("71ede0f2-5ba5-4e44-bd34-53e465fd2374"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(7373), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(7358), null, false, new Guid("226d164c-42b9-4d20-83c7-201e18afd77d"), null, "Rel. Item Cardápio(Café da Manhã, Segunda-feira da 1a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("f7f0d0a0-744b-4d73-a432-7768a2f3d60f"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(7630), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(7621), null, false, new Guid("3a0fc70c-7693-47bc-8dd0-e2251b160637"), null, "Rel. Item Cardápio(Café da Manhã, Terça-feira da 1a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("cb9118bc-e577-4932-8aa9-b5b8a399332c"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(7917), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(7908), null, false, new Guid("2481ef11-2d44-4c44-9572-6f0dcd680fdf"), null, "Rel. Item Cardápio(Café da Manhã, Quarta-feira da 1a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("23b3cefc-b677-4699-8b40-4b4bc2998149"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8057), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8051), null, false, new Guid("cf5b4c40-6571-42a9-8545-bb647b8d112b"), null, "Rel. Item Cardápio(Café da Manhã, Quinta-feira da 1a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("e1506ea7-d4fc-4414-b7a4-c8160ffa88e3"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9437), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9431), null, false, new Guid("a529add5-d8af-4567-873e-6125ced81f2d"), null, "Rel. Item Cardápio(Café da Manhã, Sábado da 2a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("7f45fd2d-1967-44b7-afa5-a59f569e9ccf"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8440), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8434), null, false, new Guid("fb1ae416-358b-45ea-b2c3-d742bf762173"), null, "Rel. Item Cardápio(Café da Manhã, Sábado da 1a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("bc8e4706-c309-4cf8-bc89-4b13d7b11782"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8283), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8276), null, false, new Guid("df4cc799-1a69-489d-80c6-610faf4a9cac"), null, "Rel. Item Cardápio(Café da Manhã, Sexta-feira da 1a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("2c0962fe-fc18-4ce2-b455-c492b8d4c7a2"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8699), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8691), null, false, new Guid("f418d161-6a86-413c-beb5-1d30f90f3fe7"), null, "Rel. Item Cardápio(Café da Manhã, Segunda-feira da 2a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("c4a893a9-7cee-4137-991a-58b991bf3562"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8847), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8840), null, false, new Guid("8cf9f417-493d-473f-9e4d-ca0c0dc6c571"), null, "Rel. Item Cardápio(Café da Manhã, Terça-feira da 2a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("545e94cc-f07c-4a08-b9a5-142b13ec94f0"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8989), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8983), null, false, new Guid("e08be16a-b32f-47d7-8fe4-775f6164f154"), null, "Rel. Item Cardápio(Café da Manhã, Quarta-feira da 2a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("30f9ee2f-95c4-4ce5-9957-19501936cf60"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9135), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(9129), null, false, new Guid("bdc435ab-f511-450a-bff8-b0f824c6977c"), null, "Rel. Item Cardápio(Café da Manhã, Quinta-feira da 2a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null },
                    { new Guid("9543427b-ec88-4419-a4c5-a0702610ee20"), new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8566), null, new DateTime(2020, 7, 6, 22, 39, 18, 908, DateTimeKind.Utc).AddTicks(8558), null, false, new Guid("6aa888e7-d78d-4192-937f-5d5483b44e45"), null, "Rel. Item Cardápio(Café da Manhã, Domingo da 2a semana ) x Receita(Pão de Forma)", new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null }
                });

            migrationBuilder.InsertData(
                table: "item_lista_ingrediente",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "id_ingrediente", "s_uri", "s_nome", "n_ordem", "n_quantidade", "id_receia", "m_sinonimos", "id_unidade_medida" },
                values: new object[,]
                {
                    { new Guid("7cab5f78-7e33-40e6-8bb6-23709c402fbe"), new DateTime(2020, 7, 6, 22, 39, 18, 903, DateTimeKind.Utc).AddTicks(8848), null, new DateTime(2020, 7, 6, 22, 39, 18, 903, DateTimeKind.Utc).AddTicks(8842), null, false, new Guid("1264a549-6fe1-4e2f-b615-09d8f4c13a12"), null, "Ovo de galinha", 2, 5.0, new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null, new Guid("d4416508-18c0-4f99-ac43-18e522840f70") },
                    { new Guid("86ec42ce-ea76-41e4-95a8-997542f6c008"), new DateTime(2020, 7, 6, 22, 39, 18, 903, DateTimeKind.Utc).AddTicks(14), null, new DateTime(2020, 7, 6, 22, 39, 18, 902, DateTimeKind.Utc).AddTicks(9999), null, false, new Guid("5e9b48af-cb77-4d2d-9c6c-81bdee79afb8"), null, "Farinha de Trigo", 0, 3.0, new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null, new Guid("11254ba0-ce36-452a-a5b9-b00d7732dda2") },
                    { new Guid("23380c7f-1709-4536-9cff-d98adaa92288"), new DateTime(2020, 7, 6, 22, 39, 18, 903, DateTimeKind.Utc).AddTicks(8335), null, new DateTime(2020, 7, 6, 22, 39, 18, 903, DateTimeKind.Utc).AddTicks(8320), null, false, new Guid("5e9b48af-cb77-4d2d-9c6c-81bdee79afb8"), null, "Farinha de Trigo", 0, 3.0, new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null, new Guid("11254ba0-ce36-452a-a5b9-b00d7732dda2") },
                    { new Guid("d7fe7fda-1a06-44c3-8921-3e01adb63339"), new DateTime(2020, 7, 6, 22, 39, 18, 903, DateTimeKind.Utc).AddTicks(8724), null, new DateTime(2020, 7, 6, 22, 39, 18, 903, DateTimeKind.Utc).AddTicks(8717), null, false, new Guid("557d4cc0-0796-4076-9ca2-dc520d0a91df"), null, "Fermento para Pão", 1, 1.0, new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null, new Guid("11254ba0-ce36-452a-a5b9-b00d7732dda2") },
                    { new Guid("de8c42be-6b43-42ca-8917-98281baa5ed8"), new DateTime(2020, 7, 6, 22, 39, 18, 903, DateTimeKind.Utc).AddTicks(8978), null, new DateTime(2020, 7, 6, 22, 39, 18, 903, DateTimeKind.Utc).AddTicks(8969), null, false, new Guid("9a34cc26-c983-4b22-8d6f-2cb21f1c56ea"), null, "Água", 3, 0.5, new Guid("1085ed74-dee9-42ad-a41b-77d67dcf7d41"), null, new Guid("6856d677-002f-4f5b-a7d3-f673d810ab23") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_usuario_id_receita_media",
                table: "avaliacao_usuario",
                column: "id_receita_media",
                unique: true,
                filter: "[id_receita_media] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_usuario_id_receita",
                table: "avaliacao_usuario",
                column: "id_receita");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_usuario_id_usuario",
                table: "avaliacao_usuario",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_cardapio_id_cardapio",
                table: "cardapio",
                column: "id_cardapio");

            migrationBuilder.CreateIndex(
                name: "IX_categoria_id_categoria_pai",
                table: "categoria",
                column: "id_categoria_pai");

            migrationBuilder.CreateIndex(
                name: "IX_etapa_preparo_id_receita",
                table: "etapa_preparo",
                column: "id_receita");

            migrationBuilder.CreateIndex(
                name: "IX_info_nutricional_id_ingrediente",
                table: "info_nutricional",
                column: "id_ingrediente");

            migrationBuilder.CreateIndex(
                name: "IX_info_nutricional_ReceitaId",
                table: "info_nutricional",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_info_nutricional_id_unidade_medida",
                table: "info_nutricional",
                column: "id_unidade_medida");

            migrationBuilder.CreateIndex(
                name: "IX_ingrediente_id_categoria",
                table: "ingrediente",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_ingrediente_id_unidade_medida_default",
                table: "ingrediente",
                column: "id_unidade_medida_default");

            migrationBuilder.CreateIndex(
                name: "IX_ingrediente_id_unidade_medida_compras",
                table: "ingrediente",
                column: "id_unidade_medida_compras");

            migrationBuilder.CreateIndex(
                name: "IX_item_cardapio_CardapioId",
                table: "item_cardapio",
                column: "CardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_item_cardapio_receita_ItemCardapioId",
                table: "item_cardapio_receita",
                column: "ItemCardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_item_cardapio_receita_ReceitaId",
                table: "item_cardapio_receita",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_item_lista_ingrediente_id_ingrediente",
                table: "item_lista_ingrediente",
                column: "id_ingrediente");

            migrationBuilder.CreateIndex(
                name: "IX_item_lista_ingrediente_id_receia",
                table: "item_lista_ingrediente",
                column: "id_receia");

            migrationBuilder.CreateIndex(
                name: "IX_item_lista_ingrediente_id_unidade_medida",
                table: "item_lista_ingrediente",
                column: "id_unidade_medida");

            migrationBuilder.CreateIndex(
                name: "IX_receita_id_categoria",
                table: "receita",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_receita_id_fonte",
                table: "receita",
                column: "id_fonte");

            migrationBuilder.CreateIndex(
                name: "IX_receita_id_receita_pai",
                table: "receita",
                column: "id_receita_pai");

            migrationBuilder.CreateIndex(
                name: "IX_unidade_medida_equiv_id_unidade_dest",
                table: "unidade_medida_equiv",
                column: "id_unidade_dest");

            migrationBuilder.CreateIndex(
                name: "IX_unidade_medida_equiv_id_unidade_orig",
                table: "unidade_medida_equiv",
                column: "id_unidade_orig");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avaliacao_usuario");

            migrationBuilder.DropTable(
                name: "etapa_preparo");

            migrationBuilder.DropTable(
                name: "info_nutricional");

            migrationBuilder.DropTable(
                name: "item_cardapio_receita");

            migrationBuilder.DropTable(
                name: "item_lista_ingrediente");

            migrationBuilder.DropTable(
                name: "unidade_medida_equiv");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "item_cardapio");

            migrationBuilder.DropTable(
                name: "ingrediente");

            migrationBuilder.DropTable(
                name: "receita");

            migrationBuilder.DropTable(
                name: "cardapio");

            migrationBuilder.DropTable(
                name: "unidade_medida");

            migrationBuilder.DropTable(
                name: "fonte_prop_intelec");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
