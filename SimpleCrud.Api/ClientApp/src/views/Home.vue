<template>
    <div id="home">
        <div class="container">
            <b-loading :is-full-page="true" :active.sync="isLoading" :can-cancel="false"/>

            <div class="columns is-centered is-mobile is-multiline has-side-margin has-negative-top-margin">
                <div class="column is-three-quarters-tablet is-full-desktop is-full-fullhd">
                    <div class="box has-shadow">
                        <p class="has-text-left has-text-weight-bold has-margin-5">
                            {{ $t('home.list.title') }}
                        </p>

                        <b-table ref="tableEmpresas" class="has-margin-table" :data="empresas" hoverable
                            :default-sort-direction="defaultSortOrder" :default-sort="[sortField, sortOrder]">
                            <template slot-scope="props">
                                <b-table-column class="is-unselectable" cell-class="is-vertical" field="nome" :label="$t('home.list.name')">
                                    {{props.row.nome}}
                                </b-table-column>

                                <b-table-column class="is-unselectable" cell-class="is-vertical" field="site" :label="$t('home.list.site')">
                                    {{props.row.site}}
                                </b-table-column>

                                <b-table-column class="is-unselectable" cell-class="is-vertical" field="quantidadeFuncionarios" :label="$t('home.list.quantity')">
                                    {{props.row.quantidadeFuncionarios}}
                                </b-table-column>

                                <b-table-column class="is-unselectable" width="90" cell-class="has-pointer">
                                    <div class="level is-mobile has-top-margin">
                                        <div class="level-left">
                                            <div class="level-item">
                                                <b-button class="button is-smaller" type="is-dark" icon-left="edit" @click="edit(props.row)"/>
                                            </div>
                                        </div>

                                        <div class="level-right">
                                            <div class="level-item">
                                                <b-button class="button is-smaller" type="is-dark" icon-left="trash" @click="remove(props.row)"/>
                                            </div>
                                        </div>
                                    </div>
                                </b-table-column>
                            </template>

                            <template slot="empty">
                                <div class="content has-text-grey has-text-centered has-bottom-margin">
                                    <p>{{ $t('home.list.none') }}</p>
                                </div>
                            </template>
                        </b-table>

                        <b-modal :active.sync="isEditting" trap-focus aria-role="dialog" aria-modal :width="500" scroll="keep">
                            <div class="box has-text-centered content" style="padding: 40px">
                                <h2 class="title">{{ $t('home.edit.title') }}</h2>
                            
                                <div>
                                    <b-field :label="$t('home.list.name')" position="is-centered" expanded :type="{ 'is-danger': nameEmptyError || nameRepeatedError }" 
                                            :message="[{ 'O nome deve conter 2 ou mais caracteres.': nameEmptyError }, { 'Já existe uma empresa com esse nome.': nameRepeatedError }]">
                                        <b-input type="text" maxlength="255" :placeholder="$t('home.list.name-info')" v-model="editEmpresa.nome"/>
                                    </b-field>

                                    <b-field :label="$t('home.list.site')" position="is-centered" expanded>
                                        <b-input type="text" maxlength="255" :placeholder="$t('home.list.site-info')" v-model="editEmpresa.site"/>
                                    </b-field>

                                    <b-field :label="$t('home.list.quantity')" position="is-centered" expanded :type="{ 'is-danger': quantEmptyError }" 
                                        :message="[{ 'A empresa deve conter 1 ou mais funcionários.': quantEmptyError }]">
                                        <b-input type="number" :placeholder="$t('home.list.quantity-info')" v-model="editEmpresa.quantidadeFuncionarios"/>
                                    </b-field>

                                    <hr>

                                    <div class="level is-mobile has-top-margin">
                                        <div class="level-left">
                                            <div class="level-item">
                                                <b-button class="has-margin-as-label" type="is-dark" icon-left="save" @click="confirmEdit()">{{ $t('home.edit.save') }}</b-button>
                                            </div>
                                        </div>

                                        <div class="level level-right">
                                            <div class="level-item">
                                                <b-button class="has-margin-as-label" type="is-dark" icon-left="times" @click="cancelEdit()">{{ $t('home.edit.cancel') }}</b-button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </b-modal>

                        <div>
                            <b-field :label="$t('home.list.name')" position="is-centered" expanded :type="{ 'is-danger': nameEmptyError || nameRepeatedError }" 
                                    :message="[{ 'O nome deve conter 2 ou mais caracteres.': nameEmptyError }, { 'Já existe uma empresa com esse nome.': nameRepeatedError }]">
                                <b-input type="text" maxlength="255" :placeholder="$t('home.list.name-info')" v-model="newName"/>
                            </b-field>

                            <b-field grouped style="margin-right: 0">
                                <b-field :label="$t('home.list.site')" position="is-centered" expanded>
                                    <b-input type="text" maxlength="255" :placeholder="$t('home.list.site-info')" v-model="newSite"/>
                                </b-field>

                                <b-field :label="$t('home.list.quantity')" position="is-centered" :type="{ 'is-danger': quantEmptyError }" 
                                    :message="[{ 'A empresa deve conter 1 ou mais funcionários.': quantEmptyError }]">
                                    <b-input type="number" :placeholder="$t('home.list.quantity-info')" v-model="newQuantity"/>
                                </b-field>
                            </b-field>

                            <div class="level is-mobile has-top-margin">
                                <div class="level-left">
                                    <!-- Leave in blank to make the right side stick to the side -->
                                </div>

                                <div class="level level-right">
                                    <div class="level-item">
                                        <b-button class="has-margin-as-label" type="is-dark" icon-left="plus" @click="add()">{{ $t('home.new.add') }}</b-button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "Home",

    data() {
        return {
            isLoading: true,
            isEditting: false,

            empresas: [],
            newName: "",
            newSite: "",
            newQuantity: 0,
            nameEmptyError: false,
            nameRepeatedError: false,
            quantEmptyError: false,
            editEmpresa: {},

            sortField: "properties.empresa.name",
            sortOrder: "asc",
            defaultSortOrder: "asc",
        };
    },

    async mounted() {
        try {
            var response = await this.$store.dispatch("empresa/getAll");

            if (response != null)
                this.empresas = response;
        } catch (e) {
            this.$buefy.snackbar.open({
                duration: 5000,
                message: 'Error while trying to get companies.',
                type: 'is-danger',
                position: 'is-bottom-left',
                actionText: 'Ok',
            });

            console.log("Error in getting companies", e);
        } finally {
            this.isLoading = false;
        }
    },

    methods: {
        isEmpty(obj) {
            for (var i in obj) 
                return false;

            return true;
        },
        async add(){
            this.nameEmptyError = false;
            this.nameRepeatedError = false;
            this.quantEmptyError = false;

            if (this.newName.length < 2) {
                this.nameEmptyError = true;
                return;
            }

            if (this.newQuant < 1) {
                this.quantEmptyError = true;
                return;
            }

            var params = {
                nome: this.newName,
                site: this.newSite,
                quantidadeFuncionarios: parseInt(this.newQuantity)
            };

            var resp = await this.$store.dispatch('empresa/add', { params });

            if (resp && resp.code == 102) {
                this.nameRepeatedError = true;
                return;
            }

            this.empresas = this.$store.state.empresa.empresas;
            this.clear();
        },
        edit(row){
            console.log(row);

            this.editEmpresa = row;
            this.isEditting = true;
        },
        async confirmEdit(){
            this.nameEmptyError = false;
            this.nameRepeatedError = false;
            this.quantEmptyError = false;

            if (this.editEmpresa.nome.length < 2) {
                this.nameEmptyError = true;
                return;
            }

            if (this.editEmpresa.quantidadeFuncionarios < 1) {
                this.quantEmptyError = true;
                return;
            }

            var params = {
                id: this.editEmpresa.id,
                nome: this.editEmpresa.nome,
                site: this.editEmpresa.site,
                quantidadeFuncionarios: parseInt(this.editEmpresa.quantidadeFuncionarios)
            };

            var resp = await this.$store.dispatch('empresa/update', { params });

            if (resp && resp.code == 102) {
                this.nameRepeatedError = true;
                return;
            }

            this.isEditting = false;
            this.empresas = this.$store.state.empresa.empresas;
            console.log(this.$store.state);
        },
        cancelEdit(){
            this.isEditting = false;
        },
        async remove(row, confirm){
            if (confirm == null){
                    this.$buefy.dialog.confirm({
                        title: 'Remoção de empresa',
                        message: 'Você deseja <b>remover</b> a empresa <i>' + row.nome + '</i>?',
                        confirmText: 'Sim',
                        cancelText: 'Não',
                        type: 'is-danger',
                        hasIcon: true,
                        onConfirm: () => this.remove(row, true)
                    });
                    return;
                }

            var id = parseInt(row.id);
            await this.$store.dispatch('empresa/delete', { id });
            this.empresas = this.$store.state.empresa.empresas;
        },
        clear() {
            this.nameEmptyError = false;
            this.nameRepeatedError = false;
            this.quantEmptyError = false;
            this.newName = "";
            this.newSite = "";
            this.newQuantity = 0;
        },
    },
};
</script>

<style lang="scss" scoped>
.has-side-margin {
    margin: 10px 0;
}

.columns {
    margin-top: -60px;
}

.has-shadow {
    border-radius: 2px;
    box-shadow: 0px 0px 16px rgba(0, 0, 0, 0.06);
}

.column .is-padded {
    padding: 0.75rem;
}

.column .button {
    white-space: normal;
    border-radius: 2px;
    width: 100%;
    height: 100%;
}

.limits-with-ellipses {
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
}
</style>

<style lang="scss">
.button > span {
    width: 100%;
    padding: 0px 5px;
}
</style>