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
                    id_usu_criacao = table.Column<Guid>(nullable: false),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: false),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: false),
                    id_categoria_pai = table.Column<Guid>(nullable: false)
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
                    id_usu_criacao = table.Column<Guid>(nullable: false),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: false),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: false),
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
                    id_usu_criacao = table.Column<Guid>(nullable: false),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: false),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: false),
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
                    id_usu_criacao = table.Column<Guid>(nullable: false),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: false),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: false),
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
                name: "ingrediente",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: false),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: false),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: false),
                    id_categoria = table.Column<Guid>(nullable: false),
                    m_imagens_url = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "receita",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: false),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: false),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: false),
                    id_receita_pai = table.Column<Guid>(nullable: true),
                    id_categoria = table.Column<Guid>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    n_tempo_preparo_minutos = table.Column<int>(nullable: true),
                    n_redimento_porcoes = table.Column<int>(nullable: true),
                    id_fonte = table.Column<Guid>(nullable: false),
                    id_avaliacao_media = table.Column<Guid>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receita_receita_id_receita_pai",
                        column: x => x.id_receita_pai,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unidade_medida_equiv",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: false),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: false),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: false),
                    id_unidade_orig = table.Column<Guid>(nullable: false),
                    id_unidade_dest = table.Column<Guid>(nullable: false),
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
                name: "avaliacao_usuario",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: false),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: false),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: false),
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
                    id_usu_criacao = table.Column<Guid>(nullable: false),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: false),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: false),
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "info_nutricional",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: false),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: false),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: false),
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
                    id_usu_criacao = table.Column<Guid>(nullable: false),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: false),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: false),
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_item_lista_ingrediente_unidade_medida_id_unidade_medida",
                        column: x => x.id_unidade_medida,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "item_lista_ingrediente");

            migrationBuilder.DropTable(
                name: "unidade_medida_equiv");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "ingrediente");

            migrationBuilder.DropTable(
                name: "receita");

            migrationBuilder.DropTable(
                name: "unidade_medida");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "fonte_prop_intelec");
        }
    }
}
