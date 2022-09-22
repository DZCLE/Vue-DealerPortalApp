// const devToolToUse = process.env.NODE_ENV !== 'production' ? 'eval-cheap-module-source-map' : 'source-map'

module.exports = {
  publicPath: process.env.PUBLIC_PATH,
  chainWebpack: (config) => {
    config.plugin('html').tap((args) => {
      args[0].title = 'Dealer Self Service App'
      return args
    })
    // config.devtool(devToolToUse)
  },
  transpileDependencies: ['vuetify', 'camelcase-keys', 'map-obj', 'camelcase', 'quick-lru'],
  css: {
    loaderOptions: {
      scss: {
        additionalData:
          '@import "@/styles/_variables.scss"; @import "@/styles/_vuetifyStyles.scss"; @import "@/styles/_common.scss"; @import "@/styles/_tables.scss"; @import "@/styles/_button.scss";',
      },
    },
  },
  configureWebpack: {
    devtool: "source-map"
  }
}