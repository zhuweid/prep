configs ={
  :git => {
    :user => 'sydneyjune2013',
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'prep' 
  }
}
configatron.configure_from_hash(configs)
