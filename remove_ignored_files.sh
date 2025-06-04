while IFS= read -r file; do
  git rm --cached "$file"
done < .gitignore